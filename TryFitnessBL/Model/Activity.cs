using System;
using System.Collections.Generic;

namespace TryFitnessBL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string NameActivity { get; set; }
        public double CaloriesPerMinut { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public Activity() { }
        public Activity(string nameActivity, double calPerMinut)
        {
            NameActivity = nameActivity;
            CaloriesPerMinut = calPerMinut;
        }

        public override string ToString()
        {
            return NameActivity;
        }
    }
}
