using System;


namespace TryFitnessBL.Model
{
    [Serializable]
    public class Activity
    {
        public string NameActivity { get; }
        public double CaloriesPerMinut { get; }
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
