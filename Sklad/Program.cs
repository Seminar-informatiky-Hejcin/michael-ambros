using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Sklad;

public record Produkt(int Id, string Nazev, string Kategorie, decimal Cena, int SklademKs);

class Program
{
    static void Main()
    {
        List<Produkt> sklad = NactiProdukty();
        int volba = -1;

        while (volba != 0)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Vyprodané produkty");
            Console.WriteLine("2 - Hodnota skladu");
            Console.WriteLine("3 - Levný notebook");
            Console.WriteLine("4 - Tři nejdražší produkty skladem");
            Console.WriteLine("5 - Souhrn podle kategorií");
            Console.WriteLine("0 - Konec");

            // volba = NactiVolbu();
            volba = 4;


            switch (volba)
            {
                case 1:
                {
                    // TODO: Vypište názvy produktů, které nejsou skladem (Where, Select).
                    var vypis = sklad
                        .Where(x => x.SklademKs == 0)
                        .Select(x => x.Nazev).ToList();
                    foreach (var item in vypis) {
                        Console.WriteLine(item);
                    }        

                    break;
                }
                case 2:
                {
                    // TODO: Vypočítejte celkovou hodnotu skladu (Sum).
                    var vypis = sklad
                        .Sum(x => x.Cena * x.SklademKs);
                    Console.WriteLine(vypis);

                    break;
                }
                case 3:
                {
                    // TODO: Zjistěte, zda existuje levný notebook (Any).
                    var existujeLevnyNotebook = sklad
                        .Any(item => item.Kategorie.ToLower() == "notebook" && item.Cena < 10000);
                    if (existujeLevnyNotebook)
                        Console.WriteLine("existuje levny notebook");
                    else
                        Console.WriteLine("neexistuje levny notebook");
                    break;
                }
                case 4:
                {
                    // TODO: Vypište až tři nejdražší produkty skladem
                    // (Where, OrderByDescending, Take).
                    var vypis = sklad
                        .OrderByDescending(item => item.Cena)
                        .Select(x => x.Nazev)
                        .Take(3);
                    foreach (var item in vypis) {
                        Console.WriteLine(item);
                    }        

                    break;
                }
                case 5:
                {
                    // TODO: Vypište počet produktů a kusů skladem podle kategorie (GroupBy).
                    break;
                }
                case 0:
                    Console.WriteLine("Konec.");
                    break;
                default:
                    Console.WriteLine("Taková volba v menu není.");
                    break;
            }
            
        }
    }

    static List<Produkt> NactiProdukty()
    {
        // test or real data 
        if (true)
        { 
            var sklad = new List<Produkt>()
            {
                    new(1, "nazev1", "kategorie", 10.01m, 0),
                    new(2, "nazev2", "kategorie", 11.01m, 0),
                    new(3, "nazev3", "kategorie", 12.01m, 12),
                    new(4, "nazev4", "notebook", 13.01m, 13),
                    new(5, "nazev5", "notebook", 13.01m, 13),
            };

            return sklad;
        }
        else
        {
            var sklad = new List<Produkt>();
            // loading products
            Console.WriteLine("Kolik produktů chceš vložit?");
            var line = Console.ReadLine();
            int pocet;
            try
            {
                pocet = int.Parse(line);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Nemohl jsem naparsovat do intu počet produktů: {0}", e.Message);
                throw;
            }
            // todo: better exceptions, like this
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                throw;
            }

            if (pocet <= 0)
            {
                throw new ArgumentOutOfRangeException("Počet produktů k vložení musí být kladné číslo");
            }

            // debug
            Console.WriteLine("pocet produkutu je {0}", pocet);

            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine("Zadej {0}. produkt", i);

                // id
                Console.WriteLine("\tId produktu:");
                int Id;
                try 
                {
                Id = int.Parse(Console.ReadLine() !);
                }
                catch
                {
                    Console.WriteLine("Nemohl jsem naparsovat do intu Id produktu");
                    throw;
                }
                if (Id < 0) throw new ArgumentException("Id produktu musí být nezáporné");

                // nazev
                Console.WriteLine("\tNázev produktu:");
                string Nazev;
                Nazev = Console.ReadLine();
                if (Nazev.Length == 0) throw new ArgumentException("Název produktu nemůže být prázdný");

                // kategorie
                Console.WriteLine("\tKategorie produktu:");
                string Kategorie;
                Kategorie = Console.ReadLine();
                if (Kategorie.Length == 0) throw new ArgumentException("Kategorie produktu nemůže být prázdný");

                // id
                Console.WriteLine("\tCena produktu:");
                decimal Cena;
                try 
                {
                Cena = decimal.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Nemohl jsem naparsovat do decimalu Cenu produktu");
                    throw;
                }
                if (Id < 0) throw new ArgumentException("Cena produktu musí být nezáporné");

                // skladem ks
                Console.WriteLine("\tSklademKs produktů:");
                int SklademKs;
                try 
                {
                SklademKs = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Nemohl jsem naparsovat do intu SklademKs produktu");
                    throw;
                }
                if (SklademKs < 0) throw new ArgumentException("SklademKs produktu musí být nezáporné");
            }

            return sklad;
       }
    }

    static int NactiVolbu()
    {
        Console.Write("Volba: ");

        try
        {
            return int.Parse(Console.ReadLine() ?? string.Empty);
        }
        catch (FormatException)
        {
            Console.WriteLine("Zadejte celé číslo.");
            return -1;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Zadané číslo je příliš velké nebo malé.");
            return -1;
        }
    }

    static int NactiCeleCislo(string name)
    {
        Console.WriteLine("\t{name.} produktu:");
        int Id;
        try 
        {
        Id = int.Parse(Console.ReadLine() !);
        }
        catch
        {
            Console.WriteLine("Nemohl jsem naparsovat do intu Id produktu");
            throw;
        }
        if (Id < 0) throw new ArgumentException("Id produktu musí být nezáporné");


    }

}
