namespace sumofsquareofodddigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num,digit,sum=0;
            Console.WriteLine("Enter the number");
            num=Convert.ToInt32(Console.ReadLine());
            if(num<0)
            {
                sum = -1;
            }
            while(num>0)
            {
                digit = num % 10;
                if(digit%2!=0)
                {
                    sum = sum+(digit * digit);
                }
                num = num / 10;
            }
            Console.WriteLine(sum);

        }
    }
}
