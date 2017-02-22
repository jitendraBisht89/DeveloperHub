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
            DropColumn("dbo.UserProfiles", "imgPath");
        }
    }
}
