using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_project
{
    public partial class Inventory : Form
    {
        SqlConnection conn = new SqlConnection(
            "Data Source=.; Initial Catalog=PharmacyMgmtDB; Integrated Security=True; TrustServerCertificate=True");

        public Inventory()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSearch.Click += btnSearch_Click;
            btnClear.Click += btnClear_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

           // Handle Connection 
        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        // load Data
        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadBranches();

            showingby.SelectedIndex = 1; // All Branches default
            UpdateControlVisibility(); // 

            LoadAllBranches();
        }

        private void LoadBranches()
        {
            try
            {
                OpenConnection();

                string query = "SELECT BID, BNAME FROM BRANCH";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //  Add default row
                DataRow row = dt.NewRow();
                row["BID"] = DBNull.Value; // no real ID
                row["BNAME"] = "-- Select Branch --";
                dt.Rows.InsertAt(row, 0);


                BranchComboBox.DisplayMember = "BNAME";
                BranchComboBox.ValueMember = "BID";
                BranchComboBox.DataSource = dt;
            }
            finally { CloseConnection(); }
        }

        //  All Branch View
        private void LoadAllBranches()
        {
            try
            {
                OpenConnection();

                string query = @"SELECT d.SERIAL_NUM, d.D_NAME,
                                ISNULL(SUM(e.CURRENT_QUANTITY),0) AS Amount,
                                d.CATEGORY, d.SUPPLIER
                                FROM DRUG d
                                LEFT JOIN EXIST_IN e ON d.SERIAL_NUM = e.Serial_NUM
                                GROUP BY d.SERIAL_NUM, d.D_NAME, d.CATEGORY, d.SUPPLIER";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                FillGrid(dt);
            }
            finally { CloseConnection(); }
        }

        // By Branch View
        private void LoadByBranch()
        {
            try
            {
                OpenConnection();

                string query = @"SELECT 
                        d.SERIAL_NUM, 
                        d.D_NAME,
                        b.BNAME AS Branch,
                        e.CURRENT_QUANTITY AS Amount,
                        d.CATEGORY, 
                        d.SUPPLIER
                        FROM DRUG d
                        JOIN EXIST_IN e ON d.SERIAL_NUM = e.Serial_NUM
                        JOIN BRANCH b ON e.B_ID = b.BID
                        ORDER BY d.SERIAL_NUM, b.BNAME";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                FillGrid(dt, true); // TRUE = show branch column
            }
            finally { CloseConnection(); }
        }
           // Fill The Grid with The Data
        private void FillGrid(DataTable dt, bool showBranch = false)
        {
            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int index = dataGridView1.Rows.Add();

                dataGridView1.Rows[index].Cells["SERIAL_NUM"].Value = row["SERIAL_NUM"];
                dataGridView1.Rows[index].Cells["Dname"].Value = row["D_NAME"];
                dataGridView1.Rows[index].Cells["Amount"].Value = row["Amount"];
                dataGridView1.Rows[index].Cells["Category"].Value = row["CATEGORY"];
                dataGridView1.Rows[index].Cells["supplier"].Value = row["SUPPLIER"];

                if (showBranch && dt.Columns.Contains("Branch"))
                {
                    dataGridView1.Rows[index].Cells["DBranch"].Value = row["Branch"];
                }
            }
        }

        // ---------------------- ADD -------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validation
            if (DidInput.Text == "" ||
                DnameInput.Text == "" ||
                cat.Text == "" ||
                DsupplierInput.Text == "" ||
                QuantutyInput.Text == "" ||
                BranchComboBox.SelectedValue == null)
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            try
            {
                using (SqlConnection c = new SqlConnection(conn.ConnectionString))
                {
                    c.Open();

                    string drugId = DidInput.Text;
                    string branchId = BranchComboBox.SelectedValue.ToString();
                    int quantity = int.Parse(QuantutyInput.Text);

                    // Check If Drug Already Exist

                    SqlCommand checkDrug = new SqlCommand(
                        "SELECT COUNT(*) FROM DRUG WHERE SERIAL_NUM = @id", c);

                    checkDrug.Parameters.AddWithValue("@id", drugId);

                    int drugExists = (int)checkDrug.ExecuteScalar();
                    //  IF DRUG EXISTS → VALIDATE DATA 
                    if (drugExists > 0)
                    {
                        SqlCommand getDrug = new SqlCommand(
                            "SELECT D_NAME, CATEGORY, SUPPLIER FROM DRUG WHERE SERIAL_NUM = @id", c);

                        getDrug.Parameters.AddWithValue("@id", DidInput.Text);

                        SqlDataReader reader = getDrug.ExecuteReader();

                        if (reader.Read())
                        {
                            string dbName = reader["D_NAME"].ToString();
                            string dbCat = reader["CATEGORY"].ToString();
                            string dbSup = reader["SUPPLIER"].ToString();

                            reader.Close();

                            //  CHECK IF USER CHANGED DATA 
                            if (DnameInput.Text != dbName ||
                                cat.Text != dbCat ||
                                DsupplierInput.Text != dbSup)
                            {
                                MessageBox.Show("This drug already exists. You cannot change its Name, Category, or Supplier.");
                                return;
                            }
                        }
                        else
                        {
                            reader.Close();
                        }
                    }

                    // INSERT DRUG IF NEW 
                    if (drugExists == 0)
                    {
                        SqlCommand insertDrug = new SqlCommand(
                            "INSERT INTO DRUG (SERIAL_NUM, D_NAME, PRICE, CATEGORY, SUPPLIER) VALUES(@id,@name,0,@cat,@sup)", c);

                        insertDrug.Parameters.AddWithValue("@id", drugId);
                        insertDrug.Parameters.AddWithValue("@name", DnameInput.Text);
                        insertDrug.Parameters.AddWithValue("@cat", cat.Text);
                        insertDrug.Parameters.AddWithValue("@sup", DsupplierInput.Text);

                        insertDrug.ExecuteNonQuery();
                    }
   

                    //  CHECK IF EXISTS IN BRANCH 
                    SqlCommand checkExist = new SqlCommand(
                        "SELECT COUNT(*) FROM EXIST_IN WHERE Serial_NUM = @id AND B_ID = @b", c);

                    checkExist.Parameters.AddWithValue("@id", drugId);
                    checkExist.Parameters.AddWithValue("@b", branchId);

                    int existsInBranch = (int)checkExist.ExecuteScalar();

                    if (existsInBranch == 0)
                    {
                        // INSERT INTO BRANCH (Exist In)
                        SqlCommand insertExist = new SqlCommand(
                            "INSERT INTO EXIST_IN (Serial_NUM, B_ID, CURRENT_QUANTITY) VALUES(@id,@b,@q)", c);

                        insertExist.Parameters.AddWithValue("@id", drugId);
                        insertExist.Parameters.AddWithValue("@b", branchId);
                        insertExist.Parameters.AddWithValue("@q", quantity);

                        insertExist.ExecuteNonQuery();
                    }
                    else
                    {
                        // If exist In branch require Click Update 

                        MessageBox.Show("Drug already exists in this branch. Please Update Insted Of Add");
                        return;
                    }
                }

                MessageBox.Show("Operation successful!");
                showingby.SelectedIndex = 0; // Branch mode
                LoadByBranch();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // ===== REQUIRE BRANCH =====
            if (BranchComboBox.SelectedValue == null)
            {
                MessageBox.Show("Branch is required!");
                return;
            }

            if (DidInput.Text == "")
            {
                MessageBox.Show("Serial Number is required!");
                return;
            }

            try
            {
                using (SqlConnection c = new SqlConnection(conn.ConnectionString))
                {
                    c.Open();

                    string drugId = DidInput.Text;
                    string branchId = BranchComboBox.SelectedValue.ToString();

                    // ===== CHECK IF EXISTS IN THIS BRANCH =====
                    SqlCommand check = new SqlCommand(
                        "SELECT COUNT(*) FROM EXIST_IN WHERE Serial_NUM=@id AND B_ID=@b", c);

                    check.Parameters.AddWithValue("@id", drugId);
                    check.Parameters.AddWithValue("@b", branchId);

                    int exists = (int)check.ExecuteScalar();

                    if (exists == 0)
                    {
                        MessageBox.Show("This drug does not exist in this branch!");
                        return;
                    }

                    // ===== UPDATE DRUG INFO ## For Only provided Data 
                    if (DnameInput.Text != "" || cat.Text != "" || DsupplierInput.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand(
                            @"UPDATE DRUG SET 
                      D_NAME = COALESCE(NULLIF(@n,''), D_NAME),
                      CATEGORY = COALESCE(NULLIF(@c,''), CATEGORY),
                      SUPPLIER = COALESCE(NULLIF(@s,''), SUPPLIER)
                      WHERE SERIAL_NUM=@id", c);

                        cmd.Parameters.AddWithValue("@id", drugId);
                        cmd.Parameters.AddWithValue("@n", DnameInput.Text);
                        cmd.Parameters.AddWithValue("@c", cat.Text);
                        cmd.Parameters.AddWithValue("@s", DsupplierInput.Text);

                        cmd.ExecuteNonQuery();
                    }

                    // Update Quantity If providded 
                    if (QuantutyInput.Text != "")
                    {
                        int quantity;
                        if (!int.TryParse(QuantutyInput.Text, out quantity))
                        {
                            MessageBox.Show("Quantity must be a number!");
                            return;
                        }

                        SqlCommand cmd2 = new SqlCommand(
                            "UPDATE EXIST_IN SET CURRENT_QUANTITY=@q WHERE Serial_NUM=@id AND B_ID=@b", c);

                        cmd2.Parameters.AddWithValue("@id", drugId);
                        cmd2.Parameters.AddWithValue("@b", branchId);
                        cmd2.Parameters.AddWithValue("@q", quantity);

                        cmd2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Updated successfully!");
                showingby.SelectedIndex = 0; // Branch mode
                LoadByBranch();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // -------------------------- DELETE -------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DidInput.Text == "" || BranchComboBox.SelectedValue == null)
            {
                MessageBox.Show("Drug ID and Branch are required!");
                return;
            }

            try
            {
                using (SqlConnection c = new SqlConnection(conn.ConnectionString))
                {
                    c.Open();

                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM EXIST_IN WHERE Serial_NUM=@id AND B_ID=@b", c);

                    cmd.Parameters.AddWithValue("@id", DidInput.Text);
                    cmd.Parameters.AddWithValue("@b", BranchComboBox.SelectedValue);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("This drug does not exist in this branch!");
                        return;
                    }
                }

                MessageBox.Show("Removed from this branch successfully!");
                showingby.SelectedIndex = 0; // Branch mode
                LoadByBranch();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // ================= SEARCH =================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();

                DataTable dt = new DataTable();

                //  ALL BRANCHES MODE 
                if (showingby.Text.Contains("All"))
                {
                    string query = @"SELECT d.SERIAL_NUM, d.D_NAME,
                ISNULL(SUM(e.CURRENT_QUANTITY),0) AS Amount,
                d.CATEGORY, d.SUPPLIER
                FROM DRUG d
                LEFT JOIN EXIST_IN e ON d.SERIAL_NUM = e.Serial_NUM
                WHERE (@id = '' OR d.SERIAL_NUM LIKE '%' + @id + '%')
                AND (@name = '' OR d.D_NAME LIKE '%' + @name + '%')
                GROUP BY d.SERIAL_NUM,d.D_NAME,d.CATEGORY,d.SUPPLIER";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", DidInput.Text);
                    cmd.Parameters.AddWithValue("@name", DnameInput.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dataGridView1.Columns["DBranch"].Visible = false;
                    FillGrid(dt, false);
                }

                //  BY BRANCH MODE 
                else if (showingby.Text.Contains("Branch"))
                {
                    string query = @"SELECT d.SERIAL_NUM, d.D_NAME,
                b.BNAME AS Branch,
                e.CURRENT_QUANTITY AS Amount,
                d.CATEGORY, d.SUPPLIER
                FROM DRUG d
                JOIN EXIST_IN e ON d.SERIAL_NUM = e.Serial_NUM
                JOIN BRANCH b ON e.B_ID = b.BID
                WHERE (@id = '' OR d.SERIAL_NUM LIKE '%' + @id + '%')
                AND (@name = '' OR d.D_NAME LIKE '%' + @name + '%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", DidInput.Text);
                    cmd.Parameters.AddWithValue("@name", DnameInput.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dataGridView1.Columns["DBranch"].Visible = true;
                    FillGrid(dt, true);
                }
            }
            finally { CloseConnection(); }
        }

        //  -------------------- CLEAR ------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            // Reload based on current mode
            showingby_SelectedIndexChanged(null, null);
        }

        private void ClearFields()
        {
            DidInput.Text = "";
            DnameInput.Text = "";
            DsupplierInput.Text = "";
            cat.Text = "";
            QuantutyInput.Text = "";
        }

        // -------------------- ROW CLICK ------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            DidInput.Text = row.Cells["SERIAL_NUM"].Value?.ToString();
            DnameInput.Text = row.Cells["DNAME"].Value?.ToString();
            QuantutyInput.Text = row.Cells["Amount"].Value?.ToString();
            cat.Text = row.Cells["Category"].Value?.ToString();
            DsupplierInput.Text = row.Cells["supplier"].Value?.ToString();

            // ===== HANDLE BRANCH MODE =====
            if (showingby.Text.Contains("Branch") && row.Cells["DBranch"].Value != null)
            {
                string branchName = row.Cells["DBranch"].Value.ToString();

                // Set ComboBox to match branch name
                BranchComboBox.Text = branchName;
            }
        }

        // --------------------- SHOW MODE ------------------
        private void showingby_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlVisibility(); // 

            if (showingby.Text.Contains("All"))
            {

                dataGridView1.Columns["DBranch"].Visible = false;
                LoadAllBranches();
            }
            else if (showingby.Text.Contains("Branch"))
            {
                dataGridView1.Columns["DBranch"].Visible = true;
                LoadByBranch(); // ← no parameter anymore
                btnSearch_Click(null, null);

            }
        }
        // -------------------- BACK ---------------------
        private void backBtn_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Close();
        }

        private void UpdateControlVisibility()
        {
            bool isAll = showingby.Text.Contains("All");

            // Hide buttons that require a branch
            btnAdd.Visible = !isAll;
            btnUpdate.Visible = !isAll;
            btnDelete.Visible = !isAll;

            // Optional: disable instead of hide
            // btnAdd.Enabled = !isAll;

            // Hide branch input section (optional)
            BranchComboBox.Visible = !isAll;

            // Keep Clear always visible
            btnClear.Visible = true;
        }
        // -------------------- EMPTY EVENTS ---------------
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void Purchase_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}