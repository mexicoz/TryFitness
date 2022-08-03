using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";
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
            var newFood = Foods.SingleOrDefault(f => f.NameFood == food.NameFood);
            if (newFood == null)
            {
                Foods.Add(food);
                Eating.AddFood(food, weight);
                SaveAllFoods();
            }
            else
            {
                Eating.AddFood(newFood, weight);
                SaveAllFoods();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }
        private void SaveAllFoods()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}
