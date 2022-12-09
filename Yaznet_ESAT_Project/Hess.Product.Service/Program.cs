using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hess.Core.Exceptions;
using Hess.Core.UtilityObjects;
using Hess.DataLayer.Context;

namespace Hess.Product.Service
{
    class Program
    {

        /// <summary>
        /// Main thread exception handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

        }

        /// <summary>
        /// Application domain exception handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public static void AppDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {


        }

        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions, System.Security.SecurityCritical]
        static void Main(string[] args)
        {
            try
            {
                InitializeObjects();
                System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
                System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);

             

                //System.ServiceProcess.ServiceBase[] ServicesToRun;
                //ServicesToRun = new System.ServiceProcess.ServiceBase[]
                //{
                //   //new CommunicationService()
                //};

                //System.ServiceProcess.ServiceBase.Run(ServicesToRun);


            }
            catch (Exception ex)
            {
                ex.Log($"Product Service::Main ({(decimal)HessLogEnum.GlobalError})");
            }
            Console.Read();

        }

        private static void InitializeObjects()
        {
            #region Initialize Globals
            Globals.Initialize();
            #endregion

           
        }
    }
}
