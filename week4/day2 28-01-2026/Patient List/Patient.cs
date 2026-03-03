using System;
using System.Collections.Generic;
using System.Text;

namespace Patient_List
{
     class Patient
    {
        private string name;
        private int age;
        private string _illness;
        private string city;
        public Patient()
        {
        }
        public Patient(string Name, int Age, string Illness, string City)
        {
            this.name = Name;
            this.age = Age;
            this._illness = Illness;
            this.city = City;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Illness
        {
            get
            {
                return _illness;
            }
            set
            {
                _illness = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0,-21}{1,-6}{2,-21}{3,-20}", this.name, this.age, this._illness, this.city);
        }
    }
}
