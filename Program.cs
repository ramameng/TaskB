using System;

namespace TaskB
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;

            while (exit == 0)
            {
                Console.Write("Input: $");
                string input = Console.ReadLine();

                Console.WriteLine($"Result: {input.ProcessInput()}");
                Console.WriteLine("");
                Console.Write("Try again? (Press n to exit.) ");
                if (Console.ReadKey().Key == ConsoleKey.N)
                    exit = 1;
                else
                    Console.WriteLine("");
            }
        }
    }
}
