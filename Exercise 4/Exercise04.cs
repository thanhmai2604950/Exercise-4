using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise_03
{
    internal class Exercise_4
    {
        static void Main()
        {
            Ex01();
            Ex02();
            Ex03(); 
            Ex0401();
            Ex0402();
            Ex05();
            Ex06();
        }
        /// <summary>
        /// 1.Write a C# function to find the largest number of the three numbers.
        /// Improve the next version that accept at least 1 parameter. (varArg)
        /// </summary>
        static void Ex01()
        {
            Console.WriteLine("Enter three numbers:");
            string? inputA = Console.ReadLine();
            string? inputB = Console.ReadLine();
            string? inputC = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputA) || string.IsNullOrWhiteSpace(inputB) || string.IsNullOrWhiteSpace(inputC))
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
                return;
            }

            int a = int.Parse(inputA);
            int b = int.Parse(inputB);
            int c = int.Parse(inputC);

            int largest = FindLargestOfThree(a, b, c);
            Console.WriteLine($"Largest of three is: {largest}");
            Console.WriteLine("Enter numbers separated by space:");
            string? inputLine = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
                return;
            }
            string[] input = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll(input, int.Parse);

            int largestVarArg = FindLargest(numbers);
            Console.WriteLine($"Largest (varArg) is: {largestVarArg}");
            static int FindLargestOfThree(int a, int b, int c)
            {
                int max = a;
                if (b > max) max = b;
                if (c > max) max = c;
                return max;
            }

            static int FindLargest(params int[] numbers)
            {
                if (numbers == null || numbers.Length == 0)
                    throw new ArgumentException("At least one number is required.");

                int max = numbers[0];
                foreach (int num in numbers)
                {
                    if (num > max)
                        max = num;
                }
                return max;
            }
        }
        /// <summary>
        /// 2.Write a C# function to calculate the factorial of a number (a non-negative integer). The function accepts the number as an argument.
        /// </summary>
        static void Ex02()
        {
            Console.Write("Enter a non-negative integer: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid non-negative integer.");
                return;
            }
            int n = int.Parse(input);

            if (n < 0)
            {
                Console.WriteLine("Number must be non-negative");
                return;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            Console.WriteLine($"{n}! = {result}");
        }
        /// <summary>
        /// 3.Write a C# function that takes a number as a parameter and checks whether the number is prime or not.
        /// </summary>
        static void Ex03()
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            int n = int.Parse(input);

            if (n <= 1)
            {
                Console.WriteLine($"{n} is not a prime number.");
                return;
            }

            bool isPrime = true;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
                Console.WriteLine($"{n} is a prime number.");
            else
                Console.WriteLine($"{n} is not a prime number.");
        }
        /// <summary> 
        /// 4.Write a C# function to print
        /// 4.1.all prime numbers that less than a number(enter prompt keyboard).
        /// </summary>
        static void Ex0401()
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            int n = int.Parse(input);

            if (n <= 2)
            {
                Console.WriteLine("No prime numbers less than " + n);
                return;
            }

            Console.WriteLine($"Prime numbers less than {n}:");
            for (int i = 2; i < n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// 4.Write a C# function to print
        /// 4.2.the first N prime numbers
        /// </summary>
        static void Ex0402()
        {
            Console.Write("Enter N (number of prime numbers to print): ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            int n = int.Parse(input);

            if (n <= 0)
            {
                Console.WriteLine("N must be greater than 0.");
                return;
            }

            Console.WriteLine($"First {n} prime numbers:");
            int count = 0;
            int num = 2;

            while (count < n)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.Write(num + " ");
                    count++;
                }

                num++;
            }

            Console.WriteLine();
        }
        /// <summary>  
        /// 5.Write a C# function to check whether a number is "Perfect" or not. Then print all perfect number that less than 1000.
        /// </summary>
        static void Ex05()
        {
            // 1. Check a number is Perfect or not
            Console.Write("Enter a number to check Perfect or not: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            int n = int.Parse(input);

            int sum = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                    sum += i;
            }

            if (sum == n && n != 0)
                Console.WriteLine($"{n} is a Perfect number.");
            else
                Console.WriteLine($"{n} is not a Perfect number.");

            // 2. Print all Perfect numbers less than 1000
            Console.WriteLine("Perfect numbers less than 1000 are:");
            for (int num = 1; num < 1000; num++)
            {
                int s = 0;
                for (int j = 1; j <= num / 2; j++)
                {
                    if (num % j == 0)
                        s += j;
                }
                if (s == num && num != 0)
                    Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        /// <summary>  
        /// 6.Write a C# function to check whether a string is a pangram or not.
        /// (Note : Pangrams are words or sentences containing every letter of the alphabet at least once.For example : "The quick brown fox jumps over the lazy dog")
        /// </summary>
        static void Ex06()
        {
            Console.WriteLine("Enter a sentence to check pangram or not:");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty sentence.");
                return;
            }

            // chuẩn hóa: đưa về chữ thường, bỏ ký tự không phải a-z
            string lower = input.ToLower();
            bool[] seen = new bool[26];

            foreach (char c in lower)
            {
                if (c >= 'a' && c <= 'z')
                {
                    seen[c - 'a'] = true;
                }
            }

            bool isPangram = true;
            for (int i = 0; i < 26; i++)
            {
                if (!seen[i])
                {
                    isPangram = false;
                    break;
                }
            }

            if (isPangram)
                Console.WriteLine("This sentence is a Pangram.");
            else
                Console.WriteLine("This sentence is NOT a Pangram.");
        }
    }
}
