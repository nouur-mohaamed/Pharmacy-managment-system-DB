namespace Database_project
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iNVENTORYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUSTOMERPORTALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pURCHASEFORMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rECORDSMANAGMENTFORMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNVENTORYToolStripMenuItem,
            this.cUSTOMERPORTALToolStripMenuItem,
            this.pURCHASEFORMToolStripMenuItem,
            this.rECORDSMANAGMENTFORMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iNVENTORYToolStripMenuItem
            // 
            this.iNVENTORYToolStripMenuItem.Name = "iNVENTORYToolStripMenuItem";
            this.iNVENTORYToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.iNVENTORYToolStripMenuItem.Text = "INVENTORY";
            this.iNVENTORYToolStripMenuItem.Click += new System.EventHandler(this.iNVENTORYToolStripMenuItem_Click);
            // 
            // cUSTOMERPORTALToolStripMenuItem
            // 
            this.cUSTOMERPORTALToolStripMenuItem.Name = "cUSTOMERPORTALToolStripMenuItem";
            this.cUSTOMERPORTALToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.cUSTOMERPORTALToolStripMenuItem.Text = "CUSTOMER PORTAL";
            this.cUSTOMERPORTALToolStripMenuItem.Click += new System.EventHandler(this.cUSTOMERPORTALToolStripMenuItem_Click);
            // 
            // pURCHASEFORMToolStripMenuItem
            // 
            this.pURCHASEFORMToolStripMenuItem.Name = "pURCHASEFORMToolStripMenuItem";
            this.pURCHASEFORMToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.pURCHASEFORMToolStripMenuItem.Text = "PURCHASE FORM";
            this.pURCHASEFORMToolStripMenuItem.Click += new System.EventHandler(this.pURCHASEFORMToolStripMenuItem_Click);
            // 
            // rECORDSMANAGMENTFORMToolStripMenuItem
            // 
            this.rECORDSMANAGMENTFORMToolStripMenuItem.Name = "rECORDSMANAGMENTFORMToolStripMenuItem";
            this.rECORDSMANAGMENTFORMToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.rECORDSMANAGMENTFORMToolStripMenuItem.Text = "RECORDS MANAGMENT FORM";
            this.rECORDSMANAGMENTFORMToolStripMenuItem.Click += new System.EventHandler(this.rECORDSMANAGMENTFORMToolStripMenuItem_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iNVENTORYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERPORTALToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pURCHASEFORMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rECORDSMANAGMENTFORMToolStripMenuItem;
    }
}

