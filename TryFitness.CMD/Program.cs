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

            Console.WriteLine("Enter your gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your birthDay");
            var birthDay = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter your weight");
            var weigth = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height");
            var height = double.Parse(Console.ReadLine());

            UserController user = new UserController(name, gender, birthDay, weigth, height);

            user.Save();
        }
    }
}
