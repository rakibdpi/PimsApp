namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEducationInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        ExamName = c.String(),
                        UniversityId = c.Int(nullable: false),
                        Subject = c.String(),
                        Year = c.String(),
                        Result = c.String(),
                        SchoolOrCallege = c.String(),
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
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.GeneralInformationId)
                .Index(t => t.UniversityId);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EducationInformations", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.EducationInformations", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.EducationInformations", new[] { "UniversityId" });
            DropIndex("dbo.EducationInformations", new[] { "GeneralInformationId" });
            DropTable("dbo.Universities");
            DropTable("dbo.EducationInformations");
        }
    }
}
