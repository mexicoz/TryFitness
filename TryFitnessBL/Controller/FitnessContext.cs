
using System.Data.Entity;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller
{
    public class FitnessContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }

        public FitnessContext() : base("DBConection") { } 

    }
}
