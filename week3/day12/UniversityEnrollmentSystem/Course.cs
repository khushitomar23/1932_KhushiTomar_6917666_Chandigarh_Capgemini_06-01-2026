using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
    internal class Course
    {
        public string courseName;

        public Course(string cname)
        {
            courseName = cname;
        }

        public void DisplayCourse()
        {
            Console.WriteLine("Course Name: " + courseName);
        }
    }
}
