namespace Integer_List_Descending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements");
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> arr = new List<int>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("Enter the number below which elements need to be displayed");
            int input2 = Convert.ToInt32(Console.ReadLine());
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] < input2)
                {
                    result.Add(arr[i]);
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine("No element found");
                return;
            }

            result.Sort();
            result.Reverse();

            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
