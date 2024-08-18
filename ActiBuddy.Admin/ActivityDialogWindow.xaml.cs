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

namespace ActiBuddy.Admin
{
    public partial class ActivityDialogWindow : Window
    {
        public Activity Activity { get; private set; }

        public ActivityDialogWindow(Activity activity = null)
        {
            InitializeComponent();
            Activity = activity;

            if (Activity != null)
            {
                // Populate fields with activity data if editing
                NameTextBox.Text = Activity.Name;
                DescriptionTextBox.Text = Activity.Description;
                DatePicker.SelectedDate = Activity.Date;
                LatitudeTextBox.Text = Activity.Latitude.ToString();
                LongitudeTextBox.Text = Activity.Longitude.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Activity == null)
            {
                Activity = new Activity
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Date = DatePicker.SelectedDate ?? DateTime.Now,
                    Latitude = double.Parse(LatitudeTextBox.Text),
                    Longitude = double.Parse(LongitudeTextBox.Text)
                };
            }
            else
            {
                Activity.Name = NameTextBox.Text;
                Activity.Description = DescriptionTextBox.Text;
                Activity.Date = DatePicker.SelectedDate ?? DateTime.Now;
                Activity.Latitude = double.Parse(LatitudeTextBox.Text);
                Activity.Longitude = double.Parse(LongitudeTextBox.Text);
            }

            DialogResult = true; // Indicates that the user clicked Save
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Indicates that the user clicked Cancel
        }
    }
}
