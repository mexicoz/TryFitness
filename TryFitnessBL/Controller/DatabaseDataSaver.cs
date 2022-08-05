
using System.Linq;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public T Load<T>(string fileName) where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().FirstOrDefault();
                return result;
            }                
        }

        public void Save(string fileName, object item)
        {
            using(var db = new FitnessContext())
            {
                #region if/else
                //var type = item.GetType();
                //if(type == typeof(User))
                //{
                //    db.Users.Add(item as User);
                //}
                //else if(type == typeof(Gender))
                //{
                //    db.Genders.Add(item as Gender);
                //}
                #endregion

                switch (item.ToString())
                {
                    case nameof(User):
                        db.Users.Add(item as User);
                        break;
                    case nameof(Gender):
                        db.Genders.Add(item as Gender);
                        break;
                    case nameof(Food):
                        db.Foods.Add(item as Food);
                        break;
                    case nameof(Exercise):
                        db.Exercises.Add(item as Exercise);
                        break;
                    case nameof(Eating):
                        db.Eatings.Add(item as Eating);
                        break;
                    case nameof(Activity):
                        db.Activities.Add(item as Activity);
                        break;
                }
                db.SaveChanges();
            }
        }
    }
}
