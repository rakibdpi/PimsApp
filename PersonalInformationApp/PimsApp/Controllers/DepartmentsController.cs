using Pims.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        public ActionResult New()
        {
            var vm = new DepartmentViewModel() { IsActive = true };
            return View(vm);
        }
    }
}