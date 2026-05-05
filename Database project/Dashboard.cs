using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            LoadTopDrugsChart();
        }

        private void LoadStats()
        {
            try
            {
                conn.Open();
                string totalDrugsQuery = "SELECT COUNT(*) FROM DRUG";
                SqlCommand cmd1 = new SqlCommand(totalDrugsQuery, conn);
                lblTotalDrugs.Text = cmd1.ExecuteScalar().ToString();

                string lowStockQuery = "SELECT COUNT(*) FROM EXIST_IN WHERE CURRENT_QUANTITY < 50";
                SqlCommand cmd2 = new SqlCommand(lowStockQuery, conn);
                lblLowStock.Text = cmd2.ExecuteScalar().ToString();

                string totalCustomers = "SELECT COUNT(*) FROM CUSTOMER";
                lblTotalCustomers.Text = new SqlCommand(totalCustomers, conn).ExecuteScalar().ToString();

                string dailySalesQuery = @"SELECT SUM(P.Purchased_Quantity * D.PRICE) 
                                   FROM PURCHASE P 
                                   JOIN DRUG D ON P.Serial_NUM = D.SERIAL_NUM 
                                   WHERE CAST(P.Purchase_Date AS DATE) = CAST(GETDATE() AS DATE)";

                SqlCommand cmdDaily = new SqlCommand(dailySalesQuery, conn);
                object result = cmdDaily.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    lblDailySales.Text = string.Format("{0:C}", result); 
                }
                else
                {
                    lblDailySales.Text = "$0.00";
                }



                conn.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void LoadTopDrugsChart()
        {
            try
            {
                chartTopDrugs.Series.Clear(); 
                conn.Open();

                string query = @"SELECT TOP 5 D.D_NAME, SUM(P.Purchased_Quantity) as TotalSold
                        FROM PURCHASE P
                        JOIN DRUG D ON P.Serial_NUM = D.SERIAL_NUM
                        GROUP BY D.D_NAME
                        ORDER BY TotalSold DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Units Sold");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                chartTopDrugs.Series.Add(series);

                chartTopDrugs.DataSource = dt;
                series.XValueMember = "D_NAME";
                series.YValueMembers = "TotalSold";

                chartTopDrugs.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error: " + ex.Message);
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