namespace armstrong
{
     class Arm
    {
        void Armstrong(int n)
        {
            int num, output1 = 1, digit, sum = 0;
            num = n;
            if (num < 0)
            {
                output1 = -1;
            }
            if (num > 999)
            {
                output1 = -2;
            }
            while (num > 0)
            {
                digit = num % 10;
                sum = sum + (digit * digit * digit);
                num = num / 10;

            }
            if (sum == n)
            {
                Console.WriteLine("Number is Armstrong " + n);
                output1 = 1;
            }
            else
            {
                Console.WriteLine("Number is not a Armstrong Number");
                output1 = 0;
            }
            Console.WriteLine(output1);
        }
        static void Main(string[] args)
        {
            Arm ob = new Arm();
          
            ob.Armstrong(153);
        }
    }
}
