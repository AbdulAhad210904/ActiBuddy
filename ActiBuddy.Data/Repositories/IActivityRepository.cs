using ActiBuddy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiBuddy.Data.Repositories
{
    public interface IActivityRepository
    {
        Activity GetActivityById(int id);
        IEnumerable<Activity> GetAllActivities();
        void AddActivity(Activity activity);
        void UpdateActivity(Activity activity);
        void DeleteActivity(int id);
    }
}
