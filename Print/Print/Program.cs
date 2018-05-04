using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #if !DEBUG
            if (CheckUpdateAtProcessStart.CheckNewVersion.CheckAndUpdate() != CheckUpdateAtProcessStart.ProcessState.ForceUpdate)
            #endif
                Application.Run(new MainForm());
        }
    }
}
