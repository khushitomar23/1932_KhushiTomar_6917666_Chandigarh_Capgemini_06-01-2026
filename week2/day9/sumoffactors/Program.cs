namespace sumoffactors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, num,i,sum=0;
            Console.WriteLine("enter the number");
            n = Convert.ToInt32(Console.ReadLine());
            if(n<0)
            {
                sum = -1;
            }
            Console.WriteLine("Enter the finish point");
            num= Convert.ToInt32(Console.ReadLine());
            if(num>32627)
            {
                sum = -2;
            }
            for(i=0;i<=num;i++)
            {
                if(i%n==0)
                {
                    sum = sum + i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
