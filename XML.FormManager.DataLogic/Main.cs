using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using XML.FormManager.Entity;

namespace XML.FormManager.DataLogic
{
    public class Main
    {
    }

    public static class ContractManager
    {
        public static void SerialiseAndSaveContract(object form)
        {
            var formType = form.GetType();
            XmlSerializer serializer = new XmlSerializer(formType);
            XmlDocument newDocument = new XmlDocument();
            XPathNavigator xNav = newDocument.CreateNavigator();
            using (var xs = xNav.AppendChild())
            {
                serializer.Serialize(xs, form);
            }
            if (formType.Name == "ContractModel")
            {
                newDocument.XmlServerSave(DateTime.Now.ToString().Replace(":", ".").Replace("/", "."), XMLFormType.contract);
            }
            else if (formType.Name == "InternshipModel")
            {
                newDocument.XmlServerSave(DateTime.Now.ToString().Replace(":", ".").Replace("/", "."), XMLFormType.internship);
            }
            else if (formType.Name == "MentorModel")
            {
                newDocument.XmlServerSave(DateTime.Now.ToString().Replace(":", ".").Replace("/", "."), XMLFormType.mentor);
            }
        }
    }
}
