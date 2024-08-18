using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ActiBuddy.Data.Models;
using ActiBuddy.Data.Repositories;
using ActiBuddy.Data;

namespace ActiBuddy.Admin
{
    public partial class ActivityManagementWindow : Window
    {
        private readonly ActivityRepository _activityRepository;

        public ActivityManagementWindow()
        {
            InitializeComponent();
            _activityRepository = new ActivityRepository(new DatabaseContext());
            LoadActivities();
        }

        private void LoadActivities()
        {
            List<Activity> activities = _activityRepository.GetAllActivities().ToList();
            ActivitiesDataGrid.ItemsSource = activities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var activityDialog = new ActivityDialogWindow();
            if (activityDialog.ShowDialog() == true)
            {
                var newActivity = activityDialog.Activity;
                _activityRepository.AddActivity(newActivity);
                LoadActivities();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Activity selectedActivity)
            {
                var activityDialog = new ActivityDialogWindow(selectedActivity);
                if (activityDialog.ShowDialog() == true)
                {
                    var updatedActivity = activityDialog.Activity;
                    _activityRepository.UpdateActivity(updatedActivity);
                    LoadActivities();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Activity selectedActivity)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this activity?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _activityRepository.DeleteActivity(selectedActivity.ActivityId);
                    LoadActivities();
                }
            }
        }
    }
}
