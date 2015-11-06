
using SuperChef.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperChef.Web.ViewModels
{
    public class ChefIndexViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string Speciality { get; set; }
        public string ImagePath { get; set; }
    }

    public class ChefEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Chef Name")]
        public string ChefName { get; set; }
        public string UserId { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public string Speciality { get; set; }
        public string ImagePath { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Recipe> Recipes { get; set; }
    }

    public class ChefDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Chef Name")]
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public string Speciality { get; set; }
        public string ImagePath { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}