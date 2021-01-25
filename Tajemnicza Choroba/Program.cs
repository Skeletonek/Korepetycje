using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sciezka = @"..\..\tajemnicza_choroba_4-1.txt";
            string[,] danePacjentow = Wczytanie(sciezka);
            string[,] danePacjentowPosortowane = SortowaniePacjentowWedlugGrup(danePacjentow);
            Wyswietlanie(danePacjentowPosortowane);
            SredniWiek(danePacjentowPosortowane);
            Console.WriteLine();
            PierwszeOsoby(danePacjentowPosortowane);
            Console.ReadKey();
        }
        static string[,] Wczytanie(string sciezka)
        {
            FileStream fs = new FileStream(sciezka, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string linia = string.Empty;
            
            linia = sr.ReadLine();
            string[,] danePacjentow = new string[int.Parse(linia), 3];

            int indexTablicy = 0;
            while((linia = sr.ReadLine()) != null)
            {
                string[] podzielonaLinia = linia.Split(';');
                for(int i = 0; i < podzielonaLinia.Length; i++)
                {
                    danePacjentow[indexTablicy, i] = podzielonaLinia[i];
                }
                indexTablicy++;
            }
            return danePacjentow;
        }
        static string[,] SortowaniePacjentowWedlugGrup(string[,] danePacjentow)
        {
            int index = 0;
            string[,] danePacjentowPosortowane = new string[danePacjentow.GetLength(0), 3];
            for (int z = 0; z <= 2; z++)
            {
                for (int i = 0; i < danePacjentow.GetLength(0); i++)
                {
                    if (Convert.ToInt32(danePacjentow[i, 2]) == z)
                    {
                        for (int j = 0; j < danePacjentow.GetLength(1); j++)
                        {
                            danePacjentowPosortowane[index, j] = danePacjentow[i, j];
                        }
                        index++;
                    }
                }
            }
            return danePacjentowPosortowane;
        }
        static void Wyswietlanie(string[,] danePacjentowPosortowane)
        {
            int priorytet = -1;
            for(int i = 0; i < danePacjentowPosortowane.GetLength(0); i++)
            {
                if(Convert.ToInt32(danePacjentowPosortowane[i,2]) > priorytet)
                {
                    priorytet++;
                    Console.WriteLine($"Grupa {priorytet}:");
                }
                for(int j = 0; j <danePacjentowPosortowane.GetLength(1); j++)
                {
                    Console.Write($"{danePacjentowPosortowane[i, j],9}");
                }
                Console.WriteLine();
            }
        }
        static void SredniWiek(string[,] danePacjentowPosortowane)
        {
            int priorytet = 0;
            double srednia = 0;
            int liczbaPacjentow = 0;
            Console.WriteLine("\nŚredni wiek pacjentów w każdej z grup: ");
            Console.Write($"W grupie 0: ");
            for (int i = 0; i < danePacjentowPosortowane.GetLength(0); i++)
            {
                if (Convert.ToInt32(danePacjentowPosortowane[i, 2]) > priorytet)
                {
                    srednia /= liczbaPacjentow;
                    Console.Write($"{srednia:F2}");
                    srednia = 0;
                    liczbaPacjentow = 0;
                    Console.WriteLine();
                    priorytet++;
                    Console.Write($"W grupie {priorytet}: ");
                }
                srednia += double.Parse(danePacjentowPosortowane[i, 1]);
                liczbaPacjentow++;
            }
            srednia /= liczbaPacjentow;
            Console.WriteLine($"{srednia:F2}");
        }
        static void PierwszeOsoby(string[,] danePacjentowPosortowane)
        {
            int priorytet = 0;
            string[,] pierwsiPacjenci = new string[3, 2];
            pierwsiPacjenci[priorytet, 1] = "0";
            for (int i = 0; i < danePacjentowPosortowane.GetLength(0); i++)
            {
                if (Convert.ToInt32(danePacjentowPosortowane[i, 2]) > priorytet)
                {
                    priorytet++;
                    pierwsiPacjenci[priorytet, 1] = "0";
                }
                if(Convert.ToDouble(pierwsiPacjenci[priorytet,1]) < Convert.ToDouble(danePacjentowPosortowane[i,1]))
                {
                    pierwsiPacjenci[priorytet, 0] = danePacjentowPosortowane[i, 0];
                    pierwsiPacjenci[priorytet, 1] = danePacjentowPosortowane[i, 1];
                }
            }
            Zapisanie(pierwsiPacjenci);
        }
        static void Zapisanie(string[,] pierwsziPacjenci)
        {
            FileStream fs = File.Create(@"..\..\szczepieni_pierwsi.txt");
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Pacjenci pierwsi do zaszczepienia w każdej z grup: ");
            for(int i = 0; i < pierwsziPacjenci.GetLength(0); i++)
            {
                sw.Write($"W grupie {i}:");
                for(int j = 0; j < pierwsziPacjenci.GetLength(1); j++)
                {
                    sw.Write($" {pierwsziPacjenci[i, j],12}");
                }
                sw.WriteLine();
            }
            sw.Close();
                        Console.WriteLine("Zapisano pacjentów pierwszych do szczepienia do pliku szczepieni_pierwsi.txt");
        }
    }
}
