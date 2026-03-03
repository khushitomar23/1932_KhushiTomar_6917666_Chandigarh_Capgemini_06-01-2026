namespace interfaceexample
{
    interface inter1
    {
        void f1();
    }
    interface inter2
    {
        void f1();
    }
    class C3:inter1, inter2
    {
        void inter1.f1()
        {
            Console.WriteLine("this is overriding function of inter1 and inter2 interfaces");
        }
         void inter2.f1()
        {
            Console.WriteLine("this is overriding function of inter1 and inter2 interfaces....");
        }
    }
    class interexample
    {
        static void Main(string[] args)
        {
            C3 ob=new C3();
            inter1 obj = (inter1)ob;
            inter2 obj2 = (inter2)ob;
            obj.f1();
            obj2.f1();
        }
    }
}
