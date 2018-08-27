using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using System.Diagnostics;
using System.Threading;

namespace UntilExcel
{
    public static class ExcelHelper
    {
        public static void Export(string fileName)
        {
            string path = @"D:\FCOMWCF\Final\File\WorkOrder.xls";
            //string fileName = @"D:\FCOMWCF\Final\WorkOrder_test.xls";
            HSSFWorkbook wk = null;
            //FileStream fs = File.Open(path, FileAccess.ReadWrite, FileMode.Open, FileShare.ReadWrite);
            using (FileStream fs = File.Open(path,FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite))
            {
                wk = new HSSFWorkbook(fs);
                fs.Close();
            }
            ISheet sheet = wk.GetSheet("sheet1");
            int startIndex = 5;
            int insertCounts = 2;
            //sheet.ShiftRows(startIndex, sheet.LastRowNum, 2, true, false);
            if (insertCounts < 1)
            {
                sheet.GetRow(5).GetCell(1).SetCellValue("北京");
                sheet.GetRow(5).GetCell(2).SetCellValue(DateTime.Now.ToShortDateString());
                sheet.GetRow(5).GetCell(3).SetCellValue("12,23,45");
                sheet.GetRow(5).GetCell(4).SetCellValue("X");
                sheet.GetRow(5).GetCell(5).SetCellValue(DateTime.Now.ToShortDateString());
            }
            else{
                IRow sourceRow = sheet.GetRow(startIndex-1);
                int sourceCellCount = sourceRow.Cells.Count;
                //批量移动
                sheet.ShiftRows(startIndex, sheet.LastRowNum, insertCounts, true, false);
                int startMergeCell = -1;//记录每行合并单元格起始位置
                for (int i = startIndex; i < startIndex + insertCounts ; i++)
                {
                    IRow targetRow = null;
                    ICell sourceCell = null;
                    ICell targetCell = null;
                    targetRow = sheet.CreateRow(i);
                    targetRow.Height = sourceRow.Height;//复制行高
                    int s = sourceRow.FirstCellNum;
                    for (int m = sourceRow.FirstCellNum; m < sourceRow.LastCellNum; m++)
                    {
                        sourceCell = sourceRow.GetCell(m);
                        if (sourceCell == null)
                            continue;
                        targetCell = targetRow.CreateCell(m);
                        targetCell.CellStyle = sourceCell.CellStyle;
                        targetCell.SetCellType(sourceCell.CellType);
                        //复制模板行的单元格合并格式
                        if (sourceCell.IsMergedCell)
                        {
                            if (startMergeCell<=0)
                            {
                                startMergeCell = m;
                            }else if(startMergeCell > 0 && sourceCellCount == m + 1)
                            {
                                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(i, i, startMergeCell, m));
                            }
                        }
                        else
                        {
                            if (startMergeCell>=0)
                            {
                                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(i, i, startMergeCell, m - 1));
                            }
                        }
                    }
                }
                IRow firstTargetRow = sheet.GetRow(startIndex);
                ICell firstSourceCell = null;
                ICell firstTargetCell = null;
                for (int i = sheet.GetRow(startIndex).FirstCellNum; i < sheet.GetRow(startIndex).LastCellNum; i++)
                {
                    firstSourceCell = sheet.GetRow(startIndex).GetCell(i);
                    if (firstSourceCell == null)
                    {
                        continue;
                    }
                    firstTargetCell = firstTargetRow.CreateCell(i);
                    firstTargetCell.CellStyle = firstSourceCell.CellStyle;
                    firstTargetCell.SetCellType(firstSourceCell.CellType);
                    firstTargetCell.SetCellValue("sdsdasd");
                }
                //sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(4, 7 + 2, 0, 0));
                #region
                //第一行
                var style = sheet.GetRow(1).GetCell(5).CellStyle;
                sheet.GetRow(1).GetCell(5).SetCellValue("我的excel读取写入");
                sheet.GetRow(1).GetCell(5).CellStyle = style;

                style = sheet.GetRow(1).GetCell(2).CellStyle;
                sheet.GetRow(1).GetCell(2).SetCellValue(string.Join(",", "6/23 - 6/29"));
                sheet.GetRow(1).GetCell(5).CellStyle = style;

                style = sheet.GetRow(2).GetCell(2).CellStyle;
                sheet.GetRow(2).GetCell(2).SetCellValue("zy");
                sheet.GetRow(2).GetCell(2).CellStyle = style;

                DateTime dt;
                var createOn = "";
                if (DateTime.TryParse("2018-07-08", out dt))
                {
                    createOn = dt.ToString();
                }
                style = sheet.GetRow(2).GetCell(5).CellStyle;
                sheet.GetRow(2).GetCell(5).SetCellValue(createOn);
                sheet.GetRow(2).GetCell(5).CellStyle = style;

                sheet.GetRow(3).GetCell(2).SetCellValue("zy");
                sheet.GetRow(3).GetCell(2).CellStyle = style;
            }
            

            #endregion
            using (MemoryStream ms=new MemoryStream())
            {
                byte[] bytes;
                wk.Write(ms);
                ms.Flush();
                bytes = ms.ToArray();
                ms.Write(bytes, 0, bytes.Length);
                File.WriteAllBytes(fileName+ "\\WorkOrder_test.xls", bytes);
            }
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(fucs);
                thread.Name = "test" + i;
                
            }
        }
        public static void fucs()
        {
            int i = 0;
            while (i<100)
            {
                i++;
            }
        }
        public static void ReduceMemory()
        {
            Process A = Process.GetCurrentProcess();
            A.MaxWorkingSet = Process.GetCurrentProcess().MaxWorkingSet;
            A.Dispose();
        }
        
    }
}
