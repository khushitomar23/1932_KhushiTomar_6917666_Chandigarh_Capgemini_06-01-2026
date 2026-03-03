using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    internal class Patient:Person
    {
        public Patient(int id, string name) : base(id, name) { }

        public override void Display()
        {
            Console.WriteLine("Patient Details");
            base.Display();
        }
    }
}
