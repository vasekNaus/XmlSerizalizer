using System;
using Apollo.EyeErp.Shared;

using System.Windows.Forms;
namespace Apollo.EyeErp.Legacy
{
   
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}