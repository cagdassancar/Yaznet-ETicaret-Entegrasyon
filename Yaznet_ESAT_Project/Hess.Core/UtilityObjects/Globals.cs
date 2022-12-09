using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hess.Core.UtilityObjects
{
    public class Globals
    {
        //public static string Log_Path { get { return AppDomain.CurrentDomain.BaseDirectory + "Logs\\"; } }

#if DEBUG
        public static string Log_Path
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";

            }
        }
        public static string Config_Path
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\Config\\";
            }
        }
        public static string Lic_Path
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\Licance\\";
            }
        }
#else
     public static string Log_Path
        {
            get
            {
                string dirName = AppDomain.CurrentDomain.BaseDirectory; // Starting Dir
                FileInfo fileInfo = new FileInfo(dirName);
                DirectoryInfo parentDir = fileInfo.Directory.Parent;
                return parentDir.FullName + "\\Logs\\";
            }
        }
        public static string Config_Path
        {
            get
            {
                string dirName = AppDomain.CurrentDomain.BaseDirectory; // Starting Dir
                FileInfo fileInfo = new FileInfo(dirName);
                DirectoryInfo parentDir = fileInfo.Directory.Parent;
                return parentDir.FullName + "\\Config\\";
            }
        }
        public static string Lic_Path
        {
            get
            {
                string dirName = AppDomain.CurrentDomain.BaseDirectory; // Starting Dir
                FileInfo fileInfo = new FileInfo(dirName);
                DirectoryInfo parentDir = fileInfo.Directory.Parent;
                return parentDir.FullName + "\\Licance\\";
            }
        }
#endif



        public static string StoreDBConnStr { get; set; }
        public static string IdentityDBConnStr { get; set; }
        public static string SelectedStoreDBName { get; set; } = "HessBaseStoreDB";


        public static void Initialize()
        {
            #region Files Created

            //Log Path
            if (!System.IO.Directory.Exists(Log_Path))
                System.IO.Directory.CreateDirectory(Log_Path);

            //Config Path
            if (!System.IO.Directory.Exists(Config_Path))
                System.IO.Directory.CreateDirectory(Config_Path);

            //Licances Path
            if (!System.IO.Directory.Exists(Lic_Path))
                System.IO.Directory.CreateDirectory(Lic_Path);



            #endregion


            #region Config Base Information

            using (ConfigOpt conf = new ConfigOpt(Globals.Config_Path))
            {
                #region Identity Server Information
                string Identity_Server, Identity_User, Identity_Password;

                if (conf.KeyExists("IdxSrv", "DataConfiguration"))
                    Identity_Server = conf.Read("IdxSrv", "DataConfiguration");
                else
                {
                    conf.Write("IdxSrv", "IdxSrv", "DataConfiguration");
                    Identity_Server = conf.Read("IdxSrv", "DataConfiguration");
                }

                if (conf.KeyExists("IdxUsr", "DataConfiguration"))
                    Identity_User = conf.Read("IdxUsr", "DataConfiguration");
                else
                {
                    conf.Write("IdxUsr", "IdxUsr", "DataConfiguration");
                    Identity_User = conf.Read("localUsr", "DataConfiguration");
                }

                if (conf.KeyExists("IdxPsw", "DataConfiguration"))
                    Identity_Password = conf.Read("IdxPsw", "DataConfiguration");
                else
                {
                    conf.Write("IdxPsw", "IdxPsw", "DataConfiguration");
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
                    conf.Write("ShpSrv", "ShpSrv", "DataConfiguration");
                    Shop_Server = conf.Read("ShpSrv", "DataConfiguration");
                }

                if (conf.KeyExists("ShpUsr", "DataConfiguration"))
                    Shop_User = conf.Read("ShpUsr", "DataConfiguration");
                else
                {
                    conf.Write("ShpUsr", "ShpUsr", "DataConfiguration");
                    Shop_User = conf.Read("ShpUsr", "DataConfiguration");
                }

                if (conf.KeyExists("ShpPsw", "DataConfiguration"))
                    Shop_Password = conf.Read("ShpPsw", "DataConfiguration");
                else
                {
                    conf.Write("ShpPsw", "ShpPsw", "DataConfiguration");
                    Shop_Password = conf.Read("ShpPsw", "DataConfiguration");
                }

                Core.UtilityObjects.Globals.StoreDBConnStr = $"Server={Shop_Server};Database=" + "{0}" + $";User Id={Shop_User};Password={Shop_Password};";


                #endregion               
            }

            #endregion



            #region Licance Initialize

            Licances.LicanceInformation.LicInitialize();

            #endregion
        }
    }
}
