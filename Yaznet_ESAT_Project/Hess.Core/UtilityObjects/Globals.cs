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



        public static string ShopDBConnStr { get; set; }
        public static string IdentityDBConnStr { get; set; }
        

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

            #region Licance Initialize

            Licances.LicanceInformation.LicInitialize();

            #endregion
        }
    }
}
