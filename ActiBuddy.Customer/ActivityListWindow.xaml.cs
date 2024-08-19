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

using ActiBuddy.Data.Models;
using ActiBuddy.Data.Repositories;
using ActiBuddy.Data;

namespace ActiBuddy.Customer
{
    public partial class ActivityListWindow : Window
    {
        private readonly int _userId;
        private readonly UserActivityRepository _userActivityRepository;

        public ActivityListWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _userActivityRepository = new UserActivityRepository(new DatabaseContext());
            LoadActivities();
        }

        // Load all activities
        private void LoadActivities()
        {
            ActivitiesDataGrid.ItemsSource = _userActivityRepository.GetAllActivities();
        }

        // Sign up for an activity
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Activity selectedActivity)
            {
                var userActivity = new UserActivity
                {
                    UserId = _userId,
                    ActivityId = selectedActivity.ActivityId
                };

                _userActivityRepository.AddUserActivity(userActivity);
                MessageBox.Show("Signed up successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

