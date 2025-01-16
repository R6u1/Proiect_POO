namespace Proiect_POO_;

public class Student
{
    // Proprietate pentru numele studentului
    public string Nume { get; set; }

    // Numarul de imprumuturi curente ale studentului
    private int nrImprumut;

    // Numarul maxim de imprumuturi permise, in functie de statutul avansat
    private int nrMaxImprumut;

    // Lista de resurse disponibile in biblioteca
    private List<Biblioteca> carti;

    // Istoricul imprumuturilor studentului
    private List<Biblioteca> istoricImprumutari;

    // Lista cursurilor la care este inscris studentul
    private List<string> cursuriInscrise;

    // Flag pentru a diferentia intre utilizatori standard si avansati
    public bool esteAvansat;

    // Lista de rezervari pentru student
    private List<Biblioteca> rezervari;
    public DateTime UltimaActivitate { get; set; }

    // Constructor pentru clasa Student
    public Student(int nrMaxImprumut, List<Biblioteca> carti, List<Biblioteca> istoricImprumutari,
        bool esteAvansat = false, string nume = "")
    {
        this.nrImprumut = 0;
        this.nrMaxImprumut = esteAvansat ? 5 : 3; // 5 pentru avansati, 3 pentru standard
        this.carti = carti;
        this.istoricImprumutari = istoricImprumutari;
        this.cursuriInscrise = new List<string>();
        this.esteAvansat = esteAvansat;
        this.rezervari = new List<Biblioteca>();
        this.Nume = nume;
        this.UltimaActivitate = DateTime.Now; 
    }

    // Proprietate pentru a accesa si modifica istoricul imprumuturilor
    public List<Biblioteca> IstoricImprumutari
    {
        get => istoricImprumutari;
        set => istoricImprumutari = value;
    }

    // Metoda pentru a incrementa numarul de imprumuturi
    public void ImprumutariPlus()
    {
        nrImprumut++;
    }

    // Proprietate pentru a accesa si modifica numarul de imprumuturi curente
    public int NrImprumut
    {
        get => nrImprumut;
        set => nrImprumut = value;
    }

    // Proprietate pentru a accesa si modifica lista de carti
    public List<Biblioteca> Carti
    {
        get => carti;
        set => carti = value;
    }

    // Proprietate pentru a accesa cursurile la care este inscris studentul
    public List<string> CursuriInscrise
    {
        get { return cursuriInscrise; }
    }

    // Metoda pentru a obtine o copie a listei de cursuri inscrise
    public List<string> GetCursuriInscrise()
    {
        return new List<string>(cursuriInscrise); // Returnam o copie pentru a evita modificarea directa
    }

    // Metoda pentru a adauga o rezervare
    public void AdaugaRezervare(Biblioteca resursa)
    {
        if (!rezervari.Contains(resursa))
        {
            rezervari.Add(resursa);
        }
    }

    // Metoda pentru a obtine o copie a listei de rezervari
    public List<Biblioteca> GetRezervari()
    {
        return new List<Biblioteca>(rezervari); // Returnam o copie pentru a evita modificarea directa
    }

    // Metoda pentru a sterge o rezervare
    public void StergeRezervare(Biblioteca resursa)
    {
        rezervari.Remove(resursa);
    }

    // Metoda pentru a imprumuta o resursa
    public void ImprumutareResursa()
    {
        Console.WriteLine("Dati titlul resursei pe care doriti sa o imprumutati: ");
        string titluCautare = Console.ReadLine();
        foreach (Biblioteca resurse in carti)
        {
            if (resurse.Titlu.Equals(titluCautare))
            {
                if (resurse.Stoc > 0 && nrImprumut < nrMaxImprumut)
                {
                    if (resurse.Tip == "Manual" && !cursuriInscrise.Contains(resurse.Curs))
                    {
                        Console.WriteLine("Nu sunteti inscris la cursul necesar pentru a imprumuta acest manual.");
                        return;
                    }

                    resurse.Stoc--;
                    ImprumutariPlus();
                    istoricImprumutari.Add(resurse);
                    Console.WriteLine($"Ati imprumutat '{resurse.Titlu}'.");
                }
                else if (resurse.Stoc == 0)
                {
                    Console.WriteLine("Resursa nu este disponibila momentan. Doriti sa o rezervati? (da/nu)");
                    string raspuns = Console.ReadLine().ToLower();
                    if (raspuns == "da")
                    {
                        RezervaResursa(resurse);
                    }
                }
                else
                {
                    Console.WriteLine("Ati atins limita maxima de imprumuturi.");
                }
            }
        }
    }

    // Metoda pentru cautarea resurselor
    public void cautareResurse()
    {
        Console.WriteLine("1 - ID, 2 - Titlu, 3 - Autor, 4 - Tip, 5 - Gen, 6 - Data Publicarii, 7 - Stoc");
        Console.WriteLine("Alegeti dupa ce criteriu doriti sa cautati cartea: ");
        int optiune = int.Parse(Console.ReadLine());
        List<Biblioteca> results = new List<Biblioteca>();
        do
        {
            switch (optiune)
            {
                case 1:
                    Console.WriteLine("Dati id-ul dupa care doriti sa cautati: ");
                    int idCautare = int.Parse(Console.ReadLine());
                    results = carti.Where(r => r.ID == idCautare).ToList();
                    break;
                case 2:
                    Console.WriteLine("Dati titlul dupa care doriti sa cautati: ");
                    string titluCautare = Console.ReadLine();
                    results = carti.Where(r => r.Titlu.Equals(titluCautare, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case 3:
                    Console.WriteLine("Dati autorul dupa care doriti sa cautati: ");
                    string autorCautare = Console.ReadLine();
                    results = carti.Where(r => r.Autor.Equals(autorCautare, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case 4:
                    Console.WriteLine("Dati tipul dupa care doriti sa cautati: ");
                    string tipCautare = Console.ReadLine();
                    results = carti.Where(r => r.Tip.Equals(tipCautare, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case 5:
                    Console.WriteLine("Dati genul dupa care doriti sa cautati: ");
                    string genCautare = Console.ReadLine();
                    results = carti.Where(r => r.Gen.Equals(genCautare, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case 6:
                    Console.WriteLine("Dati data publicarii dupa care doriti sa cautati (format: yyyy-MM-dd): ");
                    DateTime dataPublicarii = DateTime.Parse(Console.ReadLine());
                    results = carti.Where(r => r.DataPublicare.Date == dataPublicarii.Date).ToList();
                    break;
                case 7:
                    Console.WriteLine("Dati stocul dupa care doriti sa cautati: ");
                    int stocCautare = int.Parse(Console.ReadLine());
                    results = carti.Where(r => r.Stoc == stocCautare).ToList();
                    break;
                case 0:
                    return;
            }

            if (results.Count == 0)
            {
                Console.WriteLine("Nicio resursa nu a fost gasita conform criteriului dat.");
            }
            else
            {
                Console.WriteLine("Resursele gasite sunt:");
                foreach (Biblioteca resursa in results)
                {
                    resursa.AfisareResursa();
                    // Incercam sa imprumutam resursa daca este disponibila
                    if (ImprumutaResursaSpecifica(resursa))
                    {
                        Console.WriteLine($"Cartea '{resursa.Titlu}' imprumutata cu succes.");
                    }
                    else
                    {
                        Console.WriteLine($"Cartea '{resursa.Titlu}' nu a putut fi imprumutata.");
                    }
                }
            }

            Console.WriteLine("Doriti sa continuati cautarea? (1 pentru da, 0 pentru nu)");
            optiune = int.Parse(Console.ReadLine());
        } while (optiune != 0);
    }

    // Metoda privata pentru a incerca imprumutul unei resurse specifice
    private bool ImprumutaResursaSpecifica(Biblioteca resursa)
    {
        Console.WriteLine(
            $"Se incearca imprumutul resursei: {resursa.Titlu}, Stoc: {resursa.Stoc}, Numar imprumuturi curente: {nrImprumut}, Maxim imprumuturi: {nrMaxImprumut}");

        if (resursa.Stoc > 0 && nrImprumut < nrMaxImprumut)
        {
            if (resursa.Tip == "Manual" && !cursuriInscrise.Contains(resursa.Curs))
            {
                Console.WriteLine("Nu sunteti inscris la cursul necesar pentru a imprumuta acest manual.");
                return false;
            }

            resursa.Stoc--;
            ImprumutariPlus();
            istoricImprumutari.Add(resursa);
            return true;
        }
        else if (resursa.Stoc == 0)
        {
            Console.WriteLine("Resursa nu este disponibila momentan.");
            return false;
        }
        else
        {
            Console.WriteLine("Ati atins limita maxima de imprumuturi.");
            return false;
        }
    }

    // Metoda pentru a rezerva o resursa
    public void RezervaResursa(Biblioteca resursa)
    {
        if (!rezervari.Contains(resursa))
        {
            rezervari.Add(resursa);
            Console.WriteLine($"Ati rezervat '{resursa.Titlu}'. Veti fi notificat cand devine disponibila.");
        }
        else
        {
            Console.WriteLine($"Ati rezervat deja '{resursa.Titlu}'.");
        }
    }

    // Metoda pentru a returna o resursa
    public void ReturneazaResursa()
    {
        Console.WriteLine("Dati titlul resursei pe care doriti sa o returnati: ");
        string titluCautare = Console.ReadLine();
        foreach (Biblioteca resursa in istoricImprumutari)
        {
            if (resursa.Titlu.Equals(titluCautare))
            {
                Console.WriteLine("Ati returnat resursa la timp? (da/nu)");
                string raspuns = Console.ReadLine().ToLower();
                if (raspuns == "da")
                {
                    resursa.Stoc++;
                    nrImprumut--;
                    istoricImprumutari.Remove(resursa);
                    Console.WriteLine($"Ati returnat '{resursa.Titlu}' cu succes.");
                }
                else
                {
                    AplicaPenalizare();
                    resursa.Stoc++;
                    nrImprumut--;
                    istoricImprumutari.Remove(resursa);
                    Console.WriteLine($"Ati returnat '{resursa.Titlu}' cu intarziere si ati fost penalizat.");
                }

                break;
            }
        }
    }

    // Metoda privata pentru a aplica penalizarea
    private void AplicaPenalizare()
    {
        if (nrMaxImprumut > 1)
        {
            nrMaxImprumut--;
            Console.WriteLine($"Numarul maxim de imprumuturi a fost redus la {nrMaxImprumut}.");
        }
        else
        {
            Console.WriteLine("Nu se mai poate aplica penalizare, limita de imprumut este deja la minim.");
        }
    }

    // Metoda pentru a extinde perioada de imprumut
    public void ExtindeImprumut()
    {
        if (esteAvansat)
        {
            Console.WriteLine("Dati titlul resursei pentru care doriti sa extindeti perioada de imprumut: ");
            string titluCautare = Console.ReadLine();
            foreach (Biblioteca resursa in istoricImprumutari)
            {
                if (resursa.Titlu.Equals(titluCautare))
                {
                    Console.WriteLine($"Perioada de imprumut pentru '{resursa.Titlu}' a fost extinsa cu 3 saptamani.");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Numai utilizatorii avansati pot extinde perioada de imprumut.");
        }
    }

    // Metoda pentru a vizualiza istoricul imprumuturilor
    public void Istoric()
    {
        Console.WriteLine("Istoricul imprumuturilor este: ");
        foreach (Biblioteca resurse in istoricImprumutari)
        {
            resurse.AfisareResursa();
        }
    }

    // Metoda pentru a adauga un curs unui student
    public void AdaugaCurs(string curs)
    {
        if (!cursuriInscrise.Contains(curs))
        {
            cursuriInscrise.Add(curs);
        }
    }
}