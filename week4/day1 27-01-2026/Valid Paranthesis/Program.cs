namespace Valid_Paranthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string s = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (char ch in s)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    char top = stack.Pop();

                    if ((ch == ')' && top != '(') ||
                        (ch == ']' && top != '[') ||
                        (ch == '}' && top != '{'))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0)
                isValid = false;

            Console.WriteLine(isValid ? "YES" : "NO");

        }
    }
}
