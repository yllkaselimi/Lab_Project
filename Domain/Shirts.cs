using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Shirts
    {
          
       public Guid id { get; set; } 
       public string Type { get; set; }
       public string Color { get; set; }
       public string Size { get; set; }
       public string Description { get; set; }
       public int Quantity { get; set; }
    
    }
}