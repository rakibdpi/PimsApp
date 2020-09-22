namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTransferInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyInfortations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        Name = c.String(),
                        Relation = c.String(),
                        PhoneNo = c.String(),
                        MaritalStatus = c.String(),
                        Occupation = c.String(),
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
                .Index(t => t.GeneralInformationId);
            
            CreateTable(
                "dbo.TransferInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        WorkingPlace = c.String(),
                        Duration = c.String(),
                        OfficeOrderNumber = c.String(),
                        Address = c.String(),
                        Remarks = c.String(),
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
                .Index(t => t.GeneralInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransferInformations", "GeneralInformationId", "dbo.GeneralInformations");
            DropForeignKey("dbo.FamilyInfortations", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.TransferInformations", new[] { "GeneralInformationId" });
            DropIndex("dbo.FamilyInfortations", new[] { "GeneralInformationId" });
            DropTable("dbo.TransferInformations");
            DropTable("dbo.FamilyInfortations");
        }
    }
}
