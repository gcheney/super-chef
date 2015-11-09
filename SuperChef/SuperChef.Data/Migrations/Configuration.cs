namespace SuperChef.Data.Migrations
{
    using Core.Entities;
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
            try
            {
                CreateChefs().ForEach(c => context.Chefs.AddOrUpdate(c));
                base.Seed(context);
            }
            catch (DbEntityValidationException e)
            {
                LogValidationErrors(e.EntityValidationErrors);
                throw e;
            }
        }

        private static List<Chef> CreateChefs()
        {
            return new List<Chef>
            {
                new Chef
                {
                    UserName = "KingRamsay",
                    UserId = "f61d86b6-a013-47ff-aa77-a30f9579dda6",
                    Location = "Los Angeles, CA",
                    Age = 48,
                    About = "Multi-Michelin starred chef and star of the small screen, " 
                        + "Gordon Ramsay has opened a string of successful restaurants across the globe.",
                    Speciality = "Being a dick to people",
                    ImagePath = "chefs/gordon-ramsay.jpg"
                },
                new Chef
                {
                    UserName = "The_Puckinator",
                    UserId = "72ec2955-9eb4-418b-ab3d-3dd78bb1ab3a",
                    Location = "Sankt Veit an der Glan, Austria",
                    Age = 66,
                    About = "Austrian-born American celebrity chef, restaurateur, and occasional actor.",
                    Speciality = "Making restaurants, catering services, cookbooks and licensed products.",
                    ImagePath = "chefs/wolfgang-puck.jpg"
                },
                new Chef
                {
                    UserName = "The_Big_O",
                    UserId = "f028dc9c-d1fb-4d94-8cad-1dd487342246",
                    Location = "Clavering, United Kingdom",
                    Age = 40,
                    About = "English celebrity chef, restaurateur, and media personality ",
                    Speciality = "Food-focused television shows, cookbooks and more recently his "
                        + "global campaign for better food education.",
                    ImagePath = "chefs/jamie-oliver.jpg"
                },
                new Chef
                {
                    UserName = "RachRay",
                    UserId = "9cb26779-3401-4c41-8cf3-70271d967474",
                    Location = "New York, NY",
                    Age = 47,
                    About = " American television personality, businesswoman, celebrity cook and author.",
                    Speciality = "Lifestyle programs and three Food Network series",
                    ImagePath = "chefs/rachael-ray.jpg"
                }
            };
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
