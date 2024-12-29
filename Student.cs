namespace proiectPOO;

public class Student

{
    private int nrImprumut;
    private List<Resurse> carti;
    private List<Resurse> istoricImprumutari;

    public Student(List<Resurse> carti)
    {
        this.nrImprumut = 0;
        this.carti = carti;
    }

    public virtual List<Resurse> IstoricImprumutari
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

    public List<Resurse> Carti
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
                    foreach (Resurse resurse in carti)
                    {
                        if (resurse.Id == idCautare)
                            resurse.AfisareResursa();
                    }
                    break;
                case 2:
                    Console.WriteLine("dati titlul dupa care doriti sa cautati: ");
                    string titluCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Titlu.Equals(titluCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 3:
                    Console.WriteLine("dati autorul dupa care doriti sa cautati: ");
                    string autorCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Autor.Equals(autorCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 4:
                    Console.WriteLine("dati tipul dupa care doriti sa cautati: ");
                    string tipCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Tip.Equals(tipCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 5:
                    Console.WriteLine("dati genul dupa care doriti sa cautati: ");
                    string genCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Gen.Equals(genCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 6:
                    Console.WriteLine("dati data publicarii dupa care doriti sa cautati: ");
                    DateTime dataPublicarii = DateTime.Parse(Console.ReadLine());
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.DataPublicarii.Equals(dataPublicarii))
                            resurse.AfisareResursa();
                    }
                    break;
                case 7:
                    Console.WriteLine("dati stocul dupa care doriti sa cautati: ");
                    int stocCautare = int.Parse(Console.ReadLine());
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Stoc == stocCautare)
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
        foreach (Resurse resurse in carti)
        {
            if (resurse.Titlu.Equals(titluCautare))
            {
                if(resurse.Stoc > 0)
                {
                    resurse.Stoc--;
                    ImprumutariPlus();

                    Tip tipResursa = resurse.Tip;
                    if (tipResursa == Tip.CarteDeLectura)
                    {
                        CarteDeLectura carteDeLectura = (CarteDeLectura)resurse;
                        CarteDeLectura carte = new CarteDeLectura(resurse.Id, resurse.Titlu, resurse.Autor, resurse.Tip, resurse.Gen, resurse.DataPublicarii, resurse.Stoc);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa == Tip.EBook)
                    {
                        EBook ebook = (EBook)resurse;
                        EBook carte = new EBook(ebook.Id, ebook.Titlu, ebook.Autor, ebook.Tip, ebook.Gen,
                            ebook.DataPublicarii, ebook.Stoc, ebook.LinkDescarcare);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa == Tip.Manual)
                    {
                        Manual manual = (Manual)resurse;
                        Manual carte = new Manual(manual.Id, manual.Titlu, manual.Autor, manual.Tip,manual.Gen,manual.DataPublicarii,manual.Stoc,manual.Curs);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa == Tip.Revista)
                    {
                        Revista revista = (Revista)resurse;
                        Revista carte = new Revista(revista.Id,revista.Titlu,revista.Autor,revista.Tip,revista.Gen,revista.DataPublicarii,revista.Stoc,revista.Editie,revista.Numar,revista.LunaPublicare);
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
        foreach (Resurse resurse in istoricImprumutari)
        {
            resurse.AfisareResursa();
        }
    }
}public class Student
{
    private int nrImprumut;
    private List<Resurse> carti;
    private List<Resurse> istoricImprumutari;

    public Student(List<Resurse> carti)
    {
        this.nrImprumut = 0;
        this.carti = carti;
    }

    public virtual List<Resurse> IstoricImprumutari
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

    public List<Resurse> Carti
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
                    foreach (Resurse resurse in carti)
                    {
                        if (resurse.Id == idCautare)
                            resurse.AfisareResursa();
                    }
                    break;
                case 2:
                    Console.WriteLine("dati titlul dupa care doriti sa cautati: ");
                    string titluCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Titlu.Equals(titluCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 3:
                    Console.WriteLine("dati autorul dupa care doriti sa cautati: ");
                    string autorCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Autor.Equals(autorCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 4:
                    Console.WriteLine("dati tipul dupa care doriti sa cautati: ");
                    string tipCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Tip.Equals(tipCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 5:
                    Console.WriteLine("dati genul dupa care doriti sa cautati: ");
                    string genCautare = Console.ReadLine();
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Gen.Equals(genCautare))
                            resurse.AfisareResursa();
                    }
                    break;
                case 6:
                    Console.WriteLine("dati data publicarii dupa care doriti sa cautati: ");
                    DateTime dataPublicarii = DateTime.Parse(Console.ReadLine());
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.DataPublicarii.Equals(dataPublicarii))
                            resurse.AfisareResursa();
                    }
                    break;
                case 7:
                    Console.WriteLine("dati stocul dupa care doriti sa cautati: ");
                    int stocCautare = int.Parse(Console.ReadLine());
                    foreach (Resurse resurse in carti)
                    {
                        if(resurse.Stoc == stocCautare)
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
        foreach (Resurse resurse in carti)
        {
            if (resurse.Titlu.Equals(titluCautare))
            {
                if(resurse.Stoc > 0)
                {
                    resurse.Stoc--;
                    ImprumutariPlus();

                    Tip tipResursa = resurse.Tip;
                    if (tipResursa == Tip.CarteDeLectura)
                    {
                        CarteDeLectura carteDeLectura = (CarteDeLectura)resurse;
                        CarteDeLectura carte = new CarteDeLectura(resurse.Id, resurse.Titlu, resurse.Autor, resurse.Tip, resurse.Gen, resurse.DataPublicarii, resurse.Stoc);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa == Tip.EBook)
                    {
                        EBook ebook = (EBook)resurse;
                        EBook carte = new EBook(ebook.Id, ebook.Titlu, ebook.Autor, ebook.Tip, ebook.Gen,
                            ebook.DataPublicarii, ebook.Stoc, ebook.LinkDescarcare);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa == Tip.Manual)
                    {
                        Manual manual = (Manual)resurse;
                        Manual carte = new Manual(manual.Id, manual.Titlu, manual.Autor, manual.Tip,manual.Gen,manual.DataPublicarii,manual.Stoc,manual.Curs);
                        istoricImprumutari.Add(carte);
                    }
                    else if (tipResursa == Tip.Revista)
                    {
                        Revista revista = (Revista)resurse;
                        Revista carte = new Revista(revista.Id,revista.Titlu,revista.Autor,revista.Tip,revista.Gen,revista.DataPublicarii,revista.Stoc,revista.Editie,revista.Numar,revista.LunaPublicare);
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
        foreach (Resurse resurse in istoricImprumutari)
        {
            resurse.AfisareResursa();
        }
    }
}
