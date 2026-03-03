using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    internal class Appointment
    {
        Patient patient;
        Doctor doctor;
        string date;

        public Appointment(Patient p, Doctor d, string date)
        {
            patient = p;
            doctor = d;
            this.date = date;
        }

        public void ShowAppointment()
        {
            Console.WriteLine("\nAppointment Details");
            Console.WriteLine("Date: " + date);
            patient.Display();
            doctor.Display();
        }
    }
}
