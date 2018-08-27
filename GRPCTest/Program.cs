using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRPCDemo;
using Google.Protobuf;
using System.IO;

namespace GRPCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] bytes = { 1, 2, 3 ,4};
            string tempPath = @"D:\FCOMWCF\Final\File\WorkOrder_tt.xls";
            var ss = new HelloRequest();
            ss.Name = "zy";
            ss.Sex = 0;
            
            //bytes = ss.Byte.ToArray();
            //List<Dictionary<>> t = new List<T>();
            //ss.Byte = Google.Protobuf.ByteString.FromStream(ms);
            //ss.Byte=ByteString.CopyFrom(bytes);

            using (FileStream fs=File.Open(tempPath,FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
            }
            string test = "hello bytes";
            byte[] myBytes = System.Text.Encoding.Default.GetBytes(test);
            string dd = System.Text.Encoding.Default.GetString(myBytes);
            //ss.Byte.WriteTo(ms);
            
            //File.Copy(tempPath, @"D:\FCOMWCF\Final\File\WorkOrder_copy.xls");
            Console.WriteLine(dd);
            Console.ReadKey();
    
        }
    }
}
