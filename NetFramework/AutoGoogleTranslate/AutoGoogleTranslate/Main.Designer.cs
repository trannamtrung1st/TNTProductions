namespace AutoGoogleTranslate
{
    partial class Main
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
            this.btnActive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(122, 12);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(88, 35);
            this.btnActive.TabIndex = 0;
            this.btnActive.Text = "Stop";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 56);
            this.Controls.Add(this.btnActive);
            this.Name = "Main";
            this.Text = "Auto Google Translate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActive;
    }
}

