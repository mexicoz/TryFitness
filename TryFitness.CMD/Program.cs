using System;
using System.Globalization;
using System.Resources;
using TryFitnessBL.Controller;
using TryFitnessBL.Model;

namespace TryFitness.CMD
{
    class Program
    {
        const string EN_US = "en-us";
        const string RU_UA = "ru-ua";
        const string RESOURCE_MANAGER_ROOT = "TryFitness.CMD.Langueges.Messages";

        static CultureInfo culture = CultureInfo.CreateSpecificCulture(EN_US);
        static ResourceManager resuorceManager = new ResourceManager(RESOURCE_MANAGER_ROOT, typeof(Program).Assembly);
        static void Main(string[] args)
        {

            Console.WriteLine("-------------------");

            ShooseLang();

            Console.WriteLine(resuorceManager.GetString("UserName", culture));
            var name = Console.ReadLine();

            UserController user = new UserController(name);
            EatingController eatingController = new EatingController(user.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(user.CurrentUser);

            if (user.IsNewUser)
            {
                Console.Write(resuorceManager.GetString("UserGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParsDate(resuorceManager.GetString("UserBirthday", culture));
                var weigth = ParsDouble(resuorceManager.GetString("UserWeigth", culture));
                var height = ParsDouble(resuorceManager.GetString("UserHeight", culture));
               
                user.SetNewUserData(gender, birthDate, weigth, height);
            }

            Console.WriteLine(user.CurrentUser);

            while (true)
            {
                Console.WriteLine(resuorceManager.GetString("ShooseNext", culture));
                Console.WriteLine(resuorceManager.GetString("EnterEating", culture));
                Console.WriteLine(resuorceManager.GetString("EnterExersise", culture));
                Console.WriteLine(resuorceManager.GetString("EnterQuit", culture));
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        Console.WriteLine();
                        var food = EnterEating();
                        eatingController.AddFood(food.Food, food.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine();
                        var exercise = EnterExercise();
                        exerciseController.AddExercise(exercise.activity, exercise.startDate, exercise.finishDate);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity}, {item.Start.ToShortTimeString()} - {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }            
        }

        private static (DateTime startDate, DateTime finishDate, Activity activity ) EnterExercise()
        {
            Console.Write(resuorceManager.GetString("ExerciseName", culture));
            var exercise = Console.ReadLine();
            var energy = ParsDouble(resuorceManager.GetString("EnergyPerMin", culture));

            var activity = new Activity(exercise, energy);

            var startDate = ParsDate(resuorceManager.GetString("StartExercise", culture));
            var finishDate = ParsDate(resuorceManager.GetString("EndExercise", culture));

            return (startDate: startDate, finishDate: finishDate, activity: activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write(resuorceManager.GetString("FoodName", culture));
            var food = Console.ReadLine();

            var prots = ParsDouble(resuorceManager.GetString("proteins", culture));
            var fats = ParsDouble(resuorceManager.GetString("fats", culture));
            var carbs = ParsDouble(resuorceManager.GetString("carbohybrates", culture));
            var calories = ParsDouble(resuorceManager.GetString("calories", culture));
            var weight = ParsDouble(resuorceManager.GetString("FoodWeight", culture));

            var product = new Food(food, prots, fats, carbs, calories);

            return (Food: product, Weight: weight);
        }
        private static void ShooseLang()
        {
            Console.WriteLine("r - RU or another key - continue");

            var key1 = Console.ReadKey();

            if (key1.Key == ConsoleKey.R)
            {
                Console.WriteLine();
                culture = CultureInfo.CreateSpecificCulture(RU_UA);
            }
        }

        private static DateTime ParsDate(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write(value);
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(resuorceManager.GetString("IncorrectFormat", culture));
                }
            }
            return birthDate;
        }

        private static double ParsDouble(string name)
        {
            while (true)
            {
                Console.Write($"{resuorceManager.GetString("Enter", culture)} {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(resuorceManager.GetString("IncorrectFormat", culture));
                }
            }
        }
    } 
}
