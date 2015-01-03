using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML.FormManager.Entity
{
    public enum XMLFormType {contract, mentor, service};

    public static class Entity
    {

        public static XmlDocument XmlGet(string name, XMLFormType type) {
            var loadedXml = new XmlDocument();
            loadedXml.Load(type + "/" + name);
            return loadedXml;
        }

        public static void XmlSave(XmlDocument newDocument, string fileName, XMLFormType type) {
            newDocument.Save(type + "/" + fileName);
        }
    }
}
