namespace firsttolast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 4, 5, 2, 6, 1 };
            int s = 5,i;
            if(s<0)
            {
                a[0] = -2;
            }
            if (s % 2 == 0)
            {
                a[0] = -3;
            }
            for(i=0;i<s;i++)
            {
                if (a[i]<0)
                {
                    a[0] = -1;
                }
            }
            int mid = s / 2;
            for(i=0;i<mid;i++)
            {
                int temp = a[i];
                a[i] = a[s - i - 1];
                a[s - i - 1] = temp;

            }
            foreach(int o in a)
            {
                Console.WriteLine(o);
            }
           

        }
    }
}
