using ActiBuddy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiBuddy.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DatabaseContext _context;
        public ActivityRepository(DatabaseContext context)
        {
            //context is a parameter that is passed to the constructor
            _context = context;
        }

        public Activity GetActivityById(int id)
        {
            //Find the activity by id
            return _context.Activities.Find(id);
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            //Return all activities
            return _context.Activities.ToList();
        }

        public void AddActivity(Activity activity)
        {
            //Add the activity to the database
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        public void UpdateActivity(Activity activity)
        {
            //Update the activity in the database
            _context.Entry(activity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteActivity(int id)
        {
            //Find the activity by id and remove it from the database
            var activity = _context.Activities.Find(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
