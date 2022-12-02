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


        }

        private static void InitializeObjects()
        {            
            #region Initialize Globals
            Globals.Initialize();
            #endregion

            using (ConfigOpt conf = new ConfigOpt(Globals.Config_Path))
            {
                #region Identity Server Information
                string Identity_Server, Identity_User, Identity_Password;

                if (conf.KeyExists("IdxSrv", "DataConfiguration"))
                    Identity_Server = conf.Read("IdxSrv", "DataConfiguration");
                else
                {
                    conf.Write("IdxSrv", "localSvr", "DataConfiguration");
                    Identity_Server = conf.Read("IdxSrv", "DataConfiguration");
                }

                if (conf.KeyExists("IdxUsr", "DataConfiguration"))
                    Identity_User = conf.Read("IdxUsr", "DataConfiguration");
                else
                {
                    conf.Write("IdxUsr", "localUsr", "DataConfiguration");
                    Identity_User = conf.Read("localUsr", "DataConfiguration");
                }

                if (conf.KeyExists("IdxPsw", "DataConfiguration"))
                    Identity_Password = conf.Read("IdxPsw", "DataConfiguration");
                else
                {
                    conf.Write("IdxPsw", "localPsw", "DataConfiguration");
                    Identity_Password = conf.Read("IdxPsw", "DataConfiguration");
                }

                Core.UtilityObjects.Globals.IdentityDBConnStr = $"Server={Identity_Server};Database=HessIdentityDB;User Id={Identity_User};Password={Identity_Password};";
                #endregion

                #region Shop Server Information
                string Shop_Server, Shop_User, Shop_Password;

                if (conf.KeyExists("ShpSrv", "DataConfiguration"))
                    Shop_Server = conf.Read("ShpSrv", "DataConfiguration");
                else
                {
                    conf.Write("ShpSrv", "localSvr", "DataConfiguration");
                    Shop_Server = conf.Read("ShpSrv", "DataConfiguration");
                }

                if (conf.KeyExists("ShpUsr", "DataConfiguration"))
                    Shop_User = conf.Read("ShpUsr", "DataConfiguration");
                else
                {
                    conf.Write("ShpUsr", "localUsr", "DataConfiguration");
                    Shop_User = conf.Read("ShpUsr", "DataConfiguration");
                }

                if (conf.KeyExists("ShpPsw", "DataConfiguration"))
                    Shop_Password = conf.Read("ShpPsw", "DataConfiguration");
                else
                {
                    conf.Write("ShpPsw", "localPsw", "DataConfiguration");
                    Shop_Password = conf.Read("ShpPsw", "DataConfiguration");
                }

                Core.UtilityObjects.Globals.ShopDBConnStr = $"Server={Shop_Server};Database=" + "{0}" + $";User Id={Shop_User};Password={Shop_Password};";


                #endregion               
            }
        }
    }
}
