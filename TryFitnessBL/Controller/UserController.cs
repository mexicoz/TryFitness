using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController(User user)
        {
            User = user ?? throw new ArgumentException("User cennot be null", nameof(user));
        }
        private void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, User);
            }
        }
        private User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fileStream) is User user)
                {
                    return user;
                }
                else
                {
                    throw new FileLoadException("User not found", nameof(user));
                }
            }
        }
    }
}
