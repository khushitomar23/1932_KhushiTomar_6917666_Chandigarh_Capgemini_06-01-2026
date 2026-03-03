using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleRentalSystem
{
    internal class Vehicle
    {
        protected string vehicleNo;
        protected int ratePerDay;

        public Vehicle(string vno, int rate)
        {
            vehicleNo = vno;
            ratePerDay = rate;
        }

        public virtual int CalculateRent(int days)
        {
            return ratePerDay * days;
        }

        public void DisplayVehicle()
        {
            Console.WriteLine("Vehicle No : " + vehicleNo);
            Console.WriteLine("Rate/Day  : " + ratePerDay);
        }
    }
}
