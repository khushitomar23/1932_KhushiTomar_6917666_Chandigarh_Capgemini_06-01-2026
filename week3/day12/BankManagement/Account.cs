using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement
{
    internal class Account
    {
        private int accountNum;
        private string accountHolder;
        protected int balance;

        public Account(int accNo, string name, int bal)
        {
            accountNum = accNo;
            accountHolder = name;
            balance = bal;
        }

        public void Deposit(int amt)
        {
            if (amt > 0)
            {
                balance += amt;
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        public void Display()
        {
            Console.WriteLine("Account Number: " + accountNum);
            Console.WriteLine("Account Holder: " + accountHolder);
            Console.WriteLine("Bank Balance: " + balance);
        }

        public virtual void Withdraw(int amt)
        {
            if (amt > 0 && amt <= balance)
            {
                balance -= amt;
                Console.WriteLine("Withdrwal sucessful.");
            }
            else
            {
                Console.WriteLine("Insufficent Balance.");
            }
        }
    }
}
