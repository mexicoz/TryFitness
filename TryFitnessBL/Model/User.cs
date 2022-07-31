using System;


namespace TryFitnessBL.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public double Weight { get; set; }
        public double Height { get; set; }

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
            if(gender== null)
            {
                throw new ArgumentNullException("Gender cannot be null", nameof(gender));
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

            Name = name;
            Gender = gender; 
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
