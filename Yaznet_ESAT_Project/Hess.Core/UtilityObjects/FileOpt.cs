using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hess.Core.UtilityObjects
{
    public class FileOpt
    {
        private static string ErrorFilePath { get { return Globals.Log_Path + DateTime.Now.ToString("dd_MM_yyyy") + "_errors.txt"; } }
        private static string SuccessFilePath { get { return Globals.Log_Path + DateTime.Now.ToString("dd_MM_yyyy") + "_info.txt"; } }

        public static class WinFileOpt
        {
            public static void WriteLine(System.Diagnostics.EventLogEntryType et, string log)
            {
                try
                {
                    switch (et)
                    {
                        case System.Diagnostics.EventLogEntryType.Error | System.Diagnostics.EventLogEntryType.Warning | System.Diagnostics.EventLogEntryType.FailureAudit:
                            if (!System.IO.File.Exists(ErrorFilePath))
                                using (System.IO.StreamWriter sw = System.IO.File.CreateText(ErrorFilePath))
                                    sw.WriteLine(log);
                            else
                                using (System.IO.StreamWriter sw = System.IO.File.AppendText(ErrorFilePath))
                                    sw.WriteLine(log);
                            break;
                        case System.Diagnostics.EventLogEntryType.Information | System.Diagnostics.EventLogEntryType.SuccessAudit:
                            if (!System.IO.File.Exists(SuccessFilePath))
                                using (System.IO.StreamWriter sw = System.IO.File.CreateText(SuccessFilePath))
                                    sw.WriteLine(log);
                            else
                                using (System.IO.StreamWriter sw = System.IO.File.AppendText(SuccessFilePath))
                                    sw.WriteLine(log);
                            break;
                        default:
                            if (!System.IO.File.Exists(ErrorFilePath))
                                using (System.IO.StreamWriter sw = System.IO.File.CreateText(ErrorFilePath))
                                    sw.WriteLine(log);
                            else
                                using (System.IO.StreamWriter sw = System.IO.File.AppendText(ErrorFilePath))
                                    sw.WriteLine(log);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    FileOpt.WriteWindowsEvents(ex);
                }

            }
        }

        public static class WebFileOpt
        {
            //TODO:Durumu değerlendirilecek
            public static void WriteLine(System.Diagnostics.EventLogEntryType et, string log)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    FileOpt.WriteWindowsEvents(ex);
                }
            }
        }

        public static void WriteWindowsEvents(Exception ex)
        {
            try
            {
                if (!System.Diagnostics.EventLog.SourceExists(System.Reflection.Assembly.GetExecutingAssembly().FullName))
                {
                    System.Diagnostics.EventLog.CreateEventSource(System.Reflection.Assembly.GetExecutingAssembly().FullName, System.Reflection.Assembly.GetExecutingAssembly().FullName);
                }

                string errorMessage = "Source : " + (!String.IsNullOrEmpty(ex.Source) ? ex.Source : "null") + " \r\n" +
                    "Location : " + (!String.IsNullOrEmpty(ex.StackTrace) ? ex.StackTrace : "null") + " \r\n" +
                    "Error Message : " + (!String.IsNullOrEmpty(ex.Message) ? ex.Message : "null") + " \r\n" +
                    "Inner Message : " + (ex.InnerException != null ? ex.InnerException.ToString() : "null");



                System.Diagnostics.EventLog.WriteEntry(System.Reflection.Assembly.GetExecutingAssembly().FullName, errorMessage, System.Diagnostics.EventLogEntryType.Error);
            }
            catch (Exception)
            {

            }
        }




    }
}
