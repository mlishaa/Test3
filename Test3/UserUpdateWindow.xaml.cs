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
    /// Interaction logic for UserUpdateWindow.xaml
    /// </summary>
    public partial class UserUpdateWindow : Window
    {
        UserViewModel repo = new UserViewModel();
        User currentToUpdate;
        public UserUpdateWindow()
        {
            InitializeComponent();
        }

        public UserUpdateWindow(User UpdatedUser)
        {
            currentToUpdate = UpdatedUser;
            InitializeComponent();
            LoadUpdatedUser(UpdatedUser);
           
        }


        public void LoadUpdatedUser(User updated)
        {
            txtBlockAccountID.Text += updated.Account.AccountID;
            txtBlockID.Text += updated.ID;

        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateCurrentUser(currentToUpdate);
        }


        private void updateCurrentUser(User updated)
        {

            if (ValidateUpdateForm())
            {
                if (txtUpdatedPassword.Text != txtConfirmUpdatedPassword.Text)
                {
                    txtUpdatedPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtConfirmUpdatedPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Sorry Password doesn't match ", "Confirm password", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    txtUpdatedPassword.BorderBrush = new SolidColorBrush(Colors.Green);
                    txtConfirmUpdatedPassword.BorderBrush = new SolidColorBrush(Colors.Green);
                    updated.Name = txtUpdateName.Text;
                    updated.PassWord = txtUpdatedPassword.Text;
                    repo.UpdatedUser(updated);
                    this.DialogResult = true;
                }

            }
        }

        private bool ValidateUpdateForm()
        {
            if (string.IsNullOrEmpty(txtUpdateName.Text) || string.IsNullOrEmpty(txtUpdatedPassword.Text) || string.IsNullOrEmpty(txtConfirmUpdatedPassword.Text))
            {
                MessageBox.Show("User name or password can't be empty", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearField();
                return false;
            }
            else
                return true;
        }

        private void ClearField()
        {
            txtUpdateName.Text = string.Empty;
            txtUpdatedPassword.Text = string.Empty;
            txtConfirmUpdatedPassword.Text = string.Empty;
        }
    }
}
