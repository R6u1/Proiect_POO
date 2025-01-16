namespace Proiect_POO_;

using System.Globalization;
public class Biblioteca
{
    // Lista statica pentru a stoca toate resursele bibliotecii
    public static List<Biblioteca> resurse = new List<Biblioteca>();
    
    // Proprietati pentru caracteristicile unei resurse
    public int ID { get; set; }
    public string Titlu { get; set; }
    public string Autor { get; set; }
    public string Tip { get; set; }
    public string Gen { get; set; }
    public DateTime DataPublicare { get; set; }
    public int Stoc { get; set; }
    public string Curs { get; set; }
    public string Link { get; set; }
    public int NrPublicare { get; set; }
    public string Editie { get; set; }
    public int LunaPublicare { get; set; }
    
    // Constructor pentru Carte de lectura
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
    
    // Constructor pentru Manual
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
    
    // Constructor pentru EBook
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
    
    // Constructor pentru Revista
    public Biblioteca(int iD, string titlu, string autor, string gen, DateTime dataPublicare, int stoc, string editie, int nrPublicare, int lunaPublicare)
    {
        ID = iD;
        Titlu = titlu;
        Autor = autor;
        Tip = "Revista";
        Gen = gen;
        DataPublicare = dataPublicare;
        Stoc = stoc;
        Editie = editie;
        NrPublicare = nrPublicare;
        LunaPublicare = lunaPublicare;
    }
    
    // Metoda statica pentru adaugarea unei resurse in lista de resurse
    public static void AdaugaResursa(Biblioteca resursa)
    {
        resurse.Add(resursa);
        Console.WriteLine($"Resursa '{resursa.Titlu}' a fost adaugata.");
    }
    
    // Metoda statica pentru stergerea unei resurse din lista dupa ID
    public static void StergeResursa(int id)
    {
        Biblioteca resursaDeSters = resurse.FirstOrDefault(r => r.ID == id);
        if (resursaDeSters != null)
        {
            resurse.Remove(resursaDeSters);
            Console.WriteLine($"Resursa cu ID {id} a fost stearsa.");
        }
        else
        {
            Console.WriteLine($"Resursa cu ID {id} nu a fost gasita.");
        }
    }
    
    // Metoda statica pentru vizualizarea tuturor resurselor din biblioteca
    public static void VizualizeazaResurse()
    {
        if (resurse.Count == 0)
        {
            Console.WriteLine("Biblioteca nu contine resurse.");
        }
        else
        {
            Console.WriteLine("Resurse disponibile in biblioteca:");
            foreach (Biblioteca resursa in resurse)
            {
                Console.WriteLine($"ID: {resursa.ID}, Titlu: {resursa.Titlu}, Tip: {resursa.Tip}, Stoc: {resursa.Stoc}");
            }
        }
    }
    
    // Metoda statica pentru actualizarea stocului unei resurse
    public static void ActualizeazaStoc(int id, int stocNou)
    {
        Biblioteca resursaDeActualizat = resurse.FirstOrDefault(r => r.ID == id);
        if (resursaDeActualizat != null)
        {
            resursaDeActualizat.Stoc = stocNou;
            Console.WriteLine($"Stocul resursei cu ID {id} a fost actualizat la {stocNou}.");
        }
        else
        {
            Console.WriteLine($"Resursa cu ID {id} nu a fost gasita.");
        }
    }
    
    // Metoda statica pentru salvarea resurselor intr-un fisier
    public static void SalveazaInFisier(string fileName)
    {
        using (StreamWriter w = new StreamWriter(fileName))
        {
            foreach (Biblioteca resursa in resurse)
            {
                // Formatam data in formatul yyyy-MM-dd(an,luna,zi)
                string dataPublicareString = resursa.DataPublicare.ToString("yyyy-MM-dd");
                // Construim linia  doar cu  valorile care nu sunt goale sau nu sunt zero
                string linie = $"{resursa.ID}|{resursa.Titlu}|{resursa.Autor}|{resursa.Gen}|{dataPublicareString}|{resursa.Stoc}";
                // Adaugam Curs daca nu este gol
                if (!string.IsNullOrEmpty(resursa.Curs))
                {
                    linie += $"|{resursa.Curs}";
                }
            
                // Adaugam Link daca nu este gol
                if (!string.IsNullOrEmpty(resursa.Link))
                {
                    linie += $"|{resursa.Link}";
                }
                // Adaugam Editie daca nu este goala
                if (!string.IsNullOrEmpty(resursa.Editie))
                {
                    linie += $"|{resursa.Editie}";
                }
                // Adaugam NrPublicare daca nu este zero
                if (resursa.NrPublicare != 0)
                {
                    linie += $"|{resursa.NrPublicare}";
                }
                // Adaugam LunaPublicare daca nu este zero
                if (resursa.LunaPublicare != 0)
                {
                    linie += $"|{resursa.LunaPublicare}";
                }
                w.WriteLine(linie);
            }
        }
        Console.WriteLine($"Resursele au fost salvate in fisierul '{fileName}'.");
    }
    
    // Metoda statica pentru incarcarea resurselor dintr-un fisier
    public static void IncarcaDinFisier(string fileName)
    {
        if (File.Exists(fileName))
        {
            resurse.Clear();
            using (StreamReader r = new StreamReader(fileName))
            {
                string linie;
                while ((linie = r.ReadLine()) != null)
                {
                    string[] parts = linie.Split('|');
                    if (parts.Length >= 6)
                    {
                        try
                        {
                            int id = int.Parse(parts[0]);
                            string titlu = parts[1];
                            string autor = parts[2];
                            string gen = parts[3];
                            // Corectam formatul datelor eliminând spațiul suplimentar
                            DateTime dataPublicare = DateTime.ParseExact(parts[4], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            Biblioteca resursa = null;
                            if (parts.Length == 6) // Carte de baza
                            {
                                int stoc = int.Parse(parts[5]);
                                resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, stoc);
                            }
                            else if (parts.Length == 7 && parts[5].StartsWith("http")) // EBook
                            {
                                string link = parts[5];
                                int stoc = int.Parse(parts[6]);
                                resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, link, stoc);
                            }
                            else if (parts.Length == 7) // Manual sau carte de curs fara link
                            {
                                int stoc = int.Parse(parts[5]);
                                string curs = parts[6];
                                resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, stoc, curs);
                            }
                            else if (parts.Length >= 9) // Revista cu editie, numar si luna de publicare
                            {
                                int stoc = int.Parse(parts[5]);
                                string editie = parts[6];
                                int nrPublicare = int.Parse(parts[7]);
                                int lunaPublicare = int.Parse(parts[8]);
                                resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, stoc, editie, nrPublicare, lunaPublicare);
                            }
                            else
                            {
                                Console.WriteLine($"Format necunoscut pentru linia: {linie}");
                            }
                            if (resursa != null)
                            {
                                resurse.Add(resursa);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Eroare la procesarea liniei: {linie}\n{ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Linie incompleta: {linie}");
                    }
                }
            }
            Console.WriteLine($"Resursele au fost incarcate din '{fileName}'.");
        }
        else
        {
            Console.WriteLine($"Fisierul '{fileName}' nu exista.");
        }
    }
    
    // Metoda pentru afisarea detaliilor unei resurse
    public void AfisareResursa()
    {
        Console.WriteLine($"ID: {ID}, Titlu: {Titlu}, Autor: {Autor}, Tip: {Tip}, Gen: {Gen}, Data Publicare: {DataPublicare}, Stoc: {Stoc}");
        if (Tip == "Manual")
            Console.WriteLine($"Curs: {Curs}");
        if (Tip == "EBook")
            Console.WriteLine($"Link: {Link}");
        if (Tip == "Revista")
            Console.WriteLine($"Editie: {Editie}, Numar Publicare: {NrPublicare}, Luna Publicare: {LunaPublicare}");
    }
}
