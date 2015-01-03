using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public void NewContract(ContractModel model) {
            var result = ModelState.IsValid;
        }

        public ActionResult GetPartialView(string name) {
            return PartialView(name);
        }
	}
}