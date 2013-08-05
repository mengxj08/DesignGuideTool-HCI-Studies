using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignToolWPF
{
    class Log
    {
        private string rootDir = "";
        
        private static Log log;

        private Log()
        {
            rootDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        public static Log getLogInstance()
        {
            if (log == null)
            {
                log = new Log();
            }
            return log;
        }

        // Usage of Log class: Log.getLogInstance.writeLog("xxx").
        public void writeLog(string str)
        {
            using (StreamWriter sw = File.AppendText(Path.Combine(rootDir, "Logs.txt")))
            {
                sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy h:mm tt"));
                sw.WriteLine(str);
                sw.WriteLine();
            }
        }
    }
}
