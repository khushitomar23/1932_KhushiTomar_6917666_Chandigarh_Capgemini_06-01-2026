namespace timesinrupees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amt;
            Console.WriteLine("enter the amount");
            amt = Convert.ToInt32(Console.ReadLine());
            int count = 0;

            if (amt < 0)
            {
                Console.WriteLine(-1);
                return;
            }

            count = count+amt / 500;
            amt =amt% 500;
            count =count+ amt / 100; 
            amt =amt% 100;
            count =count+ amt / 50; 
            amt =amt%50;
            count =count+ amt / 10; 
            amt =amt% 10;
            count = count+amt / 1;

            Console.WriteLine(count);
        }
    }
}
