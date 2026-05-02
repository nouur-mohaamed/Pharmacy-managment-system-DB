using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Database_project
{
    public partial class Dashboard : Form
    {
        SqlConnection conn = new SqlConnection(
            "Data Source=localhost; Initial Catalog=PharmacyMgmtDB; Integrated Security=True; TrustServerCertificate=True");

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                conn.Open();

                // Total Drugs
                string totalDrugsQuery = "SELECT COUNT(*) FROM DRUG";
                SqlCommand cmd1 = new SqlCommand(totalDrugsQuery, conn);
                lblTotalDrugs.Text = cmd1.ExecuteScalar().ToString();

                // Low Stock (items where quantity < 50)
                string lowStockQuery = "SELECT COUNT(*) FROM EXIST_IN WHERE CURRENT_QUANTITY < 50";
                SqlCommand cmd2 = new SqlCommand(lowStockQuery, conn);
                lblLowStock.Text = cmd2.ExecuteScalar().ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            customer_portal portal = new customer_portal();
            portal.Show();
            this.Hide();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            purchase_form purchase = new purchase_form();
            purchase.Show();
            this.Hide();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            record_managment records = new record_managment();
            records.Show();
            this.Hide();
        }
    }
}