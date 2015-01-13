using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace XML.FormManager.Entity
{
    public enum XMLFormType {contract, mentor, internship};



    public static class XmlCustomEntity
    {
        public static string[] getAllFormNames(XMLFormType type)
        {
            List<string> result = new List<string>();
            var path = XmlHelpers.getPath(type, "Entity");
            XmlDocument forms = new XmlDocument();
            forms.Load(path + "/Forms.xml");
            var names = forms.ChildNodes[1].FirstChild.ChildNodes;
            foreach (XmlElement item in names)
            {
                result.Add(item.Attributes[0].Value.ToString());
            }

            return result.ToArray();
        }

        public static XmlDocument XmlGet(string name, XMLFormType type) {
            var loadedXml = new XmlDocument();
            loadedXml.Load(type + "/" + name);
            return loadedXml;
        }

        public static bool XmlServerSave(this XmlDocument newDocument, string fileName, XMLFormType type) {
            var filePath = XmlHelpers.getPath(type, "Entity");
            XmlHelpers.CheckCreateDirectory(filePath);

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

            try
            {
                XmlHelpers.Validate(forms, type);
            }
            catch (InvalidOperationException ioe)
            {
                return false;
            }

            forms.Save(filePath + "/Forms.xml");
            return true;
        }

        
    }

    public static class XmlHelpers
    {
        public static string getPath(XMLFormType type, string level)
        {
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            return Path.Combine(basePath.Replace("\\bin", "." + level), type.ToString());
        }

        public static void CheckCreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void Validate(XmlDocument doc, XMLFormType type)
        {
            var path = XmlHelpers.getPath(type, "Entity");
            XmlTextReader reader = new XmlTextReader(path + "/Form.xsd");
            XmlSchema schema = XmlSchema.Read(reader, method);
            doc.Schemas.Add(schema);
            doc.Validate(method);
        }

        static void method(object sender, ValidationEventArgs e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }
}
