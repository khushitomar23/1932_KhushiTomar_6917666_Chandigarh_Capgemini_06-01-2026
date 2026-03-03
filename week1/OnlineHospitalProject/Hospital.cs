using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHospitalProject
{
    class Record<T>
    {
        public T value;

        public void Show()
        {
            Console.WriteLine("Stored Record: " + value);
        }
    }
    enum PatientType
    {
        General,
        Emergency,
        OPD
    }
    struct Patient
    {
        public int Id;
        public string Name;
        public int Age;
        public PatientType Type;
    }
    abstract class Hospital
    {
        public string HospitalName, location;
       public abstract void GetDetails();
       public abstract void AdmitPatient();
    }
}
