using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Private_Lessons
{
    class WO_Petle
    {
        static void Main(string[] args)
        {
            // PĘTLA FOR

            // Budowa: 
            // for(<deklaracja zmiennej>; <warunek działania pętli>; <czynność na zakończenie jednej iteracji pętli>)
            // {
            // <zawartość pętli>
            // }

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Została wykonana jedna iteracja pętli for");
            }

            Console.WriteLine();
            // Pętla for nie musi posiadać wypełnionych wszystkich argumentów

            int forLoop = 0;
            for(;forLoop < 5; forLoop++)
            {
                Console.WriteLine("Została wykonana jedna iteracja pętli for z wykorzystaniem zmiennej forloop");
            }

            Console.WriteLine();
            // W ten sposób możemy stworzyć pętle która będzie wykonywana w nieskończoność

            // for(;;)
            // {
            // <zawartość pętli>
            // }

            // PĘTLA WHILE i DO...WHILE

            int whileLoop = 0;
            int doWhileLoop = 0;

            while(whileLoop < 5) // Definicja warunku na początku
            {
                Console.WriteLine("Została wykonana jedna iteracja pętli while");
                whileLoop++; // Wymagane jest ręczne wpisanie zmiany wartości zmiennej używanej w warunku. Inaczej pętla będzie wykonywana w nieskończoność.
            }

            do
            {
                Console.WriteLine("Została wykonana jedna iteracja pętli do...while"); 
                doWhileLoop++;
            } while (doWhileLoop < 5); // Definicja warunku na końcu z średnikiem na zakończenie

            Console.WriteLine();
            // Różnica między tymi pętlami jest taka, że pętla do...while zawsze wykona się przynajmniej raz niezależnie od warunku.
            // Pętla while wykona się tylko jeśli warunek jest spełniony

            // Ponieważ nasze zmienne whileLoop i doWhileLoop mają już wartość 5, czyli nie spełniają warunku, że 5 < 5 możemy to zaobserwować jeszcze raz uruchamiając pętle

            while (whileLoop < 5)
            {
                Console.WriteLine("Została wykonana jedna iteracja pętli while, w momencie gdy whileLoop już ma wartość 5");
                whileLoop++;
            }

            do
            {
                Console.WriteLine("Została wykonana jedna iteracja pętli do...while, w momencie gdy doWhileLoop już ma wartość 5");
                whileLoop++;
            } while (doWhileLoop < 5);

            Console.ReadKey();
        }
    }
}
