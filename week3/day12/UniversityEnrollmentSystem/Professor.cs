using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace UniversityEnrollmentSystem
{
    internal class Professor:Person
    {
        string subject;

        public Professor(int id, string name, string subject)
            : base(id, name)
        {
            this.subject = subject;
        }

        public void AssignCourse()
        {
            Console.WriteLine(name + " teaches " + subject);
        }
    }
}
