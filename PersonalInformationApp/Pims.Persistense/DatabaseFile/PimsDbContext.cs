using Pims.Core.Model;
using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModules;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pims.Persistense.DatabaseFile
{
    public class PimsDbContext : DbContext
    {

        //Setup Modules

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<University> universities { get; set; }


        //Opertion Modules

        public DbSet<GeneralInformation> GeneralInformations { get; set; }
        public DbSet<EducationInformations> EducationsInformations { get; set; }
        public DbSet<HomeTrainingInformation> HomeTrainingInformations { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }
        public DbSet<FamilyInfortation> FamilyInfortations { get; set; }
        public DbSet<TransferInformation> TransferInformations { get; set; }
      
        public DbSet<SocialMedia> SocialMedias { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
