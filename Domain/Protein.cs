using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Protein
    {
          
       public Guid id { get; set; } 
       public string Name { get; set; }
       public string Flavor { get; set; }
       public string Description { get; set; }
       public string Quantity { get; set; }
    
    }
}