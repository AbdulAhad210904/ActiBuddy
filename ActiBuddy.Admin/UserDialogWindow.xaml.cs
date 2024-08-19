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
using System.Windows;
using System;
using System.Windows;
using ActiBuddy.Data.Models;
using System.Text.RegularExpressions;

namespace ActiBuddy.Admin
{
    public partial class UserDialogWindow : Window
    {
        public User User { get; private set; }

        public UserDialogWindow(User user = null)
        {
            InitializeComponent();
            User = user;

            if (User != null)
            {
                // Populate fields with user data if editing
                UsernameTextBox.Text = User.Username;
                EmailTextBox.Text = User.Email;
                PhoneTextBox.Text = User.Phone;
                AddressTextBox.Text = User.Address;
                PasswordBox.Password = User.PasswordHash;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                if (User == null)
                {
                    User = new User
                    {
                        Username = UsernameTextBox.Text,
                        Email = EmailTextBox.Text,
                        Phone = PhoneTextBox.Text,
                        Address = AddressTextBox.Text,
                        PasswordHash = PasswordBox.Password
                    };
                }
                else
                {
                    User.Username = UsernameTextBox.Text;
                    User.Email = EmailTextBox.Text;
                    User.Phone = PhoneTextBox.Text;
                    User.Address = AddressTextBox.Text;
                    User.PasswordHash = PasswordBox.Password;
                }

                DialogResult = true; // Indicates that the user clicked Save
            }
        }

        private bool ValidateForm()
        {
            // Validate Username
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                UsernameTextBox.Focus();
                return false;
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || !IsValidEmail(EmailTextBox.Text))
            {
                MessageBox.Show("A valid email is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                EmailTextBox.Focus();
                return false;
            }

            // Validate Phone
            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text) || !IsValidPhoneNumber(PhoneTextBox.Text))
            {
                MessageBox.Show("A valid phone number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                PhoneTextBox.Focus();
                return false;
            }

            // Validate Address
            if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                AddressTextBox.Focus();
                return false;
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                PasswordBox.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Basic phone number validation (adjust as needed)
            return Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Indicates that the user clicked Cancel
        }
    }
}
