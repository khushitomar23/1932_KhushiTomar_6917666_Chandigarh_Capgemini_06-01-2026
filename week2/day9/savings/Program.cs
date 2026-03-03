namespace savings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalsalary, days,output,saving;
            Console.WriteLine("Enter the totalsalary");
            totalsalary=Convert.ToInt32(Console.ReadLine());
            if(totalsalary<0)
            {
                output = -2;
            }
            if(totalsalary>9000)
            {
                output= - 1;
            }
            Console.WriteLine("Enter the working days in a month ");
            days = Convert.ToInt32(Console.ReadLine());
            if(days<0)
            {
                output = -4;
            }
            if(days>30)
            {
                totalsalary = totalsalary + 500;
            }
            saving = (totalsalary * 50) / 100 + (totalsalary * 20) / 100;
            output = totalsalary - saving;
            Console.WriteLine(output);

        }
    }
}
