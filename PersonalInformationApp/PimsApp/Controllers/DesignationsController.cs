using Pims.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class DesignationsController : Controller
    {
        // GET: Designations
        public ActionResult New(int? id)
        {
            var vm = new DesignationViewModel() { IsActive = true };
            return View(vm);
        }
    }
}