using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;

namespace GestVAE
{
    public class CSDebug
    {
        public static void TraceERROR(String pMsg)
        {
            Trace("ERR",pMsg);
            MessageBox.Show(pMsg);
        }
        public static void TraceWARNING(String pMsg)
        {
            Trace("WRN", pMsg);
        }
        public static void TraceINFO(String pMsg)
        {
            Trace("INFO", pMsg);
        }
        public static void Trace(String pType,String pMsg)
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now.ToLongDateString() + ":[" + pType + "]" + pMsg);
        }
        public static void TraceException(String pMsg,Exception ex)
        {
            TraceERROR(ex.Message);
            if (ex.InnerException != null)
            {
                TraceERROR(ex.InnerException.Message);
           }
        }
    }
}
