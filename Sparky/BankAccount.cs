using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        public int balance { get; set; }
        private readonly ILogBook logBook;
        public BankAccount(ILogBook logBook)
        {
            this.logBook = logBook;
            balance = 0;
        }
        public bool Deposit(int amount)
        {
            logBook.Message("Deposit invoked");
            logBook.Message("");
            balance += amount;
            return true;
        }
        public bool Withdraw(int amount)
        {
            if(amount <= balance)
            {
                logBook.LogToDb("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                return logBook.LogBalanceAfterWithdrawal(balance);
            }
            return logBook.LogBalanceAfterWithdrawal(balance - amount);
            return false;
        }
        public int GetBalance()
        {
            return balance;
        }
    }
}
