namespace Delegate
{
    public delegate void Math(int x, int y);
     class Program
    {
        public void add(int x,int y)
        {
            Console.WriteLine("add=" + (x + y));
        }
        public void sub(int x, int y)
        {
            Console.WriteLine("sub=" + (x - y));
        }
        public void mul(int x, int y)
        {
            Console.WriteLine("Mul=" + (x * y));
        }
        public void div(int x, int y)
        {
            Console.WriteLine("Div=" + (x / y));
        }
        static void Main(string[] args)
        {
            Program ob=new Program();
            Math m = new Math(ob.add);
            m += ob.sub;
            m += ob.mul;
            m += ob.div;
            m(100, 50);
            Console.WriteLine();
            m(450, 70);
            Console.WriteLine();
            m -= ob.div;
            m(625, 25);
            Console.ReadLine();

        }
    }
}
