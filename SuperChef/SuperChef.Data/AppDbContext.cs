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

        public IDbSet<Recipe> Recipes { get; set; }
        public IDbSet<Chef> Chefs { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Cuisine> Cuisines { get; set; }
        public IDbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CuisineConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new ChefConfiguration());
            modelBuilder.Configurations.Add(new RecipeConfiguration());
        }
    }
}
