using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hess.Core.Exceptions
{
    public static class HessLog
    {      
        public static void Log(this Exception ex, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information)
        {
            try
            {
                UtilityObjects.FileOpt.WinFileOpt.WriteLine(type, HessLogFormat(ex, null, type));
            }
            catch (Exception _ex)
            {
                UtilityObjects.FileOpt.WriteWindowsEvents(_ex);
            }
        }

        public static void Log(this Exception ex, string title, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information)
        {
            try
            {
                UtilityObjects.FileOpt.WinFileOpt.WriteLine(type, HessLogFormat(ex, title, type));
            }
            catch (Exception _ex)
            {
                UtilityObjects.FileOpt.WriteWindowsEvents(_ex);
            }

        }

        public static void Log(string ex, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information)
        {
            try
            {
                UtilityObjects.FileOpt.WinFileOpt.WriteLine(type, HessLogFormat(ex, null, type));
            }
            catch (Exception _ex)
            {
                UtilityObjects.FileOpt.WriteWindowsEvents(_ex);
            }

        }

        public static void Log(string ex, string title, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information)
        {
            try
            {
                UtilityObjects.FileOpt.WinFileOpt.WriteLine(type, HessLogFormat(ex, title, type));
            }
            catch (Exception _ex)
            {
                UtilityObjects.FileOpt.WriteWindowsEvents(_ex);
            }
        }

        private static string HessLogFormat(this Exception ex, string title = null, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information)
        {
            string log = "";
            Exception _ex = (Exception)ex;
            log += "**********************\r\n";
            log += "Datetime : " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " " + Environment.NewLine;
            log += !String.IsNullOrEmpty(title) ? "Title : " + title + " " + Environment.NewLine : "";            
            log += $"Type : {type.ToString()} " + Environment.NewLine;            
            log += "StackTrace : " + _ex.StackTrace + " " + Environment.NewLine;
            log += "Source : " + _ex.Source + " " + Environment.NewLine;
            log += "TargetSite : " + _ex.TargetSite + " " + Environment.NewLine;
            log += "Message : " + _ex.Message + " " + Environment.NewLine;
            log += "InnerException : " + _ex.InnerException + " " + Environment.NewLine;
            log += "**********************\r\n";

            return log;
        }

        private static string HessLogFormat(string ex, string title = null, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information)
        {
            string log = "";
            log += "**********************\r\n";
            log += "Datetime : " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " " + Environment.NewLine;
            log += $"Type : {type.ToString()} " + Environment.NewLine;            
            log += !String.IsNullOrEmpty(title) ? "Title : " + title + " " + Environment.NewLine : "";
            log += "Message : " + ex + " " + Environment.NewLine;
            log += "**********************\r\n\r\n";

            return log;
        }

        
    }

    public enum HessLogEnum
    {
        GlobalError = 0x0063
    }
}
