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
	}
}