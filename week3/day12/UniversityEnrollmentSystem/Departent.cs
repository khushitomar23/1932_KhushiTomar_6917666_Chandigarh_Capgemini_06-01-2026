using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
    internal class Departent
    {
        public string deptName;

        public Departent(string dname)
        {
            deptName = dname;
        }

        public void DisplayDepartment()
        {
            Console.WriteLine("Department: " + deptName);
        }
    }
}
