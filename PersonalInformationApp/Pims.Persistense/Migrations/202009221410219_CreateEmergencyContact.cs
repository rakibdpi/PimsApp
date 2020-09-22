namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmergencyContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmergencyContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        Name = c.String(),
                        Relation = c.String(),
                        PhoneNo = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralInformations", t => t.GeneralInformationId, cascadeDelete: true)
                .Index(t => t.GeneralInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmergencyContacts", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.EmergencyContacts", new[] { "GeneralInformationId" });
            DropTable("dbo.EmergencyContacts");
        }
    }
}
