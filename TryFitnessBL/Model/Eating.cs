using System;
using System.Collections.Generic;
using System.Linq;

namespace TryFitnessBL.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime MomentEating { get; }
        public Dictionary<Food, double> Foods { get; }
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Name cannot be empty or null", nameof(user));
            MomentEating = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void AddFood(Food food, double weigth)
        {
            var newFood = Foods.Keys.FirstOrDefault(f => f.NameFood.Equals(food.NameFood));
           
            if(newFood == null)
            {
                Foods.Add(food, weigth);
            }
            else
            {
                Foods[newFood] += weigth;
            }
        }
    }
}
