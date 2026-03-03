namespace sumofcube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 5,output=0,i,j;

            if (num<0||num > 7)
            {
                output = -1;
            }
            for(i=1;i<=num;i++)
            {
                int c = 0;
                for (j = 1; j <= i; j++)
                {
                    if(i%j==0)
                    {
                        c++;
                    }
                    
                }
                if (c == 2)
                {
                    output = output + (i * i * i);
                }

            }
            Console.WriteLine(output);
        }
    }
}
