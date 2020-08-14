using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single checking account
    /// </summary>
    public class Account
    {

        /// <summary>
        /// Deposits the amount in the bank account and
        /// returns the new balance
        /// </summary>
        /// <param name="amt"></param>
        /// <returns></returns>
        public double Deposit(double amt)
        {
            if ( amt >= 10000)
            {
                throw new ArgumentException($"{nameof(amt)} must be less than $10,000");
            }

            if ( amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} must be a positive value");
            }
            Balance += amt;
            return Balance;
        }

        public double Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new ArgumentException($"{nameof(amt)} cannot be more than the balance");
            }

            if (amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} must be a positive value");
            }

            Balance -= amt;
            return Balance;
        }

        /// <summary>
        /// Get the current balance
        /// </summary>
        public double Balance { get; private set; }


    }
}
