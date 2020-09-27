namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmergrncyContract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmergencyContacts", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.EmergencyContacts", "CreateBy", c => c.String());
            AddColumn("dbo.EmergencyContacts", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmergencyContacts", "UpdateBy", c => c.String());
            AddColumn("dbo.EmergencyContacts", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.EmergencyContacts", "DeleteBy", c => c.String());
            AddColumn("dbo.EmergencyContacts", "DeleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmergencyContacts", "DeleteDate");
            DropColumn("dbo.EmergencyContacts", "DeleteBy");
            DropColumn("dbo.EmergencyContacts", "UpdateDate");
            DropColumn("dbo.EmergencyContacts", "UpdateBy");
            DropColumn("dbo.EmergencyContacts", "CreateDate");
            DropColumn("dbo.EmergencyContacts", "CreateBy");
            DropColumn("dbo.EmergencyContacts", "IsDelete");
        }
    }
}
