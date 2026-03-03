namespace divisibleby3or5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num,output=0,digit,pro=1;
            Console.WriteLine("Enter the number");
            num = Convert.ToInt32(Console.ReadLine());
            if(num%3==0||num%5==0)
            {
                output = -2;
            }
            if (num < 0)
            {
                output = -1;
            }
            while(num>0)
            {
                digit = num % 10;
                pro = pro * digit;
                num = num / 10;
            }
            if(pro%3==0||pro%5==0)
            {
                output = 1;
            }
            Console.WriteLine(output);

        }
    }
}
