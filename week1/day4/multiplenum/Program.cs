namespace multiplenum
{
     class Program
    {
        static void Main(string[] args)
        {
            int s,i,output=1;
            Console.WriteLine("enter the size");
            s= Convert.ToInt32(Console.ReadLine());
            int[] a = new int[s];
            Console.WriteLine("enter the Array");
            for(i=0;i<s;i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            if(s<0)
            {
                output = -2;
            }
            else
            {
                for(i=0;i<s;i++)
                {
                    if (a[i]>0)
                    {
                        output =output*a[i];
                    }
                }
            }
            Console.WriteLine(output);

        }
    }
}
