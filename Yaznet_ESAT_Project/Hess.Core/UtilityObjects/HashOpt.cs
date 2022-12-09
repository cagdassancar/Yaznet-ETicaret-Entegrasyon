using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hess.Core.UtilityObjects
{
    public class HashOpt
    {
        public HashOpt(object key)
        {
            try
            {
                var a = ((System.Reflection.Assembly)key);
                string assmbly = GetAssemblyKeyName(a);
                if (assmbly != "yaznetbilisim")
                    throw new Exception("");

            }
            catch (Exception)
            {
                throw new Exception("illegal kullanım, IP,MAC ve diğer bilgileriniz güvenlik amaçlı yönetici firmaya gönderilmiştir.");
            }
        }
        public string Encrypt(string toEncrypt)
        {
            string key = "t@2z@=+@SM<SyaznetW@4tB?";
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);


            keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string cipherString)
        {
            string key = "t@2z@=+@SM<SyaznetW@4tB?";
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public string Encrypt(string toEncrypt, string key)
        {
            //string key = "yaznetProjeler*?35Proje!";
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);


            keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string cipherString, string key)
        {
            // string key = "yaznetProjeler*?35Proje!";
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        private string GetAssemblyKeyName(System.Reflection.Assembly asmbly)
        {
            System.Reflection.Assembly asm = asmbly;
            object[] obj = asm.GetCustomAttributes(false);
            foreach (object o in obj)
            {
                if (o.GetType() == typeof(System.Reflection.AssemblyTrademarkAttribute))
                {
                    System.Reflection.AssemblyMetadataAttribute aca = (System.Reflection.AssemblyMetadataAttribute)o;
                    return aca.Value;
                }
            }
            return string.Empty;
        }

    }
}
