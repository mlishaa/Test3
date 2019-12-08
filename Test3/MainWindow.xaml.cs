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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test3.Models;

namespace Test3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User sessionedUser= new User();
        private UserViewModel repo = new UserViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DimFields();
            
        }

        public void DimFields()
        {
            txtAmount.IsEnabled = false;
            txtAmount.Text = string.Empty;
            txtBalance.IsEnabled = false;
            txtBalance.Text = string.Empty;
            btnWithdraw.IsEnabled = false;
            btnDeposit.IsEnabled = false;
            btnLog.Visibility = Visibility.Visible;
            btnLogOut.Visibility = Visibility.Hidden;
        }
        // show login window and ask for result
        public void btnLog_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow logUserPswWindow = new LogInWindow();
            logUserPswWindow.ShowDialog();
            if (logUserPswWindow.DialogResult == true)
            {
               
                UnDimFields();               
                sessionedUser = logUserPswWindow.ExistingUser;
              //  MessageBox.Show(sessionedUser.Name);
                UpdateBalance(sessionedUser);
                UpdateFormInfo(sessionedUser);

            }
        }

        private void UpdateFormInfo(User userInfo)
        {
            txtBlockUserID.Text += userInfo.ID;
            txtBlockUserName.Text += userInfo.Name;
        }

        private void UpdateBalance(User user)
        {
            int id = user.ID;

            txtBalance.Text = repo.GetBalance(user).ToString("c2");
            sessionedUser.Account.Balance = repo.GetBalance(user);
            txtAmount.Text = string.Empty;
            
        }
       

        public void UnDimFields()
        {
            txtAmount.IsEnabled = true;
           // txtBalance.IsEnabled = true;
            btnWithdraw.IsEnabled = true;
            btnDeposit.IsEnabled = true;
            btnLog.Visibility = Visibility.Hidden;
            btnLogOut.Visibility = Visibility.Visible;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            DimFields();
            sessionedUser = null;
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            
            double toDeposit;
            if(txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Please enter an amount to deposit", "Amount not valid", MessageBoxButton.OK, MessageBoxImage.Information);                
            }
            else if(double.TryParse(txtAmount.Text.ToString(),out toDeposit)==false)
            {
                MessageBox.Show("Sorry, it's not a valid money amount", "Amount not valid", MessageBoxButton.OK, MessageBoxImage.Information);               
            }
            else
            {
                repo.AddBalance(sessionedUser, toDeposit);
                UpdateBalance(sessionedUser);                
            }

        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            
            double ToWithDraw;
            if (txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Please enter an amount to deposit", "Amount not valid", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           else  if (double.TryParse(txtAmount.Text.ToString(), out ToWithDraw) == false)
            {
                MessageBox.Show("Sorry, it's not a valid money amount", "Amount not valid", MessageBoxButton.OK, MessageBoxImage.Information);

            }
           else  if (ToWithDraw > sessionedUser.Account.Balance )
            {
                MessageBox.Show("Sorry, "+ sessionedUser.Name +@" you can't withdraw more than "+
                    sessionedUser.Account.Balance.ToString("c2"),
                    "Amount not valid", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                repo.MinusBalance(sessionedUser, ToWithDraw);
                UpdateBalance(sessionedUser);
            }
        }
    }
}
