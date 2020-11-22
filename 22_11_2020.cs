using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                int wybor = 0, a, b;
                double wynik = 0;
                Console.WriteLine("1 - Dodawanie");
                Console.WriteLine("2 - Odejmowanie");
                Console.WriteLine("3 - Mnożenie");
                Console.WriteLine("4 - Dzielenie");
                Console.WriteLine("5 - Potęgowanie\n");
                try
                {
                    wybor = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Write("Jesteś głupi");
                }
                Console.Write("\nPodaj a: ");
                a = int.Parse(Console.ReadLine());
                Console.Write("Podaj b: ");
                b = int.Parse(Console.ReadLine());
                if (wybor == 1)
                {
                    wynik = a + b;
                }
                else if (wybor == 2)
                {
                    wynik = a - b;
                }
                else if (wybor == 3)
                {
                    wynik = a * b;
                }
                else if (wybor == 4)
                {
                    wynik = (double)a / b;
                }
                else if (wybor == 5)
                {
                    wynik = Math.Pow(Convert.ToDouble(a), Convert.ToDouble(b));
                }
                else
                {
                    Console.WriteLine("\nPodałeś nieprawidłowa liczbę!");
                }
                Console.WriteLine($"\nWynik: {wynik}");
            }
        }
    }
}
