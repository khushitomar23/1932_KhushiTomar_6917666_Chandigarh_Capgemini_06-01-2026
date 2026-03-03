namespace Product_Sales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productId = new string[100];
            int[] sales = new int[100];
            int count = 0;

            Console.WriteLine("Enter product records (empty line to stop):");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "") break;

                string[] parts = input.Split('-');
                string id = parts[0];
                int sale = int.Parse(parts[1]);

                bool found = false;

                
                for (int i = 0; i < count; i++)
                {
                    if (productId[i] == id)
                    {
                        if (sale > sales[i])   
                            sales[i] = sale;

                        found = true;
                        break;
                    }
                }

               
                if (!found)
                {
                    productId[count] = id;
                    sales[count] = sale;
                    count++;
                }
            }

            
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (sales[i] < sales[j])
                    {
                        
                        int tempSale = sales[i];
                        sales[i] = sales[j];
                        sales[j] = tempSale;

                       
                        string tempId = productId[i];
                        productId[i] = productId[j];
                        productId[j] = tempId;
                    }
                }
            }

            Console.WriteLine("Result is:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(productId[i] + "-" + sales[i]);
            }
        }
    }
}
