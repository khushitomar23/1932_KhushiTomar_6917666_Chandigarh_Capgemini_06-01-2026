namespace most_repeated
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s,max=0,i,j;
            Console.WriteLine("Enter the Size");
            s = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Array");
            int[] a = new int[s];
            for (i = 0; i < s; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(i=0; i < s;i++)
            {
                int c = 0;
                for(j=i+1;j<s;j++)
                {
                    if (a[i] == a[j])
                        c++;
                }
                if(c>max)
                {
                    max = c;
                }
            }
            for (i = 0; i < s; i++)
            {
                int c = 0;
                for(j=i+1; j<s;j++)
                {
                    if (a[i] == a[j])
                        c++;
                }
                if(c==max)
                {
                    Console.WriteLine(a[i]+" ");
                }
            }
        }
    }
}
