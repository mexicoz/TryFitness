using System;
using System.Collections.Generic;
using System.Linq;
using TryFitnessBL.Model;

namespace TryFitnessBL.Controller
{
    public class ExerciseController : ControllerBase
    {        
        private readonly User user;
        public List<Exercise> Exercises;
        public List<Activity> Activities;

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User cennot be null", nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void AddExercise(Activity activity, DateTime start, DateTime finish)
        {
            var exixtActivity = Activities.SingleOrDefault(a => a.NameActivity == activity.NameActivity);

            if(exixtActivity == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, finish, exixtActivity, user);
                Exercises.Add(exercise);
            }
            SaveAllExercises();
        }
        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }
        private void SaveAllExercises()
        {
            Save(Exercises);            
        }
    }
}
