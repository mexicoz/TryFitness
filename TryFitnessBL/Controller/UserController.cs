using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height )
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if( formatter.Deserialize(fileStream) is User user)
                {
                    User = user;
                }
            }
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, User);
            }
        }
    }
}
