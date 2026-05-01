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
    public partial class Form1 : Form //this is the class for the main form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost; Initial Catalog=PharmacyMgmtDB; Integrated Security=True; TrustServerCertificate=True");
        public Form1() // constructor that runs the moment the window is created 
        {
            InitializeComponent();
           
        }

        private void nxtFormBtn_Click(object sender, EventArgs e)
        {
        Form2 newform = new Form2();
            newform.Show();
            this.Hide();
        }
    }
}
