using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BankManagement
{
    internal class CheckingAccount : Account
    {
        public CheckingAccount(int accNo, string name, int bal) :
    base(accNo, name, bal)
        {

        }

        public override void Withdraw(int amt)
        {
            if (amt > 0 && balance >= amt)
            {
                balance -= amt;
                Console.WriteLine("Withdrwal succesfull.");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
    }
}
