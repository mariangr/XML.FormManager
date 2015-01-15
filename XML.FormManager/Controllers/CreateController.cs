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
        public ActionResult NewContract(ContractModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    if (FormsManager.SerialiseAndSaveForm(model))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable, ioe.Message);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
            }
        }

        [HttpPost]
        public ActionResult NewInternship(InternshipModel model) {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    if (FormsManager.SerialiseAndSaveForm(model))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable, ioe.Message);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
            }
        }

        [HttpPost]
        public ActionResult NewMentor(MentorModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    if (FormsManager.SerialiseAndSaveForm(model))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable, ioe.Message);
                }
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