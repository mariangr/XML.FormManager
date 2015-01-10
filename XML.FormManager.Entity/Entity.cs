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
            var filePath = getPath(type);
            CheckCreateDirectory(filePath);

            XmlDocument forms = new XmlDocument();
            forms.Load(filePath + "/Forms.xml");
            XmlNode appendNode = forms.ChildNodes[1].FirstChild;

            XmlNodeList objectElements = newDocument.ChildNodes[0].ChildNodes;
            XmlElement document = forms.CreateElement(type.ToString());
            foreach (var item in objectElements)
            {
                document.AppendChild(document.OwnerDocument.ImportNode(item as XmlNode, true));
            }

            XmlAttribute attr = forms.CreateAttribute(type.ToString() + "Name");
            attr.Value = fileName.ToString();
            document.Attributes.Append(attr);

            appendNode.AppendChild(document);
            forms.Save(filePath + "/Forms.xml");
        }

        public static string getPath(XMLFormType type) {
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            return Path.Combine(basePath.Replace("\\bin", ".Entity"), type.ToString());
        }

        public static void CheckCreateDirectory(string path) {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
