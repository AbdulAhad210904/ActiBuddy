﻿    using System;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    namespace ActiBuddy.Customer
    {
        public partial class MainWindow : Window
        {
            private readonly int _userId;

            public MainWindow(int userId)
            {
                InitializeComponent();
                _userId = userId;
            }

            private void ViewActivitiesButton_Click(object sender, RoutedEventArgs e)
            {
                ActivityListWindow activityListWindow = new ActivityListWindow(_userId);
                activityListWindow.Show();
            }

            private void MyActivitiesButton_Click(object sender, RoutedEventArgs e)
            {
                UserActivitiesWindow userActivitiesWindow = new UserActivitiesWindow(_userId);
                userActivitiesWindow.Show();
            }
        }
    }

