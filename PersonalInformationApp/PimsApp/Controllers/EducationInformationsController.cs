using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class EducationInformationsController : Controller
    {
        // GET: EducationInformations
        public ActionResult EduEntry(int? id)
        {
          //  ViewBag.GeneralInformationId = new SelectList(new List<GeneralInformation>(), "Id", "EmployeId");
            ViewBag.UniversityId = new SelectList(new List<University>(), "Id", "Name");
            return View();
        }
    }
}