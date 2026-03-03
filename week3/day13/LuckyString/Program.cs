namespace LuckyString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();

            if (n > str.Length)
            {
                Console.WriteLine("Invalid");
                return;
            }

            int half = n / 2;

            for (int i = 0; i <= str.Length - n; i++)
            {
                string sub = str.Substring(i, n);

                bool validChars = true;
                foreach (char c in sub)
                {
                    if (c != 'P' && c != 'S' && c != 'G')
                    {
                        validChars = false;
                        break;
                    }
                }

                if (!validChars)
                    continue;

                int count = 1;
                for (int j = 1; j < sub.Length; j++)
                {
                    if (sub[j] == sub[j - 1])
                    {
                        count++;
                        if (count >= half)
                        {
                            Console.WriteLine("Yes");
                            return;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }

            Console.WriteLine("No");
        }
    }
}
