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

    public static class ContractManager {
        public static void SaveContract(object contract) {
            XmlSerializer serializer = new XmlSerializer(contract.GetType());
            XmlDocument newContract = new XmlDocument();
            XPathNavigator xNav = newContract.CreateNavigator();
            using (var xs = xNav.AppendChild())
            {
                serializer.Serialize(xs, contract);
            }
            XmlCustomEntity.XmlSave(newContract, DateTime.Now.ToString().Replace(":","").Replace("/",""), XMLFormType.contract);
        }
    }
}
