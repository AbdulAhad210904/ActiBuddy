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


namespace ActiBuddy.Admin
{
    public partial class UserManagementWindow : Window
    {
        private readonly UserRepository _userRepository;

        public UserManagementWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new DatabaseContext());
            LoadUsers();
        }

        private void LoadUsers()
        {
            List<User> users = _userRepository.GetAllUsers().ToList();
            UsersDataGrid.ItemsSource = users;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var userDialog = new UserDialogWindow();
            if (userDialog.ShowDialog() == true)
            {
                var newUser = userDialog.User;
                _userRepository.AddUser(newUser);
                LoadUsers();
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is User selectedUser)
            {
                var userDialog = new UserDialogWindow(selectedUser);
                if (userDialog.ShowDialog() == true)
                {
                    var updatedUser = userDialog.User;
                    _userRepository.UpdateUser(updatedUser);
                    LoadUsers();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is User selectedUser)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _userRepository.DeleteUser(selectedUser.UserId);
                    LoadUsers();
                }
            }
        }

    }
}



