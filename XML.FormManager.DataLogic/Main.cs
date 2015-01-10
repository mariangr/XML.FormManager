using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using XML.FormManager.Entity;
using XML.FormManager.Models;

namespace XML.FormManager.DataLogic
{
    public class Main
    {
    }

    public static class FormsManager
    {
        public static void SerialiseAndSaveForm(object form)
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

        public static List<AllDocsModel> GetAllDocs() {
            var result = new List<AllDocsModel>();

            var allContracts = new AllDocsModel();
            allContracts.Type = XMLFormType.contract.ToString();
            allContracts.Names = XmlCustomEntity.getAllFormNames(XMLFormType.contract);
            if (allContracts.Names.Length > 0)
            {
                result.Add(allContracts);
            }

            var allInternships = new AllDocsModel();
            allInternships.Type = XMLFormType.internship.ToString();
            allInternships.Names = XmlCustomEntity.getAllFormNames(XMLFormType.internship);
            if (allInternships.Names.Length > 0)
            {
                result.Add(allInternships);
            }

            var allMentors = new AllDocsModel();
            allMentors.Type = XMLFormType.mentor.ToString();
            allMentors.Names = XmlCustomEntity.getAllFormNames(XMLFormType.mentor);
            if(allMentors.Names.Length > 0)
            {
                result.Add(allMentors);
            }

            return result;
        }
    }
}
