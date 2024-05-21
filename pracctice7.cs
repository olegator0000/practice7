//задача 1
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        int[] numbers = Array.ConvertAll(lines, int.Parse);
        
        int max = numbers.Max();
        int min = numbers.Min();
        
        Console.WriteLine($"Maximum: {max}");
        Console.WriteLine($"Minimum: {min}");
    }
}
//задача 2
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        int[] numbers = Array.ConvertAll(lines, int.Parse);
        
        Array.Sort(numbers);
        
        File.WriteAllLines("output.txt", numbers.Select(n => n.ToString()).ToArray());
    }
}

//задача 3
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("output.txt");
        int[] numbers = Array.ConvertAll(lines, int.Parse);
        
        var primes = numbers.Where(IsPrime).ToArray();
        
        File.WriteAllLines("primes.txt", primes.Select(n => n.ToString()).ToArray());
    }
    
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        
        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }
        
        return true;
    }
}

//задача 4
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        var results = lines.Where((surname, index) => lines.Any(other => other.Contains(surname) && other != surname)).ToArray();
        
        File.WriteAllLines("output.txt", results);
    }
}

//задача 5
using System;
using System.IO;
using System.Numerics;

class Program
{
    static void Main()
    {
        string input = File.ReadAllText("input.txt");
        BigInteger number = BigInteger.Parse(input);
        int N = 2; // Задайте необхідну ступінь
        
        BigInteger result = BigInteger.Pow(number, N);
        
        Console.WriteLine(result);
    }
}

//задача 6
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines1 = File.ReadAllLines("Num_1.txt");
        string[] lines2 = File.ReadAllLines("Num_2.txt");
        
        var set1 = new HashSet<int>(lines1.Select(int.Parse));
        var set2 = new HashSet<int>(lines2.Select(int.Parse));
        
        var common = set1.Intersect(set2);
        
        foreach (var number in common)
        {
            Console.WriteLine(number);
        }
    }
}

//задача 7
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines1 = File.ReadAllLines("input.txt");
        string[] lines2 = File.ReadAllLines("output.txt");
        
        int[] numbers1 = Array.ConvertAll(lines1, int.Parse);
        int[] numbers2 = Array.ConvertAll(lines2, int.Parse);
        
        int count = 0;
        
        foreach (var a in numbers1)
        {
            foreach (var b in numbers2)
            {
                if (Gcd(a, b) == 1)
                {
                    count++;
                }
            }
        }
        
        Console.WriteLine($"Number of relatively prime pairs: {count}");
    }
    
    static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}

//задача 8
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("matrix.txt");
        int[,] matrix = ParseMatrix(lines);
        
        int sum = 0;
        int n = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
        
        for (int i = 0; i < n; i++)
        {
            sum += matrix[i, i];
        }
        
        Console.WriteLine($"Sum of main diagonal elements: {sum}");
    }
    
    static int[,] ParseMatrix(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Split(' ').Length;
        int[,] matrix = new int[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            string[] elements = lines[i].Split(' ');
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(elements[j]);
            }
        }
        
        return matrix;
    }
}

//задача 9
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        int[] numbers = Array.ConvertAll(lines, int.Parse);
        int N = numbers.Length;
        var freq = new Dictionary<int, int>();
        
        foreach (var number in numbers)
        {
            if (freq.ContainsKey(number))
            {
                freq[number]++;
            }
            else
            {
                freq[number] = 1;
            }
        }
        
        var majorityElements = freq.Where(kv => kv.Value > N / 2).Select(kv => kv.Key).ToArray();
        
        foreach (var elem in majorityElements)
        {
            Console.WriteLine(elem);
        }
    }
}

//задача 10
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        int[] numbers = Array.ConvertAll(lines, int.Parse);
        
        int missingNumber = 1;
        var set = new HashSet<int>(numbers);
        
        while (set.Contains(missingNumber))
        {
            missingNumber++;
        }
        
        File.AppendAllText("input.txt", missingNumber.ToString() + Environment.NewLine);
        Console.WriteLine($"The smallest missing number is: {missingNumber}");
    }
}
