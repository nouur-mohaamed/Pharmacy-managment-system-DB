namespace Database_project
{
    partial class purchase_form
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
            this.backBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Purchase = new System.Windows.Forms.Label();
            this.DrugID = new System.Windows.Forms.Label();
            this.DidInput = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.PDate = new System.Windows.Forms.DateTimePicker();
            this.QuantutyInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SSN = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SSNInput = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BranchComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalBill = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(69, 980);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(154, 55);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.Purchase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1432, 173);
            this.panel1.TabIndex = 2;
            // 
            // Purchase
            // 
            this.Purchase.AutoSize = true;
            this.Purchase.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchase.ForeColor = System.Drawing.Color.White;
            this.Purchase.Location = new System.Drawing.Point(572, 50);
            this.Purchase.Name = "Purchase";
            this.Purchase.Size = new System.Drawing.Size(341, 71);
            this.Purchase.TabIndex = 3;
            this.Purchase.Text = "🛒 Purchase";
            this.Purchase.Click += new System.EventHandler(this.label1_Click);
            // 
            // DrugID
            // 
            this.DrugID.AutoSize = true;
            this.DrugID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrugID.ForeColor = System.Drawing.Color.White;
            this.DrugID.Location = new System.Drawing.Point(22, 20);
            this.DrugID.Name = "DrugID";
            this.DrugID.Size = new System.Drawing.Size(240, 45);
            this.DrugID.TabIndex = 3;
            this.DrugID.Text = "Drug Serial N :";
            this.DrugID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DidInput
            // 
            this.DidInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DidInput.Location = new System.Drawing.Point(268, 23);
            this.DidInput.Name = "DidInput";
            this.DidInput.Size = new System.Drawing.Size(400, 44);
            this.DidInput.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DID,
            this.DName,
            this.Quantity,
            this.Price,
            this.TPrice});
            this.dataGridView1.Location = new System.Drawing.Point(61, 330);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1332, 311);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DID
            // 
            this.DID.HeaderText = "Drug ID";
            this.DID.MinimumWidth = 10;
            this.DID.Name = "DID";
            this.DID.ReadOnly = true;
            // 
            // DName
            // 
            this.DName.HeaderText = "Drug Name";
            this.DName.MinimumWidth = 10;
            this.DName.Name = "DName";
            this.DName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 10;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 10;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // TPrice
            // 
            this.TPrice.HeaderText = "Total Price";
            this.TPrice.MinimumWidth = 10;
            this.TPrice.Name = "TPrice";
            this.TPrice.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.PDate);
            this.panel4.Controls.Add(this.QuantutyInput);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.DidInput);
            this.panel4.Controls.Add(this.DrugID);
            this.panel4.Location = new System.Drawing.Point(69, 669);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(694, 250);
            this.panel4.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(138, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 45);
            this.label8.TabIndex = 16;
            this.label8.Text = "Date : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PDate
            // 
            this.PDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PDate.Location = new System.Drawing.Point(261, 172);
            this.PDate.Name = "PDate";
            this.PDate.Size = new System.Drawing.Size(402, 44);
            this.PDate.TabIndex = 15;
            // 
            // QuantutyInput
            // 
            this.QuantutyInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantutyInput.Location = new System.Drawing.Point(263, 100);
            this.QuantutyInput.Name = "QuantutyInput";
            this.QuantutyInput.Size = new System.Drawing.Size(400, 44);
            this.QuantutyInput.TabIndex = 7;
            this.QuantutyInput.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(81, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 45);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quantity : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 45);
            this.label4.TabIndex = 2;
            // 
            // SSN
            // 
            this.SSN.AutoSize = true;
            this.SSN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSN.ForeColor = System.Drawing.Color.White;
            this.SSN.Location = new System.Drawing.Point(3, 18);
            this.SSN.Name = "SSN";
            this.SSN.Size = new System.Drawing.Size(261, 45);
            this.SSN.TabIndex = 0;
            this.SSN.Text = "Customer SSN : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 45);
            this.label2.TabIndex = 2;
            // 
            // SSNInput
            // 
            this.SSNInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSNInput.Location = new System.Drawing.Point(270, 22);
            this.SSNInput.Name = "SSNInput";
            this.SSNInput.Size = new System.Drawing.Size(293, 44);
            this.SSNInput.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BranchComboBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.SSNInput);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SSN);
            this.panel2.Location = new System.Drawing.Point(62, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1336, 93);
            this.panel2.TabIndex = 3;
            // 
            // BranchComboBox
            // 
            this.BranchComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchComboBox.FormattingEnabled = true;
            this.BranchComboBox.Location = new System.Drawing.Point(984, 22);
            this.BranchComboBox.Name = "BranchComboBox";
            this.BranchComboBox.Size = new System.Drawing.Size(313, 45);
            this.BranchComboBox.TabIndex = 7;
            this.BranchComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(799, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "Branch : ";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(822, 668);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 91);
            this.button1.TabIndex = 7;
            this.button1.Text = "➕ Add";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Remove
            // 
            this.Remove.BackColor = System.Drawing.Color.OrangeRed;
            this.Remove.FlatAppearance.BorderSize = 3;
            this.Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove.ForeColor = System.Drawing.Color.Snow;
            this.Remove.Location = new System.Drawing.Point(1020, 669);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(162, 91);
            this.Remove.TabIndex = 8;
            this.Remove.Text = "🗑️ Delete";
            this.Remove.UseVisualStyleBackColor = false;
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.Gray;
            this.Clear.FlatAppearance.BorderSize = 3;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.ForeColor = System.Drawing.Color.Snow;
            this.Clear.Location = new System.Drawing.Point(1215, 668);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(162, 91);
            this.Clear.TabIndex = 9;
            this.Clear.Text = "🔄 Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(979, 825);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 10;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TotalBill
            // 
            this.TotalBill.AutoSize = true;
            this.TotalBill.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBill.ForeColor = System.Drawing.Color.White;
            this.TotalBill.Location = new System.Drawing.Point(829, 837);
            this.TotalBill.Name = "TotalBill";
            this.TotalBill.Size = new System.Drawing.Size(307, 50);
            this.TotalBill.TabIndex = 11;
            this.TotalBill.Text = "Total = 0.00 EGP";
            this.TotalBill.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TotalBill.Click += new System.EventHandler(this.label6_Click);
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.LimeGreen;
            this.Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm.ForeColor = System.Drawing.Color.Snow;
            this.Confirm.Location = new System.Drawing.Point(1119, 943);
            this.Confirm.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(241, 92);
            this.Confirm.TabIndex = 12;
            this.Confirm.Text = "Confirm Purchase";
            this.Confirm.UseVisualStyleBackColor = false;
            // 
            // purchase_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1432, 1092);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.TotalBill);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1458, 1120);
            this.Name = "purchase_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Purchase;
        private System.Windows.Forms.Label DrugID;
        private System.Windows.Forms.TextBox DidInput;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox QuantutyInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SSNInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn DID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TotalBill;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker PDate;
        private System.Windows.Forms.ComboBox BranchComboBox;
    }
}