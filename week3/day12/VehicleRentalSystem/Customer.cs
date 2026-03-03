using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleRentalSystem
{
    internal class Customer
    {
        public string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public void DisplayCustomer()
        {
            Console.WriteLine("Customer Name: " + name);
        }
    }
}
