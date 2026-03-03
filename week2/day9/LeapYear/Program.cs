namespace LeapYear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year;
            Console.WriteLine("Enter the year");
            year=Convert.ToInt32(Console.ReadLine());
            if(year%400==0||year%4==0&&yaer%100!=0)
            {
                Console.WriteLine("it is a leap year");

            }
            else
            {
                Console.WriteLine("not a leap year");
            }
        }
    }
}
