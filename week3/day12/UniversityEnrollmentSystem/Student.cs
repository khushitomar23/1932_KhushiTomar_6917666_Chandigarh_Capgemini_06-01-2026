using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
    internal class Student : Person
    {
        string course;

        public Student(int id, string name, string course)
            : base(id, name)
        {
            this.course = course;
        }

        public void ViewSchedule()
        {
            Console.WriteLine("Enrolled Course: " + course);
        }
    }
}
