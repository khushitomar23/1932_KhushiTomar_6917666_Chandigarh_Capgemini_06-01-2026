namespace removenegative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = {40,-10,38,20};
            int s=a.Length,i,k=0;
            int[] output = new int[s];
            if(s<0)
            {
                output[0] = -1;
            }

            for (i = 0; i < s; i++)
            {
                if (a[i]>0)
                {
                    output[k] = a[i];
                    k++;
                    
                }
            }
            Array.Sort(output,0,k);
            for(i=0;i<k;i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
