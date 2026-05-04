using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_project
{
    public partial class purchase_form : Form
    {
        SqlConnection conn = new SqlConnection(
            "Data Source=localhost; Initial Catalog=PharmacyMgmtDB; Integrated Security=True; TrustServerCertificate=True");

        private decimal totalBill = 0;

        public purchase_form()
        {
            InitializeComponent();

            LoadBranches();

            button1.Click += new EventHandler(button1_Click);
            Remove.Click += new EventHandler(Remove_Click);
            Confirm.Click += new EventHandler(Confirm_Click);
        }

        // --------------- Handle connection
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

        // ------ Load Data For branch Combo Box 

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


        //  ------------------- ADD TO CART 
        private void button1_Click(object sender, EventArgs e)
        {
            if (SSNInput.Text == "" || BranchComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Customer SSN and Branch ID are required!");
                return;
            }

            string branchId = BranchComboBox.SelectedValue.ToString();

            if (DidInput.Text == "")
            {
                MessageBox.Show("Please enter a Drug Serial Number !");
                return;
            }

            if (!int.TryParse(QuantutyInput.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity!");
                return;
            }

            try
            {
                OpenConnection();

                //  CHECK CUSTOMER 
                string checkCustomer = "SELECT COUNT(*) FROM CUSTOMER WHERE CSSN = @ssn";
                SqlCommand cmdCust = new SqlCommand(checkCustomer, conn);
                cmdCust.Parameters.AddWithValue("@ssn", SSNInput.Text);

                if ((int)cmdCust.ExecuteScalar() == 0)
                {
                    // Forward To Customer Portal 
                    DialogResult result = MessageBox.Show(
                        "Customer not found!\nDo you want to add the customer through Customer Portal?",
                        "Customer Not Found",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        customer_portal form = new customer_portal();
                        form.Show();

                        // optional: close current form
                        // this.Close();
                    }

                    return;
                }

                //  Get Drug Data
                string drugQuery = @"SELECT d.SERIAL_NUM, d.D_NAME, d.PRICE, e.CURRENT_QUANTITY
                                     FROM DRUG d
                                     INNER JOIN EXIST_IN e ON d.SERIAL_NUM = e.Serial_NUM
                                     WHERE d.SERIAL_NUM = @did AND e.B_ID = @bid";

                SqlCommand cmdDrug = new SqlCommand(drugQuery, conn);
                cmdDrug.Parameters.AddWithValue("@did", DidInput.Text);
                cmdDrug.Parameters.AddWithValue("@bid", branchId);

                SqlDataAdapter da = new SqlDataAdapter(cmdDrug);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Drug not found at this branch!");
                    return;
                }

                string drugName = dt.Rows[0]["D_NAME"].ToString();
                decimal price = Convert.ToDecimal(dt.Rows[0]["PRICE"]);
                int available = Convert.ToInt32(dt.Rows[0]["CURRENT_QUANTITY"]);

                if (quantity > available)
                {
                    MessageBox.Show("Not enough stock! Available: " + available);
                    return;
                }

                // ----- CHECK IF ALREADY IN CART 
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["DID"].Value?.ToString() == DidInput.Text)
                    {
                        int existing = Convert.ToInt32(row.Cells["Quantity"].Value);
                        int newQty = existing + quantity;

                        if (newQty > available)
                        {
                            MessageBox.Show("Not enough stock! Available: " + available + ", Already in cart: " + existing);
                            return;
                        }

                        row.Cells["Quantity"].Value = newQty;
                        row.Cells["TPrice"].Value = (price * newQty).ToString("F2");

                        RecalculateTotal();
                        DidInput.Text = "";
                        QuantutyInput.Text = "";
                        return;
                    }
                }

                //  ADD NEW ROW 
                decimal totalPrice = price * quantity;

                dataGridView1.Rows.Add(
                    DidInput.Text,
                    drugName,
                    quantity,
                    price.ToString("F2"),
                    totalPrice.ToString("F2")
                );
                BranchComboBox.Enabled = false;
                RecalculateTotal();
                DidInput.Text = "";
                QuantutyInput.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // --------------------REMOVE ITEM 
        private void Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to remove!");
                return;
            }

            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            RecalculateTotal();
            if (dataGridView1.Rows.Count <= 1) // only empty row left
            {
                BranchComboBox.Enabled = true;
            }
        }

        // ------------------ CLEAR 
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SSNInput.Text = "";
            DidInput.Text = "";
            QuantutyInput.Text = "";
            BranchComboBox.SelectedIndex = 0;

            totalBill = 0;
            TotalBill.Text = "Total = 0.00 EGP";
            BranchComboBox.Enabled = true;
        }

        // ------------ CONFIRM PURCHASE 
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("No items in the purchase list!");
                return;
            }

            if (SSNInput.Text == "" || BranchComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Customer SSN and Branch ID are required to confirm!");
                return;
            }

            string branchId = BranchComboBox.SelectedValue.ToString();

            DialogResult result = MessageBox.Show(
                "Confirm purchase of " + dataGridView1.Rows.Count +
                " item(s) totalling " + totalBill.ToString("F2") + " EGP?",
                "Confirm Purchase", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            try
            {
                OpenConnection();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand getMax = new SqlCommand(
                        "SELECT ISNULL(MAX(PURCHASE_NUM), 5000) + 1 FROM PURCHASE",
                        conn, transaction);

                    int purchaseNum = Convert.ToInt32(getMax.ExecuteScalar());

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string drugId = row.Cells["DID"].Value.ToString();
                        int qty = Convert.ToInt32(row.Cells["Quantity"].Value);

                        //  CHECK EXISTING PURCHASE 
                        string checkQuery = @"SELECT COUNT(*) FROM PURCHASE 
                                              WHERE C_SSN=@ssn AND Serial_NUM=@did AND B_ID=@bid";

                        SqlCommand cmdCheck = new SqlCommand(checkQuery, conn, transaction);
                        cmdCheck.Parameters.AddWithValue("@ssn", SSNInput.Text);
                        cmdCheck.Parameters.AddWithValue("@did", drugId);
                        cmdCheck.Parameters.AddWithValue("@bid", branchId);

                        if ((int)cmdCheck.ExecuteScalar() > 0)
                        {
                            //  UPDATE 
                            string updateQuery = @"UPDATE PURCHASE 
                                SET Purchased_Quantity = Purchased_Quantity + @qty,
                                    Purchase_Date = @date
                                WHERE C_SSN=@ssn AND Serial_NUM=@did AND B_ID=@bid";

                            SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn, transaction);
                            cmdUpdate.Parameters.AddWithValue("@qty", qty);
                            cmdUpdate.Parameters.AddWithValue("@date", PDate.Value);
                            cmdUpdate.Parameters.AddWithValue("@ssn", SSNInput.Text);
                            cmdUpdate.Parameters.AddWithValue("@did", drugId);
                            cmdUpdate.Parameters.AddWithValue("@bid", branchId);
                            cmdUpdate.ExecuteNonQuery();
                        }
                        else
                        {
                            //  INSERT =====
                            string insertQuery = @"INSERT INTO PURCHASE 
                                (PURCHASE_NUM, C_SSN, Serial_NUM, B_ID, Purchase_Date, Purchased_Quantity)
                                VALUES (@pnum, @ssn, @did, @bid, @date, @qty)";

                            SqlCommand cmdInsert = new SqlCommand(insertQuery, conn, transaction);
                            cmdInsert.Parameters.AddWithValue("@pnum", purchaseNum++);
                            cmdInsert.Parameters.AddWithValue("@ssn", SSNInput.Text);
                            cmdInsert.Parameters.AddWithValue("@did", drugId);
                            cmdInsert.Parameters.AddWithValue("@bid", branchId);
                            cmdInsert.Parameters.AddWithValue("@date", PDate.Value);
                            cmdInsert.Parameters.AddWithValue("@qty", qty);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // ===== UPDATE STOCK =====
                        string stockQuery = @"UPDATE EXIST_IN 
                            SET CURRENT_QUANTITY = CURRENT_QUANTITY - @qty
                            WHERE Serial_NUM=@did AND B_ID=@bid";

                        SqlCommand cmdStock = new SqlCommand(stockQuery, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@qty", qty);
                        cmdStock.Parameters.AddWithValue("@did", drugId);
                        cmdStock.Parameters.AddWithValue("@bid", branchId);
                        cmdStock.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Purchase confirmed successfully!\nTotal: " +
                                    totalBill.ToString("F2") + " EGP");

                    button3_Click(null, null);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //  TOTAL Recalc
        private void RecalculateTotal()
        {
            totalBill = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                decimal.TryParse(row.Cells["TPrice"].Value?.ToString(), out decimal rowTotal);
                totalBill += rowTotal;
            }

            TotalBill.Text = "Total = " + totalBill.ToString("F2") + " EGP";
        }

        // Back Button
        private void backBtn_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_2(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}