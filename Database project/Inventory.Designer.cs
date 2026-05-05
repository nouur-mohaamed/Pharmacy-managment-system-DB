using System;

namespace Database_project
{
    partial class Inventory
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SERIAL_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BranchComboBox = new System.Windows.Forms.ComboBox();
            this.branch = new System.Windows.Forms.Label();
            this.cat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DsupplierInput = new System.Windows.Forms.TextBox();
            this.sup = new System.Windows.Forms.Label();
            this.DnameInput = new System.Windows.Forms.TextBox();
            this.D_name = new System.Windows.Forms.Label();
            this.QuantutyInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DidInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.showingby = new System.Windows.Forms.ComboBox();
            this.ShowBy = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(70, 1114);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 30);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(154, 56);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.Purchase);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1474, 130);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Purchase
            // 
            this.Purchase.AutoSize = true;
            this.Purchase.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchase.ForeColor = System.Drawing.Color.White;
            this.Purchase.Location = new System.Drawing.Point(598, 24);
            this.Purchase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Purchase.Name = "Purchase";
            this.Purchase.Size = new System.Drawing.Size(360, 71);
            this.Purchase.TabIndex = 4;
            this.Purchase.Text = "📦 Inventory";
            this.Purchase.Click += new System.EventHandler(this.Purchase_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(620, 100);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SERIAL_NUM,
            this.Dname,
            this.DBranch,
            this.Amount,
            this.Category,
            this.supplier});
            this.dataGridView1.Location = new System.Drawing.Point(28, 246);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1428, 392);
            this.dataGridView1.TabIndex = 3;
            // 
            // SERIAL_NUM
            // 
            this.SERIAL_NUM.HeaderText = "Drug ID ";
            this.SERIAL_NUM.MinimumWidth = 10;
            this.SERIAL_NUM.Name = "SERIAL_NUM";
            this.SERIAL_NUM.ReadOnly = true;
            // 
            // Dname
            // 
            this.Dname.HeaderText = "Drug Name ";
            this.Dname.MinimumWidth = 10;
            this.Dname.Name = "Dname";
            this.Dname.ReadOnly = true;
            // 
            // DBranch
            // 
            this.DBranch.HeaderText = "Branch";
            this.DBranch.MinimumWidth = 10;
            this.DBranch.Name = "DBranch";
            this.DBranch.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Available Amount";
            this.Amount.MinimumWidth = 10;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 10;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // supplier
            // 
            this.supplier.HeaderText = "Supplier";
            this.supplier.MinimumWidth = 10;
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 588);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.BranchComboBox);
            this.panel4.Controls.Add(this.branch);
            this.panel4.Controls.Add(this.cat);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.DsupplierInput);
            this.panel4.Controls.Add(this.sup);
            this.panel4.Controls.Add(this.DnameInput);
            this.panel4.Controls.Add(this.D_name);
            this.panel4.Controls.Add(this.QuantutyInput);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.DidInput);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(70, 656);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1358, 302);
            this.panel4.TabIndex = 7;
            // 
            // BranchComboBox
            // 
            this.BranchComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchComboBox.FormattingEnabled = true;
            this.BranchComboBox.Location = new System.Drawing.Point(936, 200);
            this.BranchComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.BranchComboBox.Name = "BranchComboBox";
            this.BranchComboBox.Size = new System.Drawing.Size(384, 45);
            this.BranchComboBox.TabIndex = 15;
            // 
            // branch
            // 
            this.branch.AutoSize = true;
            this.branch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branch.ForeColor = System.Drawing.Color.White;
            this.branch.Location = new System.Drawing.Point(766, 210);
            this.branch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(151, 45);
            this.branch.TabIndex = 14;
            this.branch.Text = "Branch : ";
            // 
            // cat
            // 
            this.cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cat.Location = new System.Drawing.Point(268, 200);
            this.cat.Margin = new System.Windows.Forms.Padding(4);
            this.cat.Name = "cat";
            this.cat.Size = new System.Drawing.Size(400, 44);
            this.cat.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(78, 196);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 45);
            this.label7.TabIndex = 12;
            this.label7.Text = "Category : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // DsupplierInput
            // 
            this.DsupplierInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DsupplierInput.Location = new System.Drawing.Point(920, 122);
            this.DsupplierInput.Margin = new System.Windows.Forms.Padding(4);
            this.DsupplierInput.Name = "DsupplierInput";
            this.DsupplierInput.Size = new System.Drawing.Size(400, 44);
            this.DsupplierInput.TabIndex = 11;
            // 
            // sup
            // 
            this.sup.AutoSize = true;
            this.sup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sup.ForeColor = System.Drawing.Color.White;
            this.sup.Location = new System.Drawing.Point(752, 122);
            this.sup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sup.Name = "sup";
            this.sup.Size = new System.Drawing.Size(163, 45);
            this.sup.TabIndex = 10;
            this.sup.Text = "Supplier :";
            this.sup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DnameInput
            // 
            this.DnameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DnameInput.Location = new System.Drawing.Point(920, 24);
            this.DnameInput.Margin = new System.Windows.Forms.Padding(4);
            this.DnameInput.Name = "DnameInput";
            this.DnameInput.Size = new System.Drawing.Size(400, 44);
            this.DnameInput.TabIndex = 9;
            this.DnameInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // D_name
            // 
            this.D_name.AutoSize = true;
            this.D_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D_name.ForeColor = System.Drawing.Color.White;
            this.D_name.Location = new System.Drawing.Point(704, 20);
            this.D_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.D_name.Name = "D_name";
            this.D_name.Size = new System.Drawing.Size(211, 45);
            this.D_name.TabIndex = 8;
            this.D_name.Text = "Drug Name :";
            this.D_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.D_name.Click += new System.EventHandler(this.label3_Click);
            // 
            // QuantutyInput
            // 
            this.QuantutyInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantutyInput.Location = new System.Drawing.Point(268, 108);
            this.QuantutyInput.Margin = new System.Windows.Forms.Padding(4);
            this.QuantutyInput.Name = "QuantutyInput";
            this.QuantutyInput.Size = new System.Drawing.Size(400, 44);
            this.QuantutyInput.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(92, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 45);
            this.label5.TabIndex = 6;
            this.label5.Text = "Amount : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 45);
            this.label4.TabIndex = 2;
            // 
            // DidInput
            // 
            this.DidInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DidInput.Location = new System.Drawing.Point(268, 20);
            this.DidInput.Margin = new System.Windows.Forms.Padding(4);
            this.DidInput.Name = "DidInput";
            this.DidInput.Size = new System.Drawing.Size(400, 44);
            this.DidInput.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "Drug Serial N :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DimGray;
            this.btnClear.FlatAppearance.BorderSize = 3;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1224, 984);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(184, 80);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Salmon;
            this.btnSearch.FlatAppearance.BorderSize = 3;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1263, 148);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(193, 80);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "🔍 Search\r\n";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDelete.FlatAppearance.BorderSize = 3;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(532, 984);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(184, 80);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Orange;
            this.btnUpdate.FlatAppearance.BorderSize = 3;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(300, 984);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(184, 80);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.FlatAppearance.BorderSize = 3;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(76, 984);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(184, 80);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // showingby
            // 
            this.showingby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showingby.FormattingEnabled = true;
            this.showingby.Items.AddRange(new object[] {
            "Branch ",
            "All Branches"});
            this.showingby.Location = new System.Drawing.Point(264, 168);
            this.showingby.Margin = new System.Windows.Forms.Padding(4);
            this.showingby.Name = "showingby";
            this.showingby.Size = new System.Drawing.Size(384, 45);
            this.showingby.TabIndex = 30;
            this.showingby.SelectedIndexChanged += new System.EventHandler(this.showingby_SelectedIndexChanged);
            // 
            // ShowBy
            // 
            this.ShowBy.AutoSize = true;
            this.ShowBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowBy.ForeColor = System.Drawing.Color.White;
            this.ShowBy.Location = new System.Drawing.Point(94, 164);
            this.ShowBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShowBy.Name = "ShowBy";
            this.ShowBy.Size = new System.Drawing.Size(177, 45);
            this.ShowBy.TabIndex = 29;
            this.ShowBy.Text = "Show By : ";
            this.ShowBy.Click += new System.EventHandler(this.label6_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1474, 1192);
            this.Controls.Add(this.showingby);
            this.Controls.Add(this.ShowBy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label Purchase;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox QuantutyInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DidInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DnameInput;
        private System.Windows.Forms.Label D_name;
        private System.Windows.Forms.TextBox DsupplierInput;
        private System.Windows.Forms.Label sup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox cat;
        private System.Windows.Forms.ComboBox BranchComboBox;
        private System.Windows.Forms.Label branch;
        private System.Windows.Forms.ComboBox showingby;
        private System.Windows.Forms.Label ShowBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIAL_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dname;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
    }
}