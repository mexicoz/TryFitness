using System;


namespace TryFitnessBL.Model
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        public User() { }
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Check conditions

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null", nameof(name));
            }            
            if(birthDate < DateTime.Parse("01.01.1923") && birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth", nameof(birthDate));
            }
            if(weight < 0)
            {
                throw new ArgumentException("Impossible wieght", nameof(weight));
            }
            if(height < 0)
            {
                throw new ArgumentException("Impossible height", nameof(height));
            }
            #endregion

            Gender = gender ?? throw new ArgumentNullException("Gender cannot be null", nameof(gender));
            Name = name; 
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
