namespace EntityMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "imgPath", c => c.String());
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.Users");
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserProfiles");
            DropColumn("dbo.UserProfiles", "UserProfiles");
        }
    }
}
