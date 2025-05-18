using System;
using System.Collections.Generic;

class Program
{
    static string naam;
    static List<string> spullen = new List<string>();
    static bool weetWachtwoord = false;
    static bool spelBeëindigd = false;

    static void Main()
    {
        spullen.Clear();
        weetWachtwoord = false;
        spelBeëindigd = false;

        Console.Clear();
        Introductie();
        EersteKeuze();

        if (spelBeëindigd) return;

        NaarKasteel();
        KasteelKeuze();

        Console.WriteLine("Bedankt voor het spelen!");
    }

    static void Introductie()
    {
        Console.WriteLine("Welkom bij het Avonturenspel!");
        Console.Write("Wat is je naam, held? ");
        naam = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"Hallo {naam}, je wordt wakker in een donker bos naast een pad richting een oud kasteel.");
        Console.WriteLine("Je besluit naar het kasteel te lopen. Onderweg kom je een splitsing tegen.");
    }

    static void EersteKeuze()
    {
        Console.WriteLine("\nLinks hoor je water stromen, rechts zie je rook. Kies je links of rechts? (links/rechts)");
        string keuze1 = Console.ReadLine().ToLower();
        Console.Clear();

        if (keuze1 == "links")
        {
            Console.WriteLine("Je volgt het pad naar links en komt bij een kleine waterval.");
            Console.WriteLine("Achter de waterval zit een grot met een oude man die zegt: 'Het wachtwoord is draconis... onthoud dat.'");
            weetWachtwoord = true;
        }
        else if (keuze1 == "rechts")
        {
            Console.WriteLine("Je gaat naar rechts en komt bij een kampvuur met een slapende ridder.");
            Console.WriteLine("Je pakt zijn zwaard en sluipt weg.");
            spullen.Add("zwaard");
            ToonInventaris();
        }
        else
        {
            Console.WriteLine("Je was te sloom met antwoorden en een vuurdraak heeft je opgegeten. GAME OVER.");
            Eindes(false);
            spelBeëindigd = true;
            return;
        }
    }

    static void NaarKasteel()
    {
        Console.WriteLine("\nNa een lange tocht bereik je het kasteel. Je duwt de grote poort open en loopt naar binnen.");
        Console.WriteLine("Je ziet een trap naar boven en een deur naar de kelder. Waar ga je heen? (trap/kelder)");
    }

    static void KasteelKeuze()
    {
        string keuze2 = Console.ReadLine().ToLower();
        Console.Clear();

        if (keuze2 == "trap")
        {
            Console.WriteLine("Boven zie je een gesloten deur met een inscriptie: 'Alleen wie het wachtwoord weet, mag passeren.'");
            Console.Write("Wat is het wachtwoord? ");
            string antwoord = Console.ReadLine().ToLower();
            Console.Clear();

            if (antwoord == "draconis" && weetWachtwoord)
            {
                Console.WriteLine("De deur opent. Je vindt een kamer vol schatten. Je hebt gewonnen!");
                Eindes(true);
            }
            else
            {
                Console.WriteLine("Verkeerd wachtwoord! De vloer zakt weg en je valt in de afgrond.");
                Eindes(false);
            }
        }
        else if (keuze2 == "kelder")
        {
            Console.WriteLine("In de kelder word je aangevallen door een monster!");
            ToonInventaris();

            if (spullen.Contains("zwaard"))
            {
                Console.WriteLine("Je gebruikt het zwaard om het monster te verslaan.");
                Console.WriteLine("Achter het monster vind je een uitgang naar vrijheid.");
                Eindes(true);
            }
            else
            {
                Console.WriteLine("Je hebt geen wapen en het monster verslaat je.");
                Eindes(false);
            }
        }
        else
        {
            Console.WriteLine("Je struikelt over je eigen voeten en valt in een put. Einde verhaal.");
            Eindes(false);
        }
    }

    static void ToonInventaris()
    {
        Console.WriteLine("\n-------------------");
        Console.WriteLine("|   INVENTARIS    |");
        Console.WriteLine("-------------------");

        if (spullen.Count == 0)
        {
            Console.WriteLine("| (leeg)          |");
        }
        else
        {
            for (int i = 0; i < spullen.Count; i++)
            {
                string item = spullen[i];
                Console.WriteLine($"| {i + 1}. {item.PadRight(14)}|"); // Dit zorgt ervoor dat de naam van het item minimaal 14 tekens breed is door spaties toe te voegen aan het einde.
            }
        }

        Console.WriteLine("-------------------\n");
    }

    static void Eindes(bool succes)
    {
        if (succes)
        {
            Console.WriteLine($"\nGefeliciteerd {naam}, je hebt het avontuur overleefd!");
        }
        else
        {
            Console.WriteLine($"\nJammer {naam}, je avontuur is ten einde.");
        }
    }
}
