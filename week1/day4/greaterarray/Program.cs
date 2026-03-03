namespace greaterarray
{
     class Program
    {
        void comparearray(int[] a, int[] b,int s)
        {
            int i;
            int[] output = new int[s];
            if(s<0)
            {
                output[0] = -2;
            }

            for(i = 0; i < s;i++)
            {
                if (a[i] < 0 || b[i]<0)
                {
                    output[0] = -1;
                }
                if (a[i] > b[i])
                {
                    output[i] = a[i];
                }
                else
                {
                    output[i] = b[i];
                }
            }
            foreach(int o in output)
            {
                Console.WriteLine(o);
            }

        }
        static void Main(string[] args)
        {
            int i, s;
            Program ob= new Program();
            int[] a = new int[50];
            int[] b = new int[50];
            Console.WriteLine("enter the size of array= ");
            s = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter first Array");
            for (i = 0; i < s; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter second array");
            for (i = 0; i < s; i++)
            {
                b[i] = Convert.ToInt32(Console.ReadLine());
            }
            ob.comparearray(a,b,s);
        }
    }
}
