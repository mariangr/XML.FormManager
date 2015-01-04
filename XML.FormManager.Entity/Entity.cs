using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML.FormManager.Entity
{
    public enum XMLFormType {contract, mentor, internship};

    public static class XmlCustomEntity
    {

        public static XmlDocument XmlGet(string name, XMLFormType type) {
            var loadedXml = new XmlDocument();
            loadedXml.Load(type + "/" + name);
            return loadedXml;
        }

        public static void XmlServerSave(this XmlDocument newDocument, string fileName, XMLFormType type) {
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            var filePath = Path.Combine(basePath.Replace("\\bin", ".Entity"), type.ToString());
            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            newDocument.Save(filePath + "/" + fileName + ".xml");
        }
    }
}
