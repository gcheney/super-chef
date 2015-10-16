namespace SuperChef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            AddColumn("dbo.UserProfiles", "UserBio", c => c.String());
            AddColumn("dbo.UserProfiles", "UserId", c => c.String());
            DropColumn("dbo.UserProfiles", "Location");
            DropColumn("dbo.UserProfiles", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UserProfiles", "Location", c => c.String());
            DropColumn("dbo.UserProfiles", "UserId");
            DropColumn("dbo.UserProfiles", "UserBio");
            CreateIndex("dbo.UserProfiles", "User_Id");
            AddForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
