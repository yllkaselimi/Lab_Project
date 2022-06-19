using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Activity
    {
        // the reason for using guid is bc we can generate this 
        // from the service side or generate this from the client side

       public Guid id { get; set; } 
       public string Title { get; set; }
       public DateTime Date { get; set; }
       public string Duration { get; set; }
       public string EventCoordinator { get; set; }
       public int NumberOfParticipants { get; set; }
       
       
    }
}