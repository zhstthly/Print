using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PrinterSystemConfig
    {
        /// <summary>
        /// 获取已安装的打印机
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPrinterList()
        {
            List<string> printerList = new List<string>();
            PrintDocument prtdoc = new PrintDocument();
            printerList.Add("");
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                printerList.Add(printerName);
            }
            return printerList;
        }
    }
}
