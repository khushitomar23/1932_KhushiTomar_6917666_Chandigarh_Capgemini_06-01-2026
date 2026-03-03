using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter employee skills (space separated):");
        int[] skills = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Console.WriteLine("Enter team sizes (space separated):");
        int[] sizes = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Array.Sort(skills);
        Array.Sort(sizes);

        int left = 0;
        int right = skills.Length - 1;
        int totalStrength = 0;

        for (int i = 0; i < sizes.Length; i++)
        {
            int teamSize = sizes[i];

            int min = skills[left];
            int max = skills[right];

            totalStrength += (min + max);

            left += 1;
            right -= (teamSize - 1);
        }

        Console.WriteLine("Maximum Total Strength is: " + totalStrength);
    }
}
