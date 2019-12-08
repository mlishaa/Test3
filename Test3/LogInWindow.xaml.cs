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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private UserViewModel repo = new UserViewModel();
        public User ExistingUser;
        public LogInWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }
       

        public void CheckUserIDPSW()
        {
            int id;
          
           if (int.TryParse(txtUserIDLogIn.Text.ToString(), out id))
             {
                    ExistingUser = repo.CheckExistingUser(id, txtUserPSWLogIn.Text);

                if ((ExistingUser == null))
                {
                    MessageBox.Show("Invalid UserID or Password,please try again", "Invalid login", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if ((ExistingUser.Account.AccountID == 1) && (ExistingUser.PassWord == "01234567"))
                {
                    MessageBox.Show("Welcome " + ExistingUser.Name, "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.DialogResult = false;
                }
                else if ((ExistingUser != null))
                {
                    MessageBox.Show("Welcome " + ExistingUser.Name, "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    this.DialogResult = true;
                }
                else
                    return;

               

            }
                else
                {
                    MessageBox.Show("Sorry, ID should be digits", "Invalid ID", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

               
            
           
        }

        private void btnUserLognIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserIDLogIn.Text) || string.IsNullOrEmpty(txtUserPSWLogIn.Text) )
            {
                MessageBox.Show("User name or password can't be empty", "Invalid credientials", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            else
                CheckUserIDPSW();

        }
    }
}
