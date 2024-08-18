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
using ActiBuddy.Data.Models;

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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Indicates that the user clicked Cancel
        }
    }
}
