using Hess.Core.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hess.Core.Licances
{
    public class LicanceInformation
    {
        private static string LicKey { get; set; }

        public static void LicInitialize()
        {
            string licKey = "licansAnahta|-1|*|Free|Element|10|30|2022-12-01|2022-12-30";
            generateKeys();
            byte[] encrypted = Encrypt(Encoding.UTF8.GetBytes(licKey));
            byte[] decrypted = Decrypt(encrypted);


            #region Write Example

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("LicanceRoot");
            xmlDoc.AppendChild(rootNode);

            XmlNode licKeyNode = xmlDoc.CreateElement("licancekey");
            licKeyNode.InnerText = BitConverter.ToString(encrypted).Replace("-", "");
            rootNode.AppendChild(licKeyNode);

            XmlNode licKeyNode2 = xmlDoc.CreateElement("licancekey2");
            licKeyNode2.InnerText = BitConverter.ToString(decrypted).Replace("-", "");
            rootNode.AppendChild(licKeyNode2);

            XmlNode licTypeNode = xmlDoc.CreateElement("lisanstype");
            licKeyNode.InnerText = "Free Licance";
            rootNode.AppendChild(licKeyNode);

           




            xmlDoc.Save(Globals.Lic_Path+ "licance.xml");


            #endregion




            //XmlTextReader reader = new XmlTextReader(System.IO.Path.Combine(Globals.Lic_Path, "licance.xml")); //Combines the location of App_Data and the file name
            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element:
            //            break;
            //        case XmlNodeType.Text:
            //            columnNames.Add(reader.Value);
            //            break;
            //        case XmlNodeType.EndElement:
            //            break;
            //    }
            //}
        }




       
    }
}
