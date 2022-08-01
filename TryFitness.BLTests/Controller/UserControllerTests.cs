﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TryFitnessBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryFitnessBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
      
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 180;
            var gender = "man";
            var controller = new UserController(userName);

            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            var controller = new UserController(userName);
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}