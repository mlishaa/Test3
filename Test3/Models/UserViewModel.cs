using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3.Models
{
  public  class UserViewModel
    {
        private UserDbContext context = new UserDbContext();
        private string fileName="Transaction.txt";

        public User CheckExistingUser(int id,string passWord)
        {
            User Existing = (from u in context.Users.Include("Account")
                             where u.Account.AccountID == id && u.PassWord == passWord
                             select u).SingleOrDefault();
            return Existing;
        }
        public List<User> GetCurrentUsers()
        {
            return (from us in context.Users.Include("Account")
                    select us).ToList();

        }

        public void AddNewUser(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public void DeleteUserByID(int id)
        {
            User userToBeDeleted = (from u in context.Users
                                where u.ID == id
                                select u).SingleOrDefault();
            Account accountTobeDeleted = GetAccountByUserID(id);

            context.Accounts.Remove(accountTobeDeleted);
            context.Users.Remove(userToBeDeleted);
            context.SaveChanges();
        }

        public Account GetAccountByUserID(int id)
        {
            return (from u in context.Users
                    where u.ID == id
                    select u.Account).SingleOrDefault();
        }

        public void UpdatedUser(User tobeUpdated)
        {
            User current = (from u in context.Users
                            where u.ID == tobeUpdated.ID
                            select u).SingleOrDefault();
            current.Name = tobeUpdated.Name;
            current.PassWord = tobeUpdated.PassWord;
            context.SaveChanges();

        }

        public void AddBalance(User sessionedUser, double amount)
        {       
           
                Account UserAddedbalance = (from u in context.Users
                                         where u.ID == sessionedUser.ID
                                         select u.Account).SingleOrDefault();
                UserAddedbalance.Balance += amount;
           
                context.SaveChanges();
            WriteLog(new Transaction(DateTime.Now, sessionedUser.Account.AccountID, 'D',
               sessionedUser.Account.Balance, UserAddedbalance.Balance));

        }

        public User GetUserByID(int id)
        {
            return (from u in context.Users
                            where u.ID == id
                            select u).SingleOrDefault();
        }

        public double GetBalance(User u)
        {
            return (from user in context.Users
                    where user.ID == u.ID
                    select user.Account.Balance).SingleOrDefault();
        }

        public void MinusBalance(User sessionedUser, double amount)
        {

            Account UserAddedbalance = (from u in context.Users
                                        where u.ID == sessionedUser.ID
                                        select u.Account).SingleOrDefault();
            UserAddedbalance.Balance -= amount;

            
            context.SaveChanges();
            WriteLog(new Transaction(DateTime.Now, sessionedUser.Account.AccountID, 'W',
               sessionedUser.Account.Balance, UserAddedbalance.Balance));

        }


        public void WriteLog(Transaction transaction)
        {
            try
            {

                using(StreamWriter sw =new StreamWriter(fileName,true))
                {
                    sw.WriteLine(transaction.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }


    }
}
