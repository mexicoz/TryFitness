using System;


namespace TryFitnessBL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string NameFood { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohybrates { get; set; }
        public double Calories { get; set; }
        private double CaloriesOneGram { get { return Calories / 100.0; } }
        private double ProteinsOneGram { get { return Proteins / 100.0; } }
        private double FatsOneGram { get { return Fats / 100.0; } }
        private double CarbohybratesOneGram { get { return Carbohybrates / 100.0; } }

        public Food(string nameFood) : this(nameFood, 0, 0, 0, 0){  }
        public Food(string nameFood, double proteins, double fats, double carbohybrates, double calories)
        {
            NameFood = nameFood;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohybrates = carbohybrates / 100.0;
        }
        public override string ToString()
        {
            return NameFood;
        }
    }
}
