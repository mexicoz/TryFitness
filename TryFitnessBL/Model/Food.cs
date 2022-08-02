using System;


namespace TryFitnessBL.Model
{
    [Serializable]
    public class Food
    {
        public string NameFood { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohybrates { get; }
        public double Calories { get; }
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
