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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {

        private UserViewModel repo = new UserViewModel();

        public AddUserWindow()
        {
            InitializeComponent();
        }

       

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateTheFields())
            {
                if(txtNewUserPassword.Text != txtConfirmPassword.Text)
                {
                    txtNewUserPassword.BorderBrush= new SolidColorBrush(Colors.Red);
                    txtConfirmPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Sorry Password doesn't match ", "Confirm password", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else {
                 txtNewUserPassword.BorderBrush = new SolidColorBrush(Colors.Green);
                 txtConfirmPassword.BorderBrush = new SolidColorBrush(Colors.Green);
                    
                 User myNewUser=  new User(){
                  Name=txtNewUserName.Text,
                  PassWord=txtNewUserPassword.Text,
                  Account=new Account()
                };
                    repo.AddNewUser(myNewUser);
                   
                    this.DialogResult = true;
                    
                
            
                }
            }
        }

        private bool ValidateTheFields()
        {
            if (string.IsNullOrEmpty(txtNewUserName.Text) || string.IsNullOrEmpty(txtNewUserPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("User name or password can't be empty", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearField();
                return false ;
            }
            // else if(!Char.IsLetter(txtNewUserName.Text, 0))
            //{
            //    MessageBox.Show("User name  can't start with non letter ", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error);
            //    txtNewUserName.BorderBrush = new SolidColorBrush(Colors.Red);
            //    return false;
            //}

            else
                return true;
        }

        public void ClearField()
        {
            txtNewUserName.Text = string.Empty;
            txtNewUserPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }
    }
}
