using Microsoft.Reporting.WebForms;
using Pims.Service.ReportModule;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PimsApp.Controllers
{
    public class ReportController : Controller
    {
        AllEmployeReportDataManager _manager = new AllEmployeReportDataManager();

        // GET: Report
        public ActionResult ReportForm()
        {
            return View();
        }

        //Get All Employee
        [HttpPost]
        [Route("Report/GetAllEmployee")]
        public JsonResult GetAllEmployee()
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();

   

                string path = Path.Combine(Server.MapPath("/Reports"), "AllEmploye.rdlc");
                viewer.LocalReport.ReportPath = path;

                var generalInfo = _manager.GetData();
                var gi = new ReportDataSource("AllEmployeeReportDataset", generalInfo);
                viewer.LocalReport.DataSources.Add(gi);



                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/Report";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }

                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/Report/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}