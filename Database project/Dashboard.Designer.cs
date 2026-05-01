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
            this.nxtFormBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nxtFormBtn
            // 
            this.nxtFormBtn.Location = new System.Drawing.Point(756, 404);
            this.nxtFormBtn.Name = "nxtFormBtn";
            this.nxtFormBtn.Size = new System.Drawing.Size(130, 34);
            this.nxtFormBtn.TabIndex = 0;
            this.nxtFormBtn.Text = "Next";
            this.nxtFormBtn.UseVisualStyleBackColor = true;
            this.nxtFormBtn.Click += new System.EventHandler(this.nxtFormBtn_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.nxtFormBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nxtFormBtn;
    }
}

