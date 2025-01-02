namespace Proiect_POO;

public class Biblioteca
{
    public static List<Biblioteca> Resurse = new List<Biblioteca>();
    public int ID { get; set; }
    public string Titlu { get; set; }
    public string Autor { get; set; }
    public string Tip { get; set; }
    public string Gen { get; set; }
    public DateTime DataPublicare { get; set; }
    public int Stoc { get; set; }
    public string Curs { get; set; }

    public Biblioteca(int iD, string titlu, string autor, string gen, DateTime dataPublicare, int stoc, string curs)
    {
        ID = iD;
        Titlu = titlu;
        Autor = autor;
        Tip = "Manual";
        Gen = gen;
        DataPublicare = dataPublicare;
        Stoc = stoc;
        Curs = curs;
    }

    public Biblioteca(int iD, string titlu, string autor, string gen, DateTime dataPublicare, int stoc)
    {
        ID = iD;
        Titlu = titlu;
        Autor = autor;
        Tip = "Carte de lectura";
        Gen = gen;
        DataPublicare = dataPublicare;
        Stoc = stoc;
    }

    public string Link { get; set; }

    public Biblioteca(int iD, string titlu, string autor, string gen, DateTime dataPublicare, string link, int stoc)
    {
        ID = iD;
        Titlu = titlu;
        Autor = autor;
        Tip = "EBook";
        Gen = gen;
        DataPublicare = dataPublicare;
        Stoc = stoc;
        Link = link;
    }

    public int NrPublicare { get; set; }
    public string Editie { get; set; }
    public int LunaPublicare { get; set; }

    public Biblioteca(int iD, string titlu, string autor, string gen, DateTime dataPublicare, int stoc, string editie,
        int nrPublicare, int lunaPublicare)
    {
        ID = iD;
        Titlu = titlu;
        Autor = autor;
        Tip = "Revista";
        Gen = gen;
        DataPublicare = dataPublicare;
        Stoc = stoc;
        NrPublicare = nrPublicare;
        LunaPublicare = lunaPublicare;
        Editie = editie;
    }

    public static void AdaugaResursa(Biblioteca resursa)
    {
        Resurse.Add(resursa);
        Console.WriteLine($"Resursa '{resursa.Titlu}' a fost adaugata.");
    }

    public static void StergeResursa(int id)
    {
        Biblioteca resursaDeSters = null;
        foreach (Biblioteca resursa in Resurse)
        {
            if (resursa.ID == id)
            {
                resursaDeSters = resursa;
                break;
            }
        }

        if (resursaDeSters != null)
        {
            Resurse.Remove(resursaDeSters);
            Console.WriteLine($"Resursa cu ID {id} a fost stearsa.");
        }
        else
        {
            Console.WriteLine($"Resursa cu ID {id} nu a fost gasita.");
        }
    }

    public static void VizualizeazaResurse()
    {
        if (Resurse.Count == 0)
        {
            Console.WriteLine("Biblioteca nu conține resurse.");
        }
        else
        {
            Console.WriteLine("Resurse disponibile în bibliotecă:");
            foreach (Biblioteca resursa in Resurse)
            {
                Console.WriteLine(
                    $"ID: {resursa.ID}, Titlu: {resursa.Titlu}, Tip: {resursa.Tip}, Stoc: {resursa.Stoc}");
            }
        }
    }

    public static void ActualizeazaStoc(int id, int stocNou)
    {
        Biblioteca resursaDeActualizat = null;
        foreach (Biblioteca resursa in Resurse)
        {
            if (resursa.ID == id)
            {
                resursaDeActualizat = resursa;
                break;
            }
        }

        if (resursaDeActualizat != null)
        {
            resursaDeActualizat.Stoc = stocNou;
            Console.WriteLine($"Stocul resursei cu ID {id} a fost actualizat la {stocNou}.");
        }
        else
        {
            Console.WriteLine($"Resursa cu ID {id} nu a fost găsită.");
        }
    }

    public static void SalveazaInFisier(string fileName)
    {
        using (StreamWriter w = new StreamWriter(fileName))
        {
            foreach (Biblioteca resursa in Resurse)
            {
                string linie =
                    $"{resursa.ID}|{resursa.Titlu}|{resursa.Autor}|{resursa.Tip}|{resursa.Gen}|{resursa.DataPublicare}|{resursa.Stoc}|{resursa.Curs}|{resursa.Link}|{resursa.Editie}|{resursa.NrPublicare}|{resursa.LunaPublicare}";
                w.WriteLine(linie);
            }
        }

        Console.WriteLine($"Resursele au fost salvate în fișierul '{fileName}'.");
    }
}
