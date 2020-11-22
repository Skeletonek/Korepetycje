using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            for (; i < 5; i++)
            {
                Console.Write("Test!");
            }
            Console.WriteLine();
            while (i < 5)
            {
                Console.Write("Test!");
                i++;
            }
            Console.WriteLine();
            do
            {
                Console.Write("Test!");
                k++;
            } while (i < 5);
        }
    }
}
