namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHomeTraingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeTrainingInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        CourseName = c.String(),
                        OrganizationId = c.Int(nullable: false),
                        Duration = c.String(),
                        Result = c.String(),
                        Address = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralInformations", t => t.GeneralInformationId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.GeneralInformationId)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeTrainingInformations", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.HomeTrainingInformations", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.HomeTrainingInformations", new[] { "OrganizationId" });
            DropIndex("dbo.HomeTrainingInformations", new[] { "GeneralInformationId" });
            DropTable("dbo.HomeTrainingInformations");
        }
    }
}
