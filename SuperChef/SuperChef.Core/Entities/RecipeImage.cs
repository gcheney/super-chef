using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperChef.Core.Entities
{
    public class RecipeImage : Image
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
