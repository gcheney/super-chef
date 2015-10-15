namespace SuperChef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            DropTable("dbo.UserProfiles");
        }
    }
}
