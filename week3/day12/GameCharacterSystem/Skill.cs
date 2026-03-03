using System;
using System.Collections.Generic;
using System.Text;

namespace GameCharacterSystem
{
    internal class Skill
    {
        string skillName;

        public Skill(string skillName)
        {
            this.skillName = skillName;
        }

        public void UseSkill()
        {
            Console.WriteLine("Using skill: " + skillName);
        }
    }
}
