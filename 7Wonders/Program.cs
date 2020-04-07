using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7Wonders
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool restart = true;
            int[] startValues= new int[] {3, 0}; //Default values (three players, version 0)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (restart)
            {
                Application.Run(new Form1(startValues));
                GameMaster Master = new GameMaster(startValues);
                Application.Run(new MasterForm(Master));
                restart = Master.restart;
            }
        }
    }
}
