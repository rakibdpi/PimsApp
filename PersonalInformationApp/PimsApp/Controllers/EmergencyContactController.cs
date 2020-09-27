using Pims.Core.Model.OperationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class EmergencyContactController : Controller
    {
        // GET: EmergencyContact
        public ActionResult EmergencyContact(int? id)
        {
            //ViewBag.GeneralInformationId = new SelectList(new List<GeneralInformation>(), "Id", "EmployeId");
            return View();
        }
    }
}