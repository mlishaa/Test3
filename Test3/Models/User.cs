using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Test3.Models
{
   public class User
    {
        private int _id;
        private string _name;
        private string _passWord;
        private Account _account;


        
        public int ID {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        [Required]
        [StringLength(50)]
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [Required]
        [StringLength(20)]
        public string PassWord { get => _passWord; 
            set =>_passWord=value; }


        public Account Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }
    }
}
