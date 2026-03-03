using System;
using System.Collections.Generic;
using System.Text;

namespace GameCharacterSystem
{
    internal class Warrior:Character
    {
        public Warrior(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine(name + " swings a sword!");
        }
    }
}
