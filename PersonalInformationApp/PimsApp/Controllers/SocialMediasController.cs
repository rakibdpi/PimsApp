using Pims.Core.Model.OperationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class SocialMediasController : Controller
    {
        // GET: SocialMedias
        public ActionResult SocialMediaEntry(int? id)
        {
            ViewBag.GeneralInfoId = new SelectList(new List<GeneralInformation>(), "Id", "Name");
            return View();
        }
    }
}