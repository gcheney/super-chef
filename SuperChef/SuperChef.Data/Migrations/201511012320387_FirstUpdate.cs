namespace SuperChef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AvatarImages", newName: "Avatars");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Avatars", newName: "AvatarImages");
        }
    }
}
