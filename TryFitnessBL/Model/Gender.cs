using System;


namespace TryFitnessBL.Model
{
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The fiel cannot be empty", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
