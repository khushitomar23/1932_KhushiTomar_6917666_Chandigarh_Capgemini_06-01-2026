namespace halfdescendinghalfascending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s,i,mid;
            Console.WriteLine("Enter the size");
            s = Convert.ToInt32(Console.ReadLine());
            if (s < 0)
            {
                Console.WriteLine(-1);
            }
            mid = s / 2;
            int[] a = new int[s];
            Console.WriteLine("Enter the array");
            for (i = 0; i < s; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());

            }
            Array.Sort(a);
            Array.Reverse(a, mid, s-mid);
            foreach(int o in a )
            {
                Console.WriteLine(o);
            }
        }
    }
}
