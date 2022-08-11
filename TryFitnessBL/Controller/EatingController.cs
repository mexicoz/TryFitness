using System;
using System.Collections.Generic;
using System.Linq;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }
        
        public void AddFood(Food food, double weight)
        {
            var existFood = Foods.SingleOrDefault(f => f.NameFood == food.NameFood);

            if (existFood == null)
            {
                Foods.Add(food);
                Eating.AddFood(food, weight);
                SaveAllFoods();
            }
            else
            {
                Eating.AddFood(existFood, weight);
                SaveAllFoods();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }
        private void SaveAllFoods()
        {
            Save(Foods);
        }
    }
}
