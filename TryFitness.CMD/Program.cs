using System;
using TryFitnessBL.Controller;

namespace TryFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();

            UserController user = new UserController(name);

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
            Console.ReadLine();
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
                Console.Write($"Enter your {name}: ");
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
