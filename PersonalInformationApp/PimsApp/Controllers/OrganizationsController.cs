using Pims.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class OrganizationsController : Controller
    {
        // GET: Organizations
        public ActionResult New(int? id)
        {
            return View();
        }
    }
}