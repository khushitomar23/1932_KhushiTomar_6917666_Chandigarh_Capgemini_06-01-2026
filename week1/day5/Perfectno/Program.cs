namespace Perfectno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, output = 0,i,sum=0;
            Console.WriteLine("enter the no");
            num=Convert.ToInt32(Console.ReadLine());
            if(num<0)
            {
                output = -1;
            }
            for(i=1;i<num;i++)
            {
                if(num%i==0)
                {
                    sum = sum + i;
                }
            }
            if(num==sum)
            {
                output = 1;
            }
            else
            {
                output = -2;
            }
            Console.WriteLine(output);
        }
    }
}
