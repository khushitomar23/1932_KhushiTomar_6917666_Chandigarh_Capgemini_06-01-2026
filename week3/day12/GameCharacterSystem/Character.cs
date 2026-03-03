using System;
using System.Collections.Generic;
using System.Text;

namespace GameCharacterSystem
{
    internal class Character
    {
        protected string name;
        protected int health;
        protected int level;

        public Character(string name)
        {
            this.name = name;
            health = 100;
            level = 1;
        }

        public virtual void Attack()
        {
            Console.WriteLine(name + " attacks the enemy!");
        }

        public void LevelUp()
        {
            level++;
            health += 20;
            Console.WriteLine(name + " leveled up to " + level);
        }

        public void ShowStatus()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Health: " + health);
        }
    }
}
