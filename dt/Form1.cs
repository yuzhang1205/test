using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string first="2018-06-09";
            string second = "2018-06-02";
            DateTime now = Convert.ToDateTime(first);
            var week = now.DayOfWeek;
            int ss = Convert.ToInt32(week);
            DateTime future = Convert.ToDateTime(second);
            TimeSpan ts = now.Subtract(future).Duration();
            int days = ts.Days;
            DateTime satuday = now.AddDays(6 - ss);
            if (days<6)
            {
                Console.WriteLine("ok");
            }
            string path = "路径ds佳丽整形/苏李秀/英整/形_2018/070/7";
            char[] temps = Path.GetInvalidFileNameChars();
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                path.Replace(invalidChar.ToString(), "-");
            }
            string reg = "[d]";
            string regg = "[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]";
            Regex.Replace(path, reg, "-");
            path.Replace("/", "_");

            Console.WriteLine(path);
        }
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                //App.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "BeginDate";
            dt.Columns.Add(dc);
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "EndDate";
            dt.Columns.Add(dc1);
            DataRow row = dt.NewRow();
            row["BeginDate"] = "2018-06-09 00:00:00.000";
            row["EndDate"] = "2018-06-15 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-06-02 00:00:00.000";
            row["EndDate"] = "2018-06-08 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-05-26 00:00:00.000";
            row["EndDate"] = "2018-06-01 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-05-19 00:00:00.000";
            row["EndDate"] = "2018-05-25 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-05-12 00:00:00.000";
            row["EndDate"] = "2018-05-18 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-04-22 00:00:00.000";
            row["EndDate"] = "2018-04-28 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-04-21 00:00:00.000";
            row["EndDate"] = "2018-04-27 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-04-15 00:00:00.000";
            row["EndDate"] = "2018-04-21 00:00:00.000";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["BeginDate"] = "2018-04-14 00:00:00.000";
            row["EndDate"] = "2018-04-20 00:00:00.000";
            dt.Rows.Add(row);
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.TableName = "0";
                dt.DefaultView.Sort = "BeginDate desc";
                dt = dt.DefaultView.ToTable();
                List<int> rowIndex = new List<int>();
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    DateTime begin = Convert.ToDateTime(dt.Rows[i]["BeginDate"]);
                    DateTime end = Convert.ToDateTime(dt.Rows[i]["EndDate"]);
                    DateTime endNext = Convert.ToDateTime(dt.Rows[i + 1]["EndDate"]);
                    if (endNext > begin && endNext < end)
                    {
                        rowIndex.Add(i + 1);
                    }
                }
                if (rowIndex.Count > 0)
                {
                    for (int i = rowIndex.Count - 1; i >= 0; i--)
                    {
                        dt.Rows.RemoveAt(rowIndex[i]);
                    }
                }
                rowIndex.Clear();
                if (dt.Rows.Count > 8)
                {
                    for (int i = 8; i < dt.Rows.Count; i++)
                    {
                        rowIndex.Add(i);
                    }

                }
                if (rowIndex.Count > 0)
                {
                    for (int i = rowIndex.Count - 1; i >= 0; i--)
                    {
                        dt.Rows.RemoveAt(rowIndex[i]);
                    }
                }
                dataGridView1.DataSource = dt;
            }

        }
    }
}
