using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace XML.FormManager.Entity
{
    public enum XMLFormType { contract, internship, mentor };



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

        public static XmlDocument XmlGet(XMLFormType type) 
        {
            var filePath = XmlHelpers.getPath(type, "Entity");
            var loadedXml = new XmlDocument();
            loadedXml.Load(filePath + "/Forms.xml");
            return loadedXml;
        }

        public static bool XmlServerSave(this XmlDocument newDocument, string fileName, XMLFormType type) {
            var filePath = XmlHelpers.getPath(type, "Entity");
            XmlHelpers.CheckCreateDirectory(filePath);

            XmlDocument forms = new XmlDocument();
            forms.Load(filePath + "/Forms.xml");
            XmlNode appendNode = forms.ChildNodes[1].FirstChild;

            XmlNodeList objectElements = newDocument.ChildNodes[0].ChildNodes;
            XmlElement document = forms.CreateElement(type.ToString(), "http://xml.form.manager.bg");
            foreach (var item in objectElements)
            {
                XmlNode node = document.OwnerDocument.ImportNode(item as XmlNode, true);
                document.AppendChild(node);
            }
            foreach (XmlNode node in document.ChildNodes)
            {
            }
            appendNode.AppendChild(document);
            

            XmlAttribute attr = forms.CreateAttribute(type.ToString() + "Name");
            attr.Value = fileName.ToString();
            document.Attributes.Append(attr);

            XmlHelpers.Validate(forms, type);
            
            forms.Save(filePath + "/Forms.xml");
            return true;
        }

        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var reader = xDocument.CreateReader())
            {
                xmlDocument.Load(reader);
            }

            var xDeclaration = xDocument.Declaration;
            if (xDeclaration != null)
            {
                var xmlDeclaration = xmlDocument.CreateXmlDeclaration(
                    xDeclaration.Version,
                    xDeclaration.Encoding,
                    xDeclaration.Standalone);

                xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.FirstChild);
            }

            return xmlDocument;
        } 

        
    }

    public static class XmlHelpers
    {
        public static string getPath(XMLFormType type, string level)
        {
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            return Path.Combine(basePath, type.ToString());
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
