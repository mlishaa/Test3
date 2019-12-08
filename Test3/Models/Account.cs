using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Test3.Models
{
   public class Account
    {
        private int _accountID;
        private double _balance;

        [Key]
        public int AccountID {
            get
            {
                return _accountID;
            }
            set 
            {
                _accountID = value;
            }
        }

        public double Balance {
            get
            {
                return _balance;
            }
            set 
            {
                _balance = value;
            }
        }
    }
}
