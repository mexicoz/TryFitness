using System;


namespace TryFitnessBL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string NameActivity { get; set; }
        public double CaloriesPerMinut { get; set; }
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
