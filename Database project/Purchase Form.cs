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
            button1.Click += new EventHandler(button1_Click);
            Remove.Click += new EventHandler(Remove_Click);
            Confirm.Click += new EventHandler(Confirm_Click);
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (SSNInput.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Customer SSN and Branch ID are required!");
                return;
            }

            if (DidInput.Text == "")
            {
                MessageBox.Show("Please enter a Drug ID!");
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

                // Check customer exists
                string checkCustomer = "SELECT COUNT(*) FROM CUSTOMER WHERE CSSN = @ssn";
                SqlCommand cmdCust = new SqlCommand(checkCustomer, conn);
                cmdCust.Parameters.AddWithValue("@ssn", SSNInput.Text);
                if ((int)cmdCust.ExecuteScalar() == 0)
                {
                    MessageBox.Show("Customer SSN not found!");
                    return;
                }

                // Check branch exists
                string checkBranch = "SELECT COUNT(*) FROM BRANCH WHERE BID = @bid";
                SqlCommand cmdBranch = new SqlCommand(checkBranch, conn);
                cmdBranch.Parameters.AddWithValue("@bid", textBox2.Text);
                if ((int)cmdBranch.ExecuteScalar() == 0)
                {
                    MessageBox.Show("Branch ID not found!");
                    return;
                }

                // Get drug info and available stock at this branch
                string drugQuery = @"SELECT d.SERIAL_NUM, d.D_NAME, d.PRICE, e.CURRENT_QUANTITY
                                     FROM DRUG d
                                     INNER JOIN EXIST_IN e ON d.SERIAL_NUM = e.Serial_NUM
                                     WHERE d.SERIAL_NUM = @did AND e.B_ID = @bid";
                SqlCommand cmdDrug = new SqlCommand(drugQuery, conn);
                cmdDrug.Parameters.AddWithValue("@did", DidInput.Text);
                cmdDrug.Parameters.AddWithValue("@bid", textBox2.Text);

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

                // If drug already in grid, update quantity instead of adding duplicate
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

                // Add new row to grid
                decimal totalPrice = price * quantity;
                dataGridView1.Rows.Add(
                    DidInput.Text,
                    drugName,
                    quantity,
                    price.ToString("F2"),
                    totalPrice.ToString("F2")
                );

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

        private void Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to remove!");
                return;
            }

            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            RecalculateTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SSNInput.Text = "";
            textBox2.Text = "";
            DidInput.Text = "";
            QuantutyInput.Text = "";
            totalBill = 0;
            TotalBill.Text = "Total = 0.00 EGP";
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No items in the purchase list!");
                return;
            }

            if (SSNInput.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Customer SSN and Branch ID are required to confirm!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Confirm purchase of " + dataGridView1.Rows.Count + " item(s) totalling " + totalBill.ToString("F2") + " EGP?",
                "Confirm Purchase", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            try
            {
                OpenConnection();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Get next purchase number
                    SqlCommand getMax = new SqlCommand(
                        "SELECT ISNULL(MAX(PURCHASE_NUM), 5000) + 1 FROM PURCHASE", conn, transaction);
                    int purchaseNum = Convert.ToInt32(getMax.ExecuteScalar());

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string drugId = row.Cells["DID"].Value.ToString();
                        int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                        string today = DateTime.Today.ToString("yyyy-MM-dd");

                        // Check if purchase record already exists for this customer, drug, branch
                        string checkQuery = "SELECT COUNT(*) FROM PURCHASE WHERE C_SSN=@ssn AND Serial_NUM=@did AND B_ID=@bid";
                        SqlCommand cmdCheck = new SqlCommand(checkQuery, conn, transaction);
                        cmdCheck.Parameters.AddWithValue("@ssn", SSNInput.Text);
                        cmdCheck.Parameters.AddWithValue("@did", drugId);
                        cmdCheck.Parameters.AddWithValue("@bid", textBox2.Text);

                        if ((int)cmdCheck.ExecuteScalar() > 0)
                        {
                            // Update existing purchase record
                            string updateQuery = @"UPDATE PURCHASE 
                                                   SET Purchased_Quantity = Purchased_Quantity + @qty,
                                                       Purchase_Date = @date
                                                   WHERE C_SSN=@ssn AND Serial_NUM=@did AND B_ID=@bid";
                            SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn, transaction);
                            cmdUpdate.Parameters.AddWithValue("@qty", qty);
                            cmdUpdate.Parameters.AddWithValue("@date", today);
                            cmdUpdate.Parameters.AddWithValue("@ssn", SSNInput.Text);
                            cmdUpdate.Parameters.AddWithValue("@did", drugId);
                            cmdUpdate.Parameters.AddWithValue("@bid", textBox2.Text);
                            cmdUpdate.ExecuteNonQuery();
                        }
                        else
                        {
                            // Insert new purchase record
                            string insertQuery = @"INSERT INTO PURCHASE 
                                                   (PURCHASE_NUM, C_SSN, Serial_NUM, B_ID, Purchase_Date, Purchased_Quantity)
                                                   VALUES (@pnum, @ssn, @did, @bid, @date, @qty)";
                            SqlCommand cmdInsert = new SqlCommand(insertQuery, conn, transaction);
                            cmdInsert.Parameters.AddWithValue("@pnum", purchaseNum++);
                            cmdInsert.Parameters.AddWithValue("@ssn", SSNInput.Text);
                            cmdInsert.Parameters.AddWithValue("@did", drugId);
                            cmdInsert.Parameters.AddWithValue("@bid", textBox2.Text);
                            cmdInsert.Parameters.AddWithValue("@date", today);
                            cmdInsert.Parameters.AddWithValue("@qty", qty);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // Deduct purchased quantity from branch stock
                        string stockQuery = @"UPDATE EXIST_IN 
                                              SET CURRENT_QUANTITY = CURRENT_QUANTITY - @qty
                                              WHERE Serial_NUM=@did AND B_ID=@bid";
                        SqlCommand cmdStock = new SqlCommand(stockQuery, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@qty", qty);
                        cmdStock.Parameters.AddWithValue("@did", drugId);
                        cmdStock.Parameters.AddWithValue("@bid", textBox2.Text);
                        cmdStock.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Purchase confirmed successfully!\nTotal: " + totalBill.ToString("F2") + " EGP");
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

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

        // Designer-required stubs
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_2(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}