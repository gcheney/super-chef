
using SuperChef.Core.Entities;
using System.Collections.Generic;

namespace SuperChef.Web.ViewModels
{
    public class ChefViewModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public string Speciality { get; set; }
        public string Image { get; set; }

        public virtual List<Recipe> Recipes { get; set; }
    }
}