using System.Data.Entity;
using SuperChef.Core.Entities;
using SuperChef.Data.Configurations;
using SuperChef.Data.Migrations;

namespace SuperChef.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Recipe> Recipes { get; set; }
        public IDbSet<Chef> Chefs { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Cuisine> Cuisines { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Avatar> AvatarImages { get; set; }
        public IDbSet<RecipeImage> RecipeImages { get; set; }

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
