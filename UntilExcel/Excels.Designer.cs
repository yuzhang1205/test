namespace UntilExcel
{
    partial class Excels
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
            this.choseFile = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // choseFile
            // 
            this.choseFile.Location = new System.Drawing.Point(265, 136);
            this.choseFile.Name = "choseFile";
            this.choseFile.Size = new System.Drawing.Size(97, 23);
            this.choseFile.TabIndex = 0;
            this.choseFile.Text = "选择文件:";
            this.choseFile.UseVisualStyleBackColor = true;
            this.choseFile.Click += new System.EventHandler(this.choseFile_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(379, 137);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(218, 25);
            this.FileName.TabIndex = 1;
            // 
            // Excels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 418);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.choseFile);
            this.Name = "Excels";
            this.Text = "Excels";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button choseFile;
        private System.Windows.Forms.TextBox FileName;
    }
}