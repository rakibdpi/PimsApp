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
        public DbSet<EducationInformations> EducationsInformations { get; set; }
        public DbSet<HomeTrainingInformation> HomeTrainingInformations { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }
        public DbSet<FamilyInfortation> FamilyInfortations { get; set; }
        public DbSet<TransferInformation> TransferInformations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}
