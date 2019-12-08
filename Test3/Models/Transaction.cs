using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3.Models
{
   public class Transaction
    {
        public DateTime TransTime { get; set; }
        public int UserAccountID { get; set; }
        public Char KindOfTrans { get; set; }
        public double Before { get; set; }
        public double After { get; set; }


        public Transaction(DateTime _transTime,int _userId,Char _kindOfTrans,double _before,double _after)
        {
            this.TransTime = _transTime;
            this.UserAccountID = _userId;
            this.KindOfTrans = _kindOfTrans;
            this.Before = _before;
            this.After = _after;
        }

        public override string ToString()
        {
            return string.Format("{0,-12}  #{1,-4} |{2,-1}| {3,-10} {4,-10}",
                TransTime.ToString("yy-MM-dd")+TransTime.ToString("[hh:mm tt]"),
                UserAccountID, KindOfTrans, Before, After);
        }
    }
}
