using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ActiBuddy.Data.Models;

namespace ActiBuddy.Data.Repositories
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly DatabaseContext _context;

        public UserActivityRepository(DatabaseContext context)
        {
            _context = context;
        }

        // Retrieve all activities available
        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities.ToList();
        }

        // Add a user to an activity (sign up)
        public void AddUserActivity(UserActivity userActivity)
        {
            _context.UserActivities.Add(userActivity);
            _context.SaveChanges();
        }

        // Retrieve the activities a user has signed up for by userId
        public IEnumerable<UserActivity> GetUserActivitiesByUserId(int userId)
        {
            return _context.UserActivities.Where(ua => ua.UserId == userId).ToList();
        }
    }
}
