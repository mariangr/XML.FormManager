using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XML.FormManager.DataLogic;
using XML.FormManager.Models;

namespace XML.FormManager.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult AllDocs()
        {
            var model = FormsManager.GetAllDocs();
            return View(model);
        }

        public ActionResult Contracts()
        {
            return Content(FormsManager.GetDoc("contract"), "text/xml");
        }

        public ActionResult Internships()
        {
            return Content(FormsManager.GetDoc("internship"), "text/xml");
        }

        public ActionResult Mentors()
        {
            return Content(FormsManager.GetDoc("mentor"), "text/xml");
        }
	}

}