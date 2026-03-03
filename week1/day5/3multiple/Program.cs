namespace _3multiple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 5, 7, 6, 9, 12 };
            int s = 6;
            int c = 0, i;
            for(i=0;i<s;i++)
            {
                if(a[i]<0)
                {
                    c = -1;
                }
                if (a[i] % 3 == 0)
                    c++;
            }
            Console.WriteLine(c);
            }
    }
}
