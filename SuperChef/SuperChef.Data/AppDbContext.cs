using System.Data.Entity;
using SuperChef.Core.Entities;
using SuperChef.Data.Configurations;
using SuperChef.Data.Migrations;

namespace SuperChef.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Avatar> AvatarImages { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CuisineConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new ChefConfiguration());
            modelBuilder.Configurations.Add(new RecipeConfiguration());
            modelBuilder.Configurations.Add(new AvatarImageConfiguration());
            modelBuilder.Configurations.Add(new RecipeImageConfiguration());
        }
    }
}
