using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain
{
    public class User
    {
  
       public Guid id { get; set; } 
       public string Name { get; set; }
       public string Surname { get; set; }
       public string Email { get; set; }
       public String Role { get; set; }

       public int Age { get; set; }
       [JsonIgnore]
       public string Password { get; set; }


    }
}