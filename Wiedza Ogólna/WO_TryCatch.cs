using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Private_Lessons
{
    class WO_TryCatch
    {
        static void Main(string[] args)
        {
            string zmiennaNiszczącaProgram = "Zniszczę twoje życie";
            int niczegoNiewinnaZmienna;

            // niczegoNiewinnaZmienna = int.Parse(zmiennaNiszczącaProgram);
            // Ta instrukcja była zakomentowana, ponieważ spowodowałaby wyjątek (System.FormatException), który "zcrashowałby" nasz program
            // Oczywiście jest tak dlatego, że program nie jest w stanie zrozumieć zdania "Zniszczę twoje życie" jako liczby

            // Możemy to łatwo ominąć na dwa sposoby

            try
            {
                niczegoNiewinnaZmienna = int.Parse(zmiennaNiszczącaProgram);
            }
            catch
            {
                Console.WriteLine($"Nie potrafię zrozumieć \"{zmiennaNiszczącaProgram}\" jako liczby!");
                Console.WriteLine($"Ustawiam wartość zmiennej niczegoNiewinnaZmienna na 0");
                niczegoNiewinnaZmienna = 0;
            }

            Console.WriteLine($"Wartość zmiennej niczegoNiewinnaZmienna = {niczegoNiewinnaZmienna}\n");

            // Możemy dokładnie doprecyzować co ma się wykonać w przypadku jakiego wyjątku

            try
            {
                niczegoNiewinnaZmienna = int.Parse(zmiennaNiszczącaProgram);
            }
            catch(System.FormatException)
            {
                Console.WriteLine($"Nie potrafię zrozumieć \"{zmiennaNiszczącaProgram}\" jako liczby! Wykryto wyjątek: \"System.FormatException\"");
                Console.WriteLine($"Ustawiam wartość zmiennej niczegoNiewinnaZmienna na 0");
                niczegoNiewinnaZmienna = 0;
            }

            Console.WriteLine($"Wartość zmiennej niczegoNiewinnaZmienna = {niczegoNiewinnaZmienna}\n");

            // Try, Catch będziemy używali ogólnie dla wszystkich przypadków gdzie może nastąpić wyjątek.
            // Oczywiście aby Try, Catch zostało użyte, programista musi przewidzieć że taki błąd może wystąpić, lub wykryć wyjątek na etapie testów aplikacji

            // W przypadku konwersji tekstu na liczby możemy użyć też specjalnej instrukcji TryParse

            Console.WriteLine($"Wartość dla metody TryParse: {zmiennaNiszczącaProgram}");
            int.TryParse(zmiennaNiszczącaProgram, out niczegoNiewinnaZmienna); // Jeżeli instrukcji TryParse nie uda się przekonwertować znaków, ustawi ona wartość zmiennej na 0
            Console.WriteLine($"Wartość zmiennej niczegoNiewinnaZmienna = {niczegoNiewinnaZmienna}\n");

            Console.WriteLine($"Wartość dla metody TryParse: 30");
            int.TryParse("30", out niczegoNiewinnaZmienna); //Jeśli się jednak uda, to wiadomo jaka będzie wartość :-)
            Console.WriteLine($"Wartość zmiennej niczegoNiewinnaZmienna = {niczegoNiewinnaZmienna}\n");

            // TryParse jest metodą, która może zwracać dodatkową wartość. Jest to wartość typu bool, która informuje nas czy konwersja się udała

            if(int.TryParse(zmiennaNiszczącaProgram, out niczegoNiewinnaZmienna)) // Sprawdzenie czy funkcja zwrociła wartość true
            {
                Console.WriteLine($"Udało się przekonwertować liczbę!");
            }
            else
            {
                Console.WriteLine($"Nie udało się przekonwertować liczby!");
            }
            Console.WriteLine($"Wartość zmiennej niczegoNiewinnaZmienna = {niczegoNiewinnaZmienna}\n");

            // I w przypadku udanej konwersji...

            if (int.TryParse("66", out niczegoNiewinnaZmienna))
            {
                Console.WriteLine($"Udało się przekonwertować liczbę!");
            }
            else
            {
                Console.WriteLine($"Nie udało się przekonwertować liczby!");
            }
            
            Console.WriteLine($"Wartość zmiennej niczegoNiewinnaZmienna = {niczegoNiewinnaZmienna}\n");

            Console.ReadKey();
        }
    }
}
