namespace winformtest
{
    partial class ExportImg
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
            this.export = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(242, 117);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 0;
            this.export.Text = "导出";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aspose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExportImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.export);
            this.Name = "ExportImg";
            this.Text = "ExportImg";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button button1;
    }
}