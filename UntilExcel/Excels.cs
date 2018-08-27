using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UntilExcel
{
    public partial class Excels : Form
    {
        public Excels()
        {
            InitializeComponent();
        }

        private void choseFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pfd = new FolderBrowserDialog();
            if (pfd.ShowDialog()==DialogResult.OK)
            {
                if (pfd.SelectedPath=="")
                {
                    MessageBox.Show("请选择文件夹");
                    return;
                }
                ExcelHelper.Export(pfd.SelectedPath);
            }
        }
    }
}
