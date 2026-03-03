namespace farenheittocelcius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int f,c;
            f = Convert.ToInt32(Console.ReadLine());
            if(f<0)
            {
                c = -1;
            }
            c = (f - 32) * 5 / 9;
            Console.WriteLine(c);
        }
    }
}
