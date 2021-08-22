using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.ViewModel
{
    public class MortgageCalculator
    {
        public MortgageCalculator(int month, double payment, double interest, double balance)
        {
            this.Month = month;
            this.Payment = payment;
            this.Interest = interest;
            this.Balance = balance;
        }

        public int Month { get; set; }
        public double Payment { get; set; }
        public double Interest { get; set; }
        public double Balance { get; set; }
    }
}
