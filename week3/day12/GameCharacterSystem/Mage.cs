using System;
using System.Collections.Generic;
using System.Text;

namespace GameCharacterSystem
{
    internal class Mage:Character
    {
        public Mage(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine(name + " casts a fireball!");
        }
    }
}
