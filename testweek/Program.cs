using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace testweek
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt= GetSundayDate();
            //TimeSpan ts = new TimeSpan((2018-05-6) - (2018-05-5));
            //int result = (int)ts.TotalDays / 7;
            Regex reg =new Regex( "^(.)");
            string ss = "5     (2018-11-17  ~  2018-11-23)";
            ss = ss.Split('(')[1].Replace(")","");
            string s = ss.Split('~')[0];
            string d = ss.Split('~')[1];
            
            int result = TotalWeeks(new DateTime(2018, 05, 6), new DateTime(2018, 05, 19),DayOfWeek.Saturday);
            string Name = "2963#1883";
            string id = Regex.Match(Name, @"#\d+").Value.Substring(1);

            List<string> list = new List<string>();
            list.Add("yy");
            list.Add("zy");
            string[] temp = { "sda", "dsfdf", "zy" };
            list.AddRange(temp);

            List<test> mytest = new List<test>();
            List<Result> results = new List<Result>();
            for (int i = 0; i < 2; i++)
            {
                Result r = new Result();
                r.name = "yy" + i;
                r.resCode = i;
                results.Add(r);
            }
            List<string> a = new List<string>() { "zq", "zw", "ze" };
            List<string> b = new List<string>() { "yy", "yu", "yi" };
            a.AddRange(b);
            a.Add("ff");

            Console.WriteLine(result);
            Console.ReadKey();
        }
        //public static String GetSunday(DateTime AStart, DateTime AEnd, DayOfWeek AWeek)
        //{
        //    DateTime dt = DateTime.Now;
        //    var ds = dt.DayOfWeek;
        //    if (ds!=DayOfWeek.Sunday)
        //    {
        //        DateTime dtweek=dt.AddDays(int(ds)-)
        //    }
        //    return "";
        //}
        /// <summary> 
        /// 计算某日结束日期（礼拜日的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns> 
        public static List< string> GetSundayDate()
        {
            List<string> list = new List<string>();
            DateTime dt = DateTime.Now;
            int i = dt.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            DateTime oneWeek = dt.Add(ts);
            list.Add(oneWeek.ToShortDateString());
            DateTime twoWeek = oneWeek.AddDays(-7);
            list.Add(twoWeek.ToShortDateString());
            DateTime threeWeek = twoWeek.AddDays(-7);
            list.Add(threeWeek.ToShortDateString());
            DateTime fourWeek = threeWeek.AddDays(-7);
            list.Add(fourWeek.ToShortDateString());
            return list;
        }
        public static int TotalWeeks(DateTime AStart, DateTime AEnd, DayOfWeek AWeek)
        { 
             TimeSpan vTimeSpan = new TimeSpan(AEnd.Ticks - AStart.Ticks); 
             int Result = (int)vTimeSpan.TotalDays / 7; 
             for   (int i   =   0;   i   <=   vTimeSpan.TotalDays   %   7;   i++) 
                     if   (AStart.AddDays(i).DayOfWeek   ==   AWeek) 
                             return   Result   +   1; 
            return   Result; 
         }

}
    class test
    {
        int id { get; set; }
        List<Result> result { get; set; }
    }

    class Result
    {
        public int resCode { get; set; }
        public string name { get; set; }
    }
}
