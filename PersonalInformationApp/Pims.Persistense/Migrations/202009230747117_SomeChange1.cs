namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChange1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HomeTrainingInformations", "NameEnglish");
            DropColumn("dbo.HomeTrainingInformations", "PhoneNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomeTrainingInformations", "PhoneNo", c => c.String());
            AddColumn("dbo.HomeTrainingInformations", "NameEnglish", c => c.String());
        }
    }
}
