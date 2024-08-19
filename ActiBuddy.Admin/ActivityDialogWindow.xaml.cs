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
                // Populate fields with activity data if editing the partcular ctivity
                NameTextBox.Text = Activity.Name;
                DescriptionTextBox.Text = Activity.Description;
                DatePicker.SelectedDate = Activity.Date;
                LatitudeTextBox.Text = Activity.Latitude.ToString();
                LongitudeTextBox.Text = Activity.Longitude.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
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
        }

        private bool ValidateForm()
        {
            // Validate Name
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                NameTextBox.Focus();
                return false;
            }

            // Validate Description
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Description is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DescriptionTextBox.Focus();
                return false;
            }

            // Validate Date
            if (DatePicker.SelectedDate == null)
            {
                MessageBox.Show("Date is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DatePicker.Focus();
                return false;
            }

            // Validate Latitude
            if (!double.TryParse(LatitudeTextBox.Text, out double latitude))
            {
                MessageBox.Show("Invalid Latitude. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LatitudeTextBox.Focus();
                return false;
            }

            // Validate Longitude
            if (!double.TryParse(LongitudeTextBox.Text, out double longitude))
            {
                MessageBox.Show("Invalid Longitude. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LongitudeTextBox.Focus();
                return false;
            }

            return true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Indicates that the user clicked Cancel
        }
    }
}
