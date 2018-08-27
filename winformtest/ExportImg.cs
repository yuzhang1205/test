using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using Spire.Xls;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.IO;

namespace winformtest
{
    public partial class ExportImg : Form
    {
        public ExportImg()
        {
            InitializeComponent();
        }

        private void export_Click(object sender, EventArgs e)
        {
            var path = @"D:\test\WorkOrder.xls";
            var outPath = @"D:\\test\\aspose";
            //HSSFWorkbook wk = null;
            //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            //{
            //    wk = new HSSFWorkbook(fs);
            //    fs.Close();
            //}
            //ISheet sheet = wk.GetSheet("Sheet1");
            
            using (Spire.Xls.Workbook workbook = new Spire.Xls.Workbook())
            {
                workbook.LoadFromFile(path);
                Spire.Xls.Worksheet sheet = workbook.Worksheets[0];
                const string main_Dir = @"c:/WenTest";
                if (!Directory.Exists(main_Dir))
                {
                    //Directory.CreateDirectory(main_Dir);
                }
                else
                {
                    ExportImg.DeleteFolder(main_Dir);
                    Directory.CreateDirectory(main_Dir);
                }
                //string mypath = Environment.CurrentDirectory+"\\test";
                if (File.Exists(outPath))
                {

                    File.Delete(outPath);
                    Directory.CreateDirectory(outPath);

                }
                else { Directory.CreateDirectory(outPath); }
                //sheet.SetRowHeightPixels()
                //sheet.SaveToImage(outPath+"\\msample.png");
                sheet.SaveToImage(sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn).Save(outPath+"\\test.jpg");
               
                //IWorkbook workbook = new IWorkbook();
            }

        }
        /// <summary>  
        /// 删除文件夹下所有文件  
        /// </summary>  
        /// <param name="dir"></param>  
        public static void DeleteFolder(string dir)
        {
            //如果存在这个文件夹删除之   
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d);//直接删除其中的文件   
                    else DeleteFolder(d);//递归删除子文件夹    
                }
                Directory.Delete(dir);
                //删除已空文件夹   
                MessageBox.Show(dir + "文件夹删除成功");
            }
            else //如果文件夹不存在则提示   
                MessageBox.Show(dir + "该文件夹不存在");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var path = @"D:\test\WorkOrder.xls";
            try
            {
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(path);
                Aspose.Cells.Worksheet sheet = workbook.Worksheets[0];
                sheet.PageSetup.LeftMargin = 0;
                sheet.PageSetup.RightMargin = 0;
                sheet.PageSetup.BottomMargin = 0;
                sheet.PageSetup.TopMargin = 0;
                ImageOrPrintOptions imgopthion = new ImageOrPrintOptions();
                imgopthion.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                imgopthion.OnePagePerSheet = true;
                imgopthion.PrintingPage = PrintingPageType.IgnoreBlank;
                SheetRender sr = new SheetRender(sheet, imgopthion);
                sr.ToImage(0, "D:\\test\\sample.jpg");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
