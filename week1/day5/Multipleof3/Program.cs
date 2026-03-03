namespace Multipleof3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, s, output = 0;
            Console.WriteLine("enter the size");
            s = Convert.ToInt32(Console.ReadLine());
            if (s < 0)
            {
                output = -2;
            }
            int[] arr = new int[s];
            for (i = 0; i < s; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < s; i++)
            {
                if (arr[i] < 0)
                {
                    output = -1;
                }
                if (arr[i] % 3 == 0)
                {
                    output++;
                }
            }
            Console.WriteLine("multiple of three are=" + output);
        }
    }
}
