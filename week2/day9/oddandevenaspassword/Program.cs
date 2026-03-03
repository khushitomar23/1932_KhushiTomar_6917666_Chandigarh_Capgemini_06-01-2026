namespace oddandevenaspassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumodd = 0, i,s,avg,sumeven=0;
            Console.WriteLine("Enter the size");
            s=Convert.ToInt32(Console.ReadLine());
            if(s<0)
            {
                avg = -1;
            }
            int[] a = new int[s];
            for(i=0;i<s;i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
                if (a[i]<0)
                {
                    avg = -2;
                }

                if (a[i] % 2 == 0)
                {
                    sumeven = sumeven + a[i];
                }
                else
                {
                    sumodd=sumodd + a[i];
                }
            }
            avg = (sumeven + sumodd) / 2;
            Console.WriteLine(avg);

        }
    }
}
