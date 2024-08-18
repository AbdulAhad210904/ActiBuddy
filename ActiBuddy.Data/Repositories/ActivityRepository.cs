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
            _context = context;
        }

        public Activity GetActivityById(int id)
        {
            return _context.Activities.Find(id);
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities.ToList();
        }

        public void AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        public void UpdateActivity(Activity activity)
        {
            _context.Entry(activity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteActivity(int id)
        {
            var activity = _context.Activities.Find(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
