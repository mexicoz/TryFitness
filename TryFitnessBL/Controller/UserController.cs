using System;
using System.Collections.Generic;
using TryFitnessBL.Model;
using System.Linq;

namespace TryFitnessBL.Controller
{
    public class UserController : ControllerBase
    {
        private const string FILE_NAME = "users.dat";
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name cannot be empty or null", nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                SaveUsersData();
            }
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weigth = 1, double heigth = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weigth;
            CurrentUser.Height = heigth;
            SaveUsersData();
        }
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }
        
        public void SaveUsersData()
        {
            Save(Users);
        }
    }
}
