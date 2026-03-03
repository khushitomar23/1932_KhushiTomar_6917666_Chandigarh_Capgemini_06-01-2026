namespace EmployeeDesignation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of Entries: ");
            int n = int.Parse(Console.ReadLine());

            string[] input1 = new string[n];
            Console.WriteLine("enetr emp detail:");
            for(int i = 0; i < n; i++)
            {
                input1[i] = Console.ReadLine();
            }
            Console.WriteLine("Enter a designation: ");
            string deg = Console.ReadLine();

            string[] result = UserProgramCode.getEmployee(input1, deg);
            foreach(string s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
