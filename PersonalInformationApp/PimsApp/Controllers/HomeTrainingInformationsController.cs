using Pims.Core.Model;
using Pims.Core.Model.OperationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class HomeTrainingInformationsController : Controller
    {
        // GET: HomeTrainingInformations
        public ActionResult HomeTrainingEntry(int? id)
        {
           ViewBag.GeneralInfoId = new SelectList(new List<GeneralInformation>(), "Id", "Name");
           ViewBag.OrganizationId = new SelectList(new List<Organization>(), "Id", "Name");
            return View();
        }
    }
}