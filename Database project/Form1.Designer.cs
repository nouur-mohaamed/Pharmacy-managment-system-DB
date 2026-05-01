namespace Database_project
{
    partial class Form1
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
            this.nxtFormBtn.Location = new System.Drawing.Point(672, 404);
            this.nxtFormBtn.Name = "nxtFormBtn";
            this.nxtFormBtn.Size = new System.Drawing.Size(116, 34);
            this.nxtFormBtn.TabIndex = 0;
            this.nxtFormBtn.Text = "Next";
            this.nxtFormBtn.UseVisualStyleBackColor = true;
            this.nxtFormBtn.Click += new System.EventHandler(this.nxtFormBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nxtFormBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nxtFormBtn;
    }
}

