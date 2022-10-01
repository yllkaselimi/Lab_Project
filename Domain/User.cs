using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
  
       public Guid id { get; set; } 
       public string Name { get; set; }
       public string Surname { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public int Age { get; set; }
       
    }
}