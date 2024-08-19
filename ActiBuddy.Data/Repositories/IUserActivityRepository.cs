using ActiBuddy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiBuddy.Data.Repositories
{
    public interface IUserActivityRepository
    {
        IEnumerable<Activity> GetAllActivities();
        void AddUserActivity(UserActivity userActivity);
        IEnumerable<UserActivity> GetUserActivitiesByUserId(int userId);
        void DeleteUserActivity(int userActivityId, int userId);
    }
}
