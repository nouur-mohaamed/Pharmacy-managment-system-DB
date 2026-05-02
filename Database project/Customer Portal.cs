using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_project
{
    public partial class customer_portal : Form
    {
        SqlConnection conn = new SqlConnection(
            "Data Source=localhost; Initial Catalog=PharmacyMgmtDB; Integrated Security=True; TrustServerCertificate=True");

        public customer_portal()
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

        private void customer_portal_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                OpenConnection();
                string query = "SELECT CSSN, First_Name, Last_Name, E_MAIL, C_CITY, C_STREET, C_BUILDINGNUM FROM CUSTOMER";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSSN.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("SSN, First Name and Last Name are required!");
                return;
            }
            try
            {
                OpenConnection();
                string query = "INSERT INTO CUSTOMER (CSSN, First_Name, Last_Name, E_MAIL, C_CITY, C_STREET, C_BUILDINGNUM) VALUES (@ssn, @fn, @ln, @email, @city, @street, @bnum)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ssn", txtSSN.Text);
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@street", txtStreet.Text);
                cmd.Parameters.AddWithValue("@bnum", txtBuilding.Text == "" ? (object)DBNull.Value : int.Parse(txtBuilding.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer added successfully!");
                LoadCustomers();
                ClearFields();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSSN.Text == "")
            {
                MessageBox.Show("Please enter SSN to update!");
                return;
            }
            try
            {
                OpenConnection();
                string query = "UPDATE CUSTOMER SET First_Name=@fn, Last_Name=@ln, E_MAIL=@email, C_CITY=@city, C_STREET=@street, C_BUILDINGNUM=@bnum WHERE CSSN=@ssn";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ssn", txtSSN.Text);
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@street", txtStreet.Text);
                cmd.Parameters.AddWithValue("@bnum", txtBuilding.Text == "" ? (object)DBNull.Value : int.Parse(txtBuilding.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer updated successfully!");
                LoadCustomers();
                ClearFields();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSSN.Text == "")
            {
                MessageBox.Show("Please enter SSN to delete!");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    OpenConnection();

                    // First delete phone numbers (child records)
                    string deletePhone = "DELETE FROM PHONE WHERE C_SSN=@ssn";
                    SqlCommand cmd1 = new SqlCommand(deletePhone, conn);
                    cmd1.Parameters.AddWithValue("@ssn", txtSSN.Text);
                    cmd1.ExecuteNonQuery();

                    // Then delete from PURCHASE table (also references customer)
                    string deletePurchase = "DELETE FROM PURCHASE WHERE C_SSN=@ssn";
                    SqlCommand cmd2 = new SqlCommand(deletePurchase, conn);
                    cmd2.Parameters.AddWithValue("@ssn", txtSSN.Text);
                    cmd2.ExecuteNonQuery();

                    // Now delete the customer
                    string deleteCustomer = "DELETE FROM CUSTOMER WHERE CSSN=@ssn";
                    SqlCommand cmd3 = new SqlCommand(deleteCustomer, conn);
                    cmd3.Parameters.AddWithValue("@ssn", txtSSN.Text);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Customer deleted successfully!");
                    LoadCustomers();
                    ClearFields();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                string query = "SELECT CSSN, First_Name, Last_Name, E_MAIL, C_CITY, C_STREET, C_BUILDINGNUM FROM CUSTOMER WHERE CSSN LIKE @search OR First_Name LIKE @search OR Last_Name LIKE @search";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + txtSSN.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadCustomers();
        }

        private void ClearFields()
        {
            txtSSN.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            txtStreet.Text = "";
            txtBuilding.Text = "";
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtSSN.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtLastName.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value?.ToString();
                txtCity.Text = row.Cells[4].Value?.ToString();
                txtStreet.Text = row.Cells[5].Value?.ToString();
                txtBuilding.Text = row.Cells[6].Value?.ToString();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}