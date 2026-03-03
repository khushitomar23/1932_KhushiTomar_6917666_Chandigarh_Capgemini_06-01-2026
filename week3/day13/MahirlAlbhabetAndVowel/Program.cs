namespace MahirlAlbhabetAndVowel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            string temp = "";

            for (int i = 0; i < s1.Length; i++)
            {
                char c = char.ToLower(s1[i]);
                bool isVowel = (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
                bool found = false;

                for (int j = 0; j < s2.Length; j++)
                {
                    if (c == char.ToLower(s2[j]))
                    {
                        found = true;
                        break;
                    }
                }

                if (isVowel || !found)
                {
                    temp = temp + s1[i];
                }
            }

            string result = "";
            result = result + temp[0];

            for (int i = 1; i < temp.Length; i++)
            {
                if (char.ToLower(temp[i]) != char.ToLower(temp[i - 1]))
                {
                    result = result + temp[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}
