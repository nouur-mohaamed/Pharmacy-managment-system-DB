using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //This library contains the "tools" needed to talk to SQL Server.

namespace Database_project
{
    public partial class Dashboard : Form //this is the class for the main form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost; Initial Catalog=PharmacyMgmtDB; Integrated Security=True; TrustServerCertificate=True"); // global variable
        public Dashboard() // constructor that runs the moment the window is created 
        {
            InitializeComponent();
            
        }

        private void nxtFormBtn_Click(object sender, EventArgs e)
        {
        Inventory newform1 = new Inventory();
            newform1.Show();
            this.Hide();
            purchase_form newform2 =new purchase_form();
            newform2.Show();
            customer_portal newform3 = new customer_portal();
            newform3.Show();
            record_managment newform4 = new record_managment();
            newform4.Show();


        }
    }
}
