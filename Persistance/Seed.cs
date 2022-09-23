using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistance;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            // what this line of code does is that it tells us if we have context
            // inside our Activities database and we return it.
   
           
        
           
            
            // if our database does not have any activities, this line of code creates
            // a new list of activities and stores it in the variable "new Activity"
            var activities = new List<Activity>()
         
            {
                new Activity
                {
                    Title = "KickBox",
                    Date = "30/12/2022",
                    Duration = "1 Hour",
                    EventCoordinator = "Yllka Selimi",
                    NumberOfParticipants = 20,
                },
                new Activity
                {
                    Title = "Pilates",
                    Date = "30/12/2022",
                    Duration = "1 Hour",
                    EventCoordinator = "Elisa Bruci",
                    NumberOfParticipants = 25,
                },
                new Activity
                {
                    Title = "KangooJump",
                    Date = "30/12/2022",
                    Duration = "45 min",
                    EventCoordinator = "Rita Selimi",
                    NumberOfParticipants = 30,
                },
               new Activity
                {
                    Title = "WeightTraining",
                    Date = "30/12/2022",
                    Duration = "30 min",
                    EventCoordinator = "Viola Bugaqku",
                    NumberOfParticipants = 15,
              
                },
               new Activity
                {
                    Title = "Yoga",
                    Date = "30/12/2022",
                    Duration = "1 hour",
                    EventCoordinator = "Tuana Bekteshi",
                    NumberOfParticipants = 30,
              
                },
                 new Activity
                {
                    Title = "CycleBar",
                    Date = "30/12/2022",
                    Duration = "1 hour",
                    EventCoordinator = "Eda Shefiti",
                    NumberOfParticipants = 25,
                },
                    new Activity
                {
                    Title = "CrossFit",
                    Date = "30/12/2022",
                    Duration = "1 hour",
                    EventCoordinator = "Anda Selimi",
                    NumberOfParticipants = 35,

                },


            };

            
             var equipments = new List<Equipment>()
             {
                  new Equipment
                {
                    Type = "Resistance Band",
                    Category = "Yoga",
                    Description = "All types of band strength",
                    Availability = 12,
                    
                },
                    new Equipment
                {
                    Type = "Dumbbell",
                    Category = "Pilates",
                    Description = "Different Weights",
                    Availability = 20,

                }
             };

            
        
           if(!context.Activities.Any()){
               await context.Activities.AddRangeAsync(activities);
           }

           if(!context.Equipments.Any()){
               await context.Equipments.AddRangeAsync(equipments);
           }
           // if (context.Activities.Any()) return; 
           // if (context.Equipments.Any()) return;
            // then what we do is we add these these activities using the range method,
            // and then we use the other line of code to actually save the changes to the database.
            // now we go and make the use of this method inside our program class.

       


            await context.SaveChangesAsync();





  
        } 
    }
    
}
    
    
    

         