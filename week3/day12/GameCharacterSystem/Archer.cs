using System;
using System.Collections.Generic;
using System.Text;

namespace GameCharacterSystem
{
    internal class Archer:Character
    {
        public Archer(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine(name + " shoots an arrow!");
        }
    }
}
