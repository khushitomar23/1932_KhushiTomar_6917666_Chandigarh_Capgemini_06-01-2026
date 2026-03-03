using System;

namespace GreeterLib
{
    public class Greeter : IGreeter
    {
        public void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}