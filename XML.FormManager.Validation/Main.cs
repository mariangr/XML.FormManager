using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using XML.FormManager.Entity;

namespace XML.FormManager.Validation
{
    public static class XmlValidator
    {
        public static void ServerValidateAndSave(this XmlDocument doc, XMLFormType type)
        {
            var path = XmlHelpers.getPath(null, "Validation");
            XmlTextReader reader = new XmlTextReader(path + "/" + type + ".xsd");
            XmlSchema schema = XmlSchema.Read(reader, method);
            doc.Schemas.Add(schema);
            doc.Validate(method);

            doc.XmlServerSave(DateTime.Now.ToString(), type);
        }

        static void method(object sender, ValidationEventArgs e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }
}
