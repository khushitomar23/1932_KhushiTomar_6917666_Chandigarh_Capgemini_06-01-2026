namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
			var s = new Student();
			s.Name = "John";
			Console.WriteLine(s.Name); // John
		}
    }
}
