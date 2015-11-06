namespace SuperChef.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperChefContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperChefContext context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            try
            {
                base.Seed(context);
            }
            catch (DbEntityValidationException e)
            {
                LogValidationErrors(e.EntityValidationErrors);
                throw e;
            }
        }

        private void LogValidationErrors(IEnumerable<DbEntityValidationResult> validationErrors)
        {
            foreach (var error in validationErrors)
            {
                Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    error.Entry.Entity.GetType().Name,
                    error.Entry.State);

                foreach (var e in error.ValidationErrors)
                {
                    Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                        e.PropertyName,
                        error.Entry.CurrentValues.GetValue<object>(e.PropertyName),
                        e.ErrorMessage);
                }
            }
        }
    }
}
