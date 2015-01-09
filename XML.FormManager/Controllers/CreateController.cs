using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using XML.FormManager.DataLogic;
using XML.FormManager.Models;

namespace XML.FormManager.Controllers
{
    public class CreateController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewContract(ContractModel model) {
            if (ModelState.IsValid)
            {
                ContractManager.SerialiseAndSaveForm(model);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
            }
        }

        public ActionResult GetPartialView(string name) {
            return PartialView(name);
        }
	}
}