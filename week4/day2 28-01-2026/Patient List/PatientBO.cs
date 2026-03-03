using System;
using System.Collections.Generic;
using System.Text;

namespace Patient_List
{
     class PatientBO
    {
        public void DisplayPatientDetails(List<Patient> patientList, string name)
        {
            List<Patient> p1 = (from p in patientList where p.Name == name select p).ToList();
            int le = p1.Count;
            if(le<0)
            {
                Console.WriteLine("Patient named {0} not found ", name);
            }
            else
            {
                Console.WriteLine("Name                Age      Illness         City");

                foreach (Patient x1 in p1)
                {
                    Console.WriteLine(x1.ToString());
                }
            }
        }
        public void DisplayYoungestPatientDetails(List<Patient> patientList)
        {
            int age = (from p in patientList select p.Age).Min();
            var x = from p in patientList where p.Age == age select p;
            Console.WriteLine("Name                Age      Illness         City");
            foreach(var x1 in x)
            {
                Console.WriteLine(x1.ToString());
            }

        }
        public void displayPatientsFromCity(List<Patient> patientList, string cname)
        {
            List<Patient> p1 = (from p in patientList where p.City == cname select p).ToList();
            int le = p1.Count;
            if(le<0)
            {
                Console.WriteLine("Patient named {0} not found ", cname);
            }
            else
            {
                Console.WriteLine("Name                Age      Illness         City");

                foreach (Patient x1 in p1)
                {
                    Console.WriteLine(x1.ToString());
                }


            }

        }
    }
}
