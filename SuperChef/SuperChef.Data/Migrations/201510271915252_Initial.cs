namespace SuperChef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvatarImages",
                c => new
                    {
                        AvatarImageId = c.Int(nullable: false),
                        ChefId = c.Int(nullable: false),
                        ImagePath = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.AvatarImageId)
                .ForeignKey("dbo.Chef", t => t.AvatarImageId, cascadeDelete: true)
                .Index(t => t.AvatarImageId);
            
            CreateTable(
                "dbo.Chef",
                c => new
                    {
                        ChefId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(nullable: false, maxLength: 4000),
                        Location = c.String(maxLength: 50),
                        Age = c.Int(),
                        About = c.String(maxLength: 1000),
                        AvatarImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChefId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 50),
                        DatePosted = c.DateTime(nullable: false),
                        ChefId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Chef", t => t.ChefId)
                .Index(t => t.ChefId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Servings = c.Int(),
                        PreparationTime = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        Upvotes = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, storeType: "date"),
                        DateEdited = c.DateTime(storeType: "date"),
                        CategoryId = c.Int(nullable: false),
                        CuisineId = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Cuisine", t => t.CuisineId)
                .ForeignKey("dbo.Chef", t => t.CreatedById, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.CuisineId)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Cuisine",
                c => new
                    {
                        CuisineId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.CuisineId);
            
            CreateTable(
                "dbo.RecipeImages",
                c => new
                    {
                        RecipeImageId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        ImagePath = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.RecipeImageId)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvatarImages", "AvatarImageId", "dbo.Chef");
            DropForeignKey("dbo.Recipe", "CreatedById", "dbo.Chef");
            DropForeignKey("dbo.Comment", "ChefId", "dbo.Chef");
            DropForeignKey("dbo.Comment", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.RecipeImages", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "CuisineId", "dbo.Cuisine");
            DropForeignKey("dbo.Recipe", "CategoryId", "dbo.Category");
            DropIndex("dbo.RecipeImages", new[] { "RecipeId" });
            DropIndex("dbo.Recipe", new[] { "CreatedById" });
            DropIndex("dbo.Recipe", new[] { "CuisineId" });
            DropIndex("dbo.Recipe", new[] { "CategoryId" });
            DropIndex("dbo.Comment", new[] { "RecipeId" });
            DropIndex("dbo.Comment", new[] { "ChefId" });
            DropIndex("dbo.AvatarImages", new[] { "AvatarImageId" });
            DropTable("dbo.RecipeImages");
            DropTable("dbo.Cuisine");
            DropTable("dbo.Category");
            DropTable("dbo.Recipe");
            DropTable("dbo.Comment");
            DropTable("dbo.Chef");
            DropTable("dbo.AvatarImages");
        }
    }
}
