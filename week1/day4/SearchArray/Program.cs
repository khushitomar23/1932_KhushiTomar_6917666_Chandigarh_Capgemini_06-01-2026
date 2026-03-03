namespace SearchArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s,n,i,output=0;
            Console.WriteLine("Enter the Size");
            s = Convert.ToInt32(Console.ReadLine());
            if(s<0)
            {
                output = -2;
            }
            Console.WriteLine("Enter the Array");
            int[] a = new int[s];
            for(i=0;i<s;i++)
            {
                a[i]=Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter the number to be search");
            n = Convert.ToInt32(Console.ReadLine());
            for(i=0;i<s;i++)
            {
                if (a[i]<0)
                {
                    output = -1;
                }
                if (a[i]==n)
                {
                    output = i;
                }
            }
            Console.WriteLine(output);

        }
    }
}
