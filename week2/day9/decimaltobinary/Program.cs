namespace decimaltobinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 15;
            int[] binary = new int[20];   
            int i = 0;

            if (num < 0)
            {
                Console.WriteLine(-1);
                return;
            }

            while (num > 0)
            {
                binary[i] = num % 2;
                num = num / 2;
                i++;
            }

            for (int j = i - 1; j >= 0; j--)
            {
                Console.Write(binary[j] + " ");
            }
        }
    }
}
