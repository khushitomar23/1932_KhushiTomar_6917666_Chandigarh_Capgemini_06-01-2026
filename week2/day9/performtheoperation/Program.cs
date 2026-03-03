namespace performtheoperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1, input2, output=0, choice;
            Console.WriteLine("Enter input1 and input2");
            input1 = Convert.ToInt32(Console.ReadLine());
            input2 = Convert.ToInt32(Console.ReadLine());
            if (input1 < 0 || input2 < 0)
            {
                output = -1;
            }
            Console.WriteLine("Enter the choice from 1 to 4");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        output = input1 + input2;
                        break;
                    }
                case 2:
                    {
                        output = input1 - input2;
                        break;
                    }
                case 3:
                    {
                        output = input1 * input2;
                        break;
                    }
                case 4:
                    {
                        output = input1 / input2;
                        break;
                    }
            }
            Console.WriteLine(output);
        }
    }
}

