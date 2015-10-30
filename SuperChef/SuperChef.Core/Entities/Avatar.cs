using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperChef.Core.Entities
{
    public class Avatar : Image
    {
        public int ChefId { get; set; }
        public virtual Chef Chef { get; set; }
    }
}
