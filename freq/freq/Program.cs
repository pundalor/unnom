using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа через пробел:");
        string input = Console.ReadLine();
        int[] nums = Array.ConvertAll(input.Split(), int.Parse);

        int[] result = FindUniqueNumbers(nums);

        if (result.Length == 1)
        {
            Console.WriteLine($"Уникальное число: {result[0]}");
        }
        else
        {
            Console.WriteLine($"Уникальные числа: {result[0]}, {result[1]}");
        }
    }

    static int[] FindUniqueNumbers(int[] nums)
    {
        int xorAll = 0;
        foreach (int num in nums)
        {
            xorAll ^= num; // Найти общий XOR всех чисел
        }

        // Если одно уникальное число
        if (Array.Exists(nums, num => num == xorAll))
        {
            return new int[] { xorAll };
        }

        // Найти бит-разделитель
        int diffBit = xorAll & -xorAll;

        int group1 = 0, group2 = 0;
        foreach (int num in nums)
        {
            if ((num & diffBit) == 0)
                group1 ^= num;
            else
                group2 ^= num;
        }

        return new int[] { group1, group2 };
    }
}