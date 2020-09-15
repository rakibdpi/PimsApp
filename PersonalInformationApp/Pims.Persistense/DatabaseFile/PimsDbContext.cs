using Pims.Core.Model;
using Pims.Core.Model.OperationModules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Persistense.DatabaseFile
{
    public class PimsDbContext : DbContext
    {

        //Setup Modules

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Organization> Organizations { get; set; }


        //Opertion Modules
    
        public DbSet<GeneralInformation> GeneralInformations { get; set; }

    }
}
