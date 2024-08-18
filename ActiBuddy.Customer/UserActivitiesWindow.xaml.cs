using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using ActiBuddy.Data.Repositories;
using ActiBuddy.Data;

namespace ActiBuddy.Customer
{
    public partial class UserActivitiesWindow : Window
    {
        private readonly int _userId;
        private readonly UserActivityRepository _userActivityRepository;

        public UserActivitiesWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _userActivityRepository = new UserActivityRepository(new DatabaseContext());
            LoadUserActivities();
        }

        private void LoadUserActivities()
        {
            UserActivitiesDataGrid.ItemsSource = _userActivityRepository.GetUserActivitiesByUserId(_userId);
        }
    }
}

