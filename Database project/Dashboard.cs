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

        private void iNVENTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void cUSTOMERPORTALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer_portal portal = new customer_portal();
            portal.Show();
            this.Hide();
        }

        private void pURCHASEFORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchase_form purchase = new purchase_form();
            purchase.Show();
            this.Hide();
        }

        private void rECORDSMANAGMENTFORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            record_managment records = new record_managment();
            records.Show();
            this.Hide();
        }
    }
}
