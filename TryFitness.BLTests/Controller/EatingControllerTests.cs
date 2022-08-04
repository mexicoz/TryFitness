using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddFoodTest()
        {
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            eatingController.AddFood(food, 300);

            //Assert.AreEqual(food.NameFood, eatingController.Eating.Foods.First().Key.NameFood);
        }
    }
}