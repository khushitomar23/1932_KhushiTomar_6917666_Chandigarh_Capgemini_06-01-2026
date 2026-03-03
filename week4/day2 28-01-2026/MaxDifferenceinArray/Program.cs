using System;

class UserProgramCode
{
    public static int diffIntArray(int[] input1)
    {
        int n = input1.Length;

        if (n <= 1 || n > 10)
            return -2;

        for (int i = 0; i < n; i++)
        {
            if (input1[i] < 0)
                return -1;
        }

       
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (input1[i] == input1[j])
                    return -3;
            }
        }

        int min = input1[0];
        int maxDiff = 0;

        for (int i = 1; i < n; i++)
        {
            if (input1[i] > min)
            {
                int diff = input1[i] - min;
                if (diff > maxDiff)
                    maxDiff = diff;
            }
            else
            {
                min = input1[i];
            }
        }

        return maxDiff;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of elements in array");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int result = UserProgramCode.diffIntArray(arr);
        Console.WriteLine(result);
    }
}
