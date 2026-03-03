namespace repeatcount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s, i, num,c=0;
            Console.WriteLine("Enter the size");
            s = Convert.ToInt32(Console.ReadLine());
            if(s<0)
            {
                c = -2;
            }
            int[] a = new int[s];
            Console.WriteLine("Enter the array");
            for(i=0;i<s;i++)
            {
                a[i]= Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("Enter the num to be found");
            num = Convert.ToInt32(Console.ReadLine());
            for(i=0;i<s;i++)
            {
                if (a[i]<0)
                {
                    c = -1;
                }
                if(a[i]==num)
                {
                    c++;
                }
            }
            if(c==0)
            {
                c = -3;
            }
            Console.WriteLine(c);


        }
    }
}
