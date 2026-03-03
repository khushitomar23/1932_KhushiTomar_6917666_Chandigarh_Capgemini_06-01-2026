using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    internal class Doctor:Person
    {
        string specialization;

        public Doctor(int id, string name, string specialization)
            : base(id, name)
        {
            this.specialization = specialization;
        }

        public override void Display()
        {
            Console.WriteLine("Doctor Details");
            base.Display();
            Console.WriteLine("Specialization: " + specialization);
        }
    }
}
