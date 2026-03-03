using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
    internal class Staff:Person
    {
        string department;

        public Staff(int id, string name, string department)
            : base(id, name)
        {
            this.department = department;
        }
    }
}
