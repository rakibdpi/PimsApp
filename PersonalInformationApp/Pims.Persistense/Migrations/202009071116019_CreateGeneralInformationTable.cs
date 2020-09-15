namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGeneralInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeId = c.String(nullable: false),
                        NameBangla = c.String(nullable: false),
                        NameEnglish = c.String(nullable: false),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        BithDate = c.DateTime(nullable: false),
                        BirthPlace = c.String(),
                        Nationality = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        BloodGroup = c.String(),
                        Religion = c.String(),
                        Gender = c.String(),
                        MeritialStatus = c.String(),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(),
                        NationalId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        Position = c.String(),
                        JobJoiningDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralInformations", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.GeneralInformations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.GeneralInformations", new[] { "DesignationId" });
            DropIndex("dbo.GeneralInformations", new[] { "DepartmentId" });
            DropTable("dbo.GeneralInformations");
        }
    }
}
