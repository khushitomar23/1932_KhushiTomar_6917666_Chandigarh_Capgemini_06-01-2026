namespace palindromenumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, rev=0,n,digit,output=0;
            Console.WriteLine("Enter the number");
            num = Convert.ToInt32(Console.ReadLine());
            n = num;
            if(num<0)
            {
                output = -1;
            }
            while(n>0)
            {
                digit = n % 10;
                rev = rev * 10 + digit;
                n = n / 10;
            }
            if(rev==num)
            {
                Console.WriteLine("Number is Palidrome" + num);
            }
            else
            {
                output = -2;
                Console.WriteLine("Number is not Palindrome" + num);
            }
            Console.WriteLine(output);
        }
    }
}
