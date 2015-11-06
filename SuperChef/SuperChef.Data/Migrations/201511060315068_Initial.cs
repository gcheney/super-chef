namespace SuperChef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                        ImagePath = c.String(maxLength: 4000),
                        Ingredients = c.String(nullable: false, maxLength: 4000),
                        Directions = c.String(nullable: false, maxLength: 4000),
                        CategoryId = c.Int(nullable: false),
                        CuisineId = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Chef", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Cuisine", t => t.CuisineId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.CuisineId)
                .Index(t => t.CreatedById);
            
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
                .ForeignKey("dbo.Chef", t => t.ChefId)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.ChefId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Chef",
                c => new
                    {
                        ChefId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(nullable: false, maxLength: 4000),
                        Location = c.String(maxLength: 50),
                        Age = c.Int(),
                        About = c.String(maxLength: 1000),
                        Speciality = c.String(maxLength: 2000),
                        ImagePath = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ChefId);
            
            CreateTable(
                "dbo.Cuisine",
                c => new
                    {
                        CuisineId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.CuisineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Recipe", "CuisineId", "dbo.Cuisine");
            DropForeignKey("dbo.Comment", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "CreatedById", "dbo.Chef");
            DropForeignKey("dbo.Comment", "ChefId", "dbo.Chef");
            DropIndex("dbo.Comment", new[] { "RecipeId" });
            DropIndex("dbo.Comment", new[] { "ChefId" });
            DropIndex("dbo.Recipe", new[] { "CreatedById" });
            DropIndex("dbo.Recipe", new[] { "CuisineId" });
            DropIndex("dbo.Recipe", new[] { "CategoryId" });
            DropTable("dbo.Cuisine");
            DropTable("dbo.Chef");
            DropTable("dbo.Comment");
            DropTable("dbo.Recipe");
            DropTable("dbo.Category");
        }
    }
}
