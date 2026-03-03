namespace Date_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.ParseExact("12/02/2014", "dd/MM/yyyy", null);
            DateTime date2 = DateTime.ParseExact("27/02/2014", "dd/MM/yyyy", null);

            TimeSpan difference = date2 - date1;

            Console.WriteLine(difference.Days + " days");
        }
    }
}
