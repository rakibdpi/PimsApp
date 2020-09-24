namespace Pims.Persistense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSocialMediaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        MediaName = c.String(),
                        MediaLink = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
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
            DropForeignKey("dbo.SocialMedias", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.SocialMedias", new[] { "GeneralInformationId" });
            DropTable("dbo.SocialMedias");
        }
    }
}
