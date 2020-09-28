using Pims.Core.ReportModel;
using Pims.Persistense.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Service.ReportModule
{
    public class AllEmployeReportDataManager
    {
        private PimsDbContext _dbContext;

        public AllEmployeReportDataManager()
        {
            _dbContext = new PimsDbContext();
        }

        public IEnumerable<AllEmplyeeReport> GetData()
        {
            //Get Employee
            var employes = _dbContext.GeneralInformations.ToList();

            //List Define
            var employeList = new List<AllEmplyeeReport>();

            foreach(var emp in employes)
            {
                var employee = new AllEmplyeeReport()
                {
                    Name = emp.NameEnglish,
                    PhoneNo = emp.PhoneNo,
                    Email = emp.Email,
                    BloodGroup = emp.BloodGroup,
                    Addrees = emp.PresentAddress,
                    NationalId = emp.NationalId,
                    EmployeId = emp.EmployeId

                };
                employeList.Add(employee);
            }
            return employeList;

        }


    }
}
