using System;
using TryFitnessBL.Controller;
using TryFitnessBL.Model;

namespace TryFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();

            UserController user = new UserController(name);
            EatingController eatingController = new EatingController(user.CurrentUser);

            if (user.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParsDate();
                var weigth = ParsDouble("Weigth");
                var height = ParsDouble("Height");
               
                user.SetNewUserData(gender, birthDate, weigth, height);
            }

            Console.WriteLine(user.CurrentUser);

            Console.WriteLine("Choose what to do next");
            Console.WriteLine("E - Enter eating");
            var key = Console.ReadKey();            

            if(key.Key == ConsoleKey.E)
            {
                Console.WriteLine();
                var food = EnterEating();
                eatingController.AddFood(food.Food, food.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter food name: ");
            var food = Console.ReadLine();

            var prots = ParsDouble("proteins");
            var fats = ParsDouble("fats");
            var carbs = ParsDouble("calories");
            var calories = ParsDouble("calories");
            var weight = ParsDouble("weight of food");

            var product = new Food(food, prots, fats, carbs, calories);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParsDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter your birthday: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect format");
                }
            }
            return birthDate;
        }

        private static double ParsDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Incorrect format");
                }
            }
        }
    } 
}
