﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;


namespace Hess.Core.UtilityObjects
{
    public class ConfigOpt:IDisposable
    {
        string Path;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public ConfigOpt(string IniPath = null)
        {
            try
            {

                if (IniPath == null)
                {
                    string dirName = AppDomain.CurrentDomain.BaseDirectory; // Starting Dir
                    FileInfo fileInfo = new FileInfo(dirName);
                    DirectoryInfo parentDir = fileInfo.Directory.Parent;
                    string configPath = parentDir.FullName + "\\Config";

                    if (!Directory.Exists(configPath))
                        Directory.CreateDirectory(configPath);


                    Path = IniPath ?? $"{configPath}config.ini";

                    if (!File.Exists(Path))
                    {
                        using (FileStream fs = File.Create(Path))
                        {
                        }
                    }
                }
                else
                {
                    if (!Directory.Exists(IniPath))
                        Directory.CreateDirectory(IniPath);

                    Path = $"{IniPath}config.ini";
                    if (!File.Exists(Path))
                    {
                        using (FileStream fs = File.Create(Path))
                        {
                        }
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                throw;


            }

        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? "", Key ?? "", "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? "", Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? "");
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? "");
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }

        public void Dispose()
        {
            Path = null;
        }
    }
}
