using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHospitalProject
{
    class GovernmentHospital : Hospital
    {
        public override void GetDetails()
        {
            Console.WriteLine("Government Hospital");
            Console.WriteLine("Free treatment available");
        }

        public override void AdmitPatient()
        {
            Console.WriteLine("Patient admitted with free treatment");
        }
    }
}
