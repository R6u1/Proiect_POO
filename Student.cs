namespace proiectPOO;

public class Student
{
    private int nrImprumut;
    private int nrMaxImprumut;
    private List<Biblioteca> carti;
    private List<Biblioteca> istoricImprumutari;

    public Student(int nrImprumut, int nrMaxImprumut, List<Biblioteca> carti, List<Biblioteca> istoricImprumutari)
    {
        this.nrImprumut = 0;
        this.nrMaxImprumut = nrMaxImprumut;
        this.carti = carti;
        this.istoricImprumutari = istoricImprumutari;
    }

    public List<Biblioteca> IstoricImprumutari
    {
        get => istoricImprumutari;
        set => istoricImprumutari = value;
    }

    private void ImprumutariPlus()
    {
        nrImprumut++;
    }
    
    public int NrImprumut
    {
        get => nrImprumut;
        set => nrImprumut = value;
    }

    public List<Biblioteca> Carti
    {
        get => carti;
        set => carti = value;
    }
    
    public void cautareResurse()
    {
        Console.WriteLine("1 - id, 2 - titlu, 3 - autor, 4 - tip, 5 - gen, 6- data publicarii, 7 - stoc");
        Console.WriteLine("Alegeti dupa ce criteriu doriti sa cautati cartea: ");
        int optiune = int.Parse(Console.ReadLine());
        do
        {
            switch (optiune)
            {
                case 1:
                    Console.WriteLine("dati id-ul dupa care doriti sa cautati: ");
                    int idCautare = int.Parse(Console.ReadLine());
                    foreach (Biblioteca resurse in carti)
                    {
                        if (resurse.ID == idCautare)
                            resurse.AfisareResursa();
                        
                    }
                    break;
                case 2:
                    Console.WriteLine("dati titlul dupa care doriti sa cautati: ");
                    string titluCautare = Console.ReadLine();
                    foreach (Biblioteca resurse in carti)
                    {
                        if (resurse.Titlu.Equals(titluCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 3:
                    Console.WriteLine("dati autorul dupa care doriti sa cautati: ");
                    string autorCautare = Console.ReadLine();
                    foreach (Biblioteca resurse in carti)
                    {
                        if (resurse.Autor.Equals(autorCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 4:
                    Console.WriteLine("dati tipul dupa care doriti sa cautati: ");
                    string tipCautare = Console.ReadLine();
                    foreach (Biblioteca resurse in carti)
                    {
                        if (resurse.Tip.Equals(tipCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 5:
                    Console.WriteLine("dati genul dupa care doriti sa cautati: ");
                    string genCautare = Console.ReadLine();
                    foreach (Biblioteca resurse in carti)
                    {
                        if (resurse.Gen.Equals(genCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 6:
                    Console.WriteLine("dati data publicarii dupa care doriti sa cautati: ");
                    DateTime dataPublicarii = DateTime.Parse(Console.ReadLine());
                    foreach (Biblioteca resurse in carti)
                    {
                        if (resurse.DataPublicare.Equals(dataPublicarii))
                            resurse.AfisareResursa();
                    }
                    break;
                case 7:
                    Console.WriteLine("dati stocul dupa care doriti sa cautati: ");
                    int stocCautare = int.Parse(Console.ReadLine());
                    foreach (Biblioteca resurse in carti)
                    {
                        if (resurse.Stoc == stocCautare)
                            resurse.AfisareResursa();
                    }
                    break;
                case 0:
                    break;

            }
            
        } while (optiune != 0);
    }

    public void ImprumutareResursa()
    {
        Console.WriteLine("dati titlul resursei pe care doriti sa o imprumutati: ");
        string titluCautare = Console.ReadLine();
        foreach (Biblioteca resurse in carti)
        {
            if (resurse.Titlu.Equals(titluCautare))
            {
                if(resurse.Stoc > 0)
                {
                    resurse.Stoc--;
                    ImprumutariPlus();

                    string tipResursa = resurse.Tip;
                    if (tipResursa.Equals("Carte de lectura"))
                    {
                        Biblioteca carte = new Biblioteca(resurse.ID, resurse.Titlu, resurse.Autor, resurse.Gen, resurse.DataPublicare, resurse.Stoc);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa.Equals("EBook"))
                    {
                        Biblioteca carte = new Biblioteca(resurse.ID, resurse.Titlu, resurse.Autor, resurse.Gen, resurse.DataPublicare, resurse.Stoc,resurse.Link);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa.Equals("Manual"))
                    {
                        Biblioteca carte = new Biblioteca(resurse.ID, resurse.Titlu, resurse.Autor, resurse.Gen, resurse.DataPublicare, resurse.Stoc,resurse.Curs);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa.Equals("Revista"))
                    {
                        Biblioteca carte = new Biblioteca(resurse.ID, resurse.Titlu, resurse.Autor, resurse.Gen, resurse.DataPublicare, resurse.Stoc, resurse.Editie, resurse.NrPublicare, resurse.LunaPublicare);
                        istoricImprumutari.Add(carte);
                    }
                }
                else Console.WriteLine("cartea pe care doriti sa o imprumutati nu mai e pe stoc");
            }
        }
    }

    public void Istoric()
    {
        Console.WriteLine("istoricul imprumutarilor este: ");
        foreach (Biblioteca resurse in istoricImprumutari)
        {
            resurse.AfisareResursa();
        }
    }
}
