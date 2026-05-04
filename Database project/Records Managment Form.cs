using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_project
{
    public partial class record_managment : Form
    {
        SqlConnection conn = new SqlConnection(
            "Data Source=localhost; Initial Catalog=PharmacyMgmtDB; Integrated Security=True; TrustServerCertificate=True");

        public record_managment()
        {
            InitializeComponent();
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

        private void record_managment_Load(object sender, EventArgs e)
        {
            cmbTable.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                OpenConnection();
                string query = "";

                if (cmbTable.SelectedItem.ToString() == "Purchase Records")
                {
                    query = @"SELECT p.PURCHASE_NUM AS [Purchase#], 
                             c.First_Name + ' ' + c.Last_Name AS [Customer],
                             ph.C_PHONE AS [Phone],
                             d.D_NAME AS [Drug],
                             p.Purchased_Quantity AS [Quantity],
                             d.PRICE * p.Purchased_Quantity AS [Total Price],
                             p.Purchase_Date AS [Date],
                             b.BNAME AS [Branch],
                             p.C_SSN AS [Customer SSN],
                             p.Serial_NUM AS [Drug Serial]
                             FROM PURCHASE p
                             JOIN CUSTOMER c ON p.C_SSN = c.CSSN
                             LEFT JOIN PHONE ph ON c.CSSN = ph.C_SSN
                             JOIN DRUG d ON p.Serial_NUM = d.SERIAL_NUM
                             JOIN BRANCH b ON p.B_ID = b.BID
                             WHERE p.Purchase_Date BETWEEN @from AND @to
                             AND (c.First_Name LIKE @search 
                             OR c.Last_Name LIKE @search 
                             OR d.D_NAME LIKE @search
                             OR ph.C_PHONE LIKE @search
                             OR CAST(p.PURCHASE_NUM AS VARCHAR) LIKE @search)
                             ORDER BY p.Purchase_Date DESC";
                }
                else
                {
                    query = @"SELECT d.D_NAME AS [Drug],
                             b.BNAME AS [Branch],
                             w.Location AS [Warehouse],
                             s.SUPPLIED_QUANTITY AS [Quantity],
                             s.Serial_NUM AS [Drug Serial],
                             s.B_ID AS [Branch ID],
                             s.W_ID AS [Warehouse ID]
                             FROM SUPPLY s
                             JOIN DRUG d ON s.Serial_NUM = d.SERIAL_NUM
                             JOIN BRANCH b ON s.B_ID = b.BID
                             JOIN WAREHOUSE w ON s.W_ID = w.W_ID
                             WHERE (d.D_NAME LIKE @search
                             OR b.BNAME LIKE @search
                             OR w.Location LIKE @search)
                             ORDER BY d.D_NAME";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                if (cmbTable.SelectedItem.ToString() == "Purchase Records")
                {
                    cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRecords.DataSource = dt;

                // Show record count
                lblCount.Text = $"Total Records: {dt.Rows.Count}";
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    OpenConnection();

                    if (cmbTable.SelectedItem.ToString() == "Purchase Records")
                    {
                        string purchaseNum = dgvRecords.SelectedRows[0].Cells["Purchase#"].Value.ToString();
                        string cSSN = dgvRecords.SelectedRows[0].Cells["Customer SSN"].Value.ToString();
                        string serialNum = dgvRecords.SelectedRows[0].Cells["Drug Serial"].Value.ToString();
                        string bID = dgvRecords.SelectedRows[0].Cells["Branch"].Value.ToString();

                        // Get branch ID from branch name
                        string getBID = "SELECT BID FROM BRANCH WHERE BNAME = @bname";
                        SqlCommand getCmd = new SqlCommand(getBID, conn);
                        getCmd.Parameters.AddWithValue("@bname", bID);
                        string branchID = getCmd.ExecuteScalar().ToString();

                        string query = "DELETE FROM PURCHASE WHERE C_SSN=@ssn AND Serial_NUM=@serial AND B_ID=@bid";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ssn", cSSN);
                        cmd.Parameters.AddWithValue("@serial", serialNum);
                        cmd.Parameters.AddWithValue("@bid", branchID);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string serialNum = dgvRecords.SelectedRows[0].Cells["Drug Serial"].Value.ToString();
                        string branchID = dgvRecords.SelectedRows[0].Cells["Branch ID"].Value.ToString();
                        string warehouseID = dgvRecords.SelectedRows[0].Cells["Warehouse ID"].Value.ToString();

                        string query = "DELETE FROM SUPPLY WHERE Serial_NUM=@serial AND B_ID=@bid AND W_ID=@wid";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@serial", serialNum);
                        cmd.Parameters.AddWithValue("@bid", branchID);
                        cmd.Parameters.AddWithValue("@wid", warehouseID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record deleted successfully!");
                    LoadRecords();
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
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to view!");
                return;
            }

            string details = "Record Details:\n\n";
            foreach (DataGridViewCell cell in dgvRecords.SelectedRows[0].Cells)
            {
                if (cell.Value != null)
                    details += $"{dgvRecords.Columns[cell.ColumnIndex].HeaderText}: {cell.Value}\n";
            }
            MessageBox.Show(details, "Record Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show/hide date filters based on selected table
            bool isPurchase = cmbTable.SelectedItem.ToString() == "Purchase Records";
            dtpFrom.Visible = isPurchase;
            dtpTo.Visible = isPurchase;
            lblFrom.Visible = isPurchase;
            lblTo.Visible = isPurchase;
            LoadRecords();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }
    }
}