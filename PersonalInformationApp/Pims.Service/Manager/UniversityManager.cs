using Pims.Core.Model.SetupModules;
using Pims.Persistense.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Pims.Service.Manager
{
    public class UniversityManager
    {
        private PimsDbContext _dbContext;

        public UniversityManager()
        {
            _dbContext = new PimsDbContext();
        }


        public IEnumerable<University> GetAll()
        {
            var department = _dbContext.universities.ToList();
               
            return department;
        }
    }
}
