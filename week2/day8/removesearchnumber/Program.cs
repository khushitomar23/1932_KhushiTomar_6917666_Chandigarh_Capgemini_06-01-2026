namespace removesearchnumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s,i,k=0,n;
            Console.WriteLine("enter the size");
            s=Convert.ToInt32(Console.ReadLine());
            int[] a=new int[s];
            int[] output=new int[s];
            if(s<0)
            {
                output[0] = -2;
            }
            for(i=0;i<s;i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
                if (a[i]<0)
                {
                    output[0] = -1;
                }
            }
            Console.WriteLine("enter the number to be searched");
            n = Convert.ToInt32(Console.ReadLine());
            for(i=0;i<s;i++)
            {
                if (a[i]!=n)
                {
                    output[k] = a[i];
                    k++;
                }
            }
            Array.Sort(output, 0, k);
            for(i=0;i<k;i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
