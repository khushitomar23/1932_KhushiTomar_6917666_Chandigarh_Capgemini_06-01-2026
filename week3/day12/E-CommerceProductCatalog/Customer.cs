using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceProductCatalog
{
    internal class Customer
    {
        public string customerName;

        public Customer(string name)
        {
            customerName = name;
        }

        public void DisplayCustomer()
        {
            Console.WriteLine("Customer: " + customerName);
        }
    }
}
