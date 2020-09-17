namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGeneralInfoTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GeneralInformations", "NationalId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GeneralInformations", "NationalId", c => c.Int(nullable: false));
        }
    }
}
