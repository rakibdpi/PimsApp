using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pims.Core.Model;

namespace PimsApp.Controllers
{
    public class GeneralInformationsController : Controller
    {
        // GET: GeneralInformations
        public ActionResult EmployeEntry(int? id)
        {
            ViewBag.DepartmentId = new SelectList(new List<Department>(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(new List<Designation>(), "Id", "Name");

            return View();
        }
    }
}