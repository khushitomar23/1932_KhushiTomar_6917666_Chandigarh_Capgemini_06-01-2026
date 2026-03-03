using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    internal class MedicalRecord
    {
        string diagnosis;

        public MedicalRecord(string diagnosis)
        {
            this.diagnosis = diagnosis;
        }

        public void ShowRecord()
        {
            Console.WriteLine("Medical History: " + diagnosis);
        }
    }
}
