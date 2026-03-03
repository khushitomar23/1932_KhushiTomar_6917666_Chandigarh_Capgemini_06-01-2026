using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    internal class Person
    {
        protected int id;
        protected string name;

        public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine("ID   : " + id);
            Console.WriteLine("Name : " + name);
        }
    }
}
