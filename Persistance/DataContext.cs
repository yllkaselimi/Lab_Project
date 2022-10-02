using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;



namespace Persistance
{
    public class DataContext : DbContext
    {

        // what we are doing here: we have the dbContextOptions and the we parse through
        // our options to the base which is the constructor inside the DbContext class we
        // are deriving from and then we parse it through the options to that class
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        // We add a property type "DbSet" that takes a paramater, we use "Activity"
        // we give it a name that is going to reflect our database table "Activities"
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Shirts> Shirt { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Protein> Proteins { get; set; }
        public DbSet<User> Users { get; set; }
    }
}