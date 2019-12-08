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
using Test3.Models;

namespace Test3
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private UserViewModel repo = new UserViewModel();
        public AdminWindow()
        {
            InitializeComponent();
            UpdateUsers();
        }

        public void UpdateUsers()
        {
            dgUsers.ItemsSource = repo.GetCurrentUsers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
            if (addUserWindow.DialogResult == true)
            {
                UpdateUsers();
            }
           
        }


        // delete an existing user
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (dgUsers.SelectedItem != null)
            {
                if (MessageBox.Show("Are you sure you want to delete " + (dgUsers.SelectedItem as User).Name.ToString(), "Confirmation",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    User userToDelete = dgUsers.SelectedItem as User;
                    int id = userToDelete.ID;
                    repo.DeleteUserByID(id);
                    UpdateUsers();

                }
                else
                    return;

            }
            else
                MessageBox.Show("Please select an user to delete ", "Deletion info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        // update current user
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(dgUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select an user to update ", "update info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                User tobeUpdated = dgUsers.SelectedItem as User;
                UserUpdateWindow userUpdateWindow = new UserUpdateWindow(tobeUpdated);
                userUpdateWindow.ShowDialog();
                if (userUpdateWindow.DialogResult == true)
                {
                    dgUsers.ItemsSource = repo.GetCurrentUsers();
                }
            }
        }
    }
}
