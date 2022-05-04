using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            // what this line of code does is that it tells us if we have context
            // inside our Activities database and we return it.
            if (context.Activities.Any()) return;
            
            // if our database does not have any activities, this line of code creates
            // a new list of activities and stores it in the variable "new Activity"
            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "KickBox",
                    Date = DateTime.Now.AddMonths(1),
                    Duration = "1 Hour",
                    EventCoordinator = "Yllka Selimi",
                    NumberOfParticipants = 20,
                },
           new Activity
                {
                    Title = "Pilates",
                    Date = DateTime.Now.AddMonths(1),
                    Duration = "1 Hour",
                    EventCoordinator = "Elisa Bruci",
                    NumberOfParticipants = 25,
                },
              new Activity
                {
                    Title = "KangooJump",
                    Date = DateTime.Now.AddMonths(1),
                    Duration = "45 min",
                    EventCoordinator = "Rita Selimi",
                    NumberOfParticipants = 30,
                },
               new Activity
                {
                    Title = "WeightTraining",
                    Date = DateTime.Now.AddMonths(1),
                    Duration = "30 min",
                    EventCoordinator = "Viola Bugaqku",
                    NumberOfParticipants = 15,
                },
               new Activity
                {
                    Title = "Yoga",
                    Date = DateTime.Now.AddMonths(1),
                    Duration = "1 hour",
                    EventCoordinator = "Tuana Bekteshi",
                    NumberOfParticipants = 30,
                },

                 new Activity
                {
                    Title = "CycleBar",
                    Date = DateTime.Now.AddMonths(1),
                    Duration = "1 hour",
                    EventCoordinator = "Eda Shefiti",
                    NumberOfParticipants = 25,
                },
                    new Activity
                {
                    Title = "CrossFit",
                    Date = DateTime.Now.AddMonths(1),
                    Duration = "1 hour",
                    EventCoordinator = "Anda Selimi",
                    NumberOfParticipants = 35,
                },

            };
            // then what we do is we add these these activities using the range method,
            // and then we use the other line of code to actually save the changes to the database.
            // now we go and make the use of this method inside our program class.

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}