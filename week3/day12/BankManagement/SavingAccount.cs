using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BankManagement
{
    internal class SavingAccount : Account
    {
        private int rate = 3;
        public SavingAccount(int accNo, string name, int bal) : base(accNo, name, bal)
        {

        }

        public void CalculateInterest()
        {
            int interest = (balance * rate) / 100;
            balance += interest;
            Console.WriteLine("Interest added: " + interest);
        }
    }
}
