using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UntilExcel
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Application.Run(new Excels());
            //Excels excels = new Excels();
            //excels.Show();
        }
    }
}
