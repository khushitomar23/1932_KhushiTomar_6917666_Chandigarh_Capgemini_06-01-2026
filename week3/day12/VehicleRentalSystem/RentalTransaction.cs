using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleRentalSystem
{
    internal class RentalTransaction
    {
        Vehicle vehicle;
        Customer customer;
        int days;

        public RentalTransaction(Vehicle v, Customer c, int d)
        {
            vehicle = v;
            customer = c;
            days = d;
        }

        public void ShowBill()
        {
            customer.DisplayCustomer();
            vehicle.DisplayVehicle();
            Console.WriteLine("Days Rented: " + days);
            Console.WriteLine("Total Rent : " + vehicle.CalculateRent(days));
        }
    }
}
