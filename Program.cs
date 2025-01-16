namespace Proiect_POO_
{
    class Program
    {
        // Lista statica pentru a stoca toti studentii
        static List<Student> studenti = new List<Student>();
        // Instanta statica a clasei Administrator
        static Administrator admin;
        // Calea catre fisierul studentilor
        static string studentiFilePath = "C://Users//Raul//RiderProjects//Proiect_POO_//Proiect_POO_//studenti.txt";
        // Calea catre fisierul bibliotecii
        static string bibliotecaFilePath = "C://Users//Raul//RiderProjects//Proiect_POO_//Proiect_POO_//biblioteca.txt";
        static void Main(string[] args)
        {
            // Initializam administratorul
            admin = new Administrator("Admin");

            // Incarcam datele din fisiere la pornire
            IncarcaDateDinFisiere();
            studenti = admin.IncarcaStudentiDinFisier(studentiFilePath);

            // Meniu principal
            while (true)
            {
                Console.WriteLine("\nMeniu Principal:");
                Console.WriteLine("1. Operatiuni pentru Studenti");
                Console.WriteLine("2. Operatiuni pentru Administrator");
                Console.WriteLine("3. Salveaza si Iesi");
                Console.Write("Alegeti o optiune: ");
                string optiune = Console.ReadLine();
                switch (optiune)
                {
                    case "1":
                        MeniuStudent();
                        break;
                    case "2":
                        MeniuAdministrator();
                        break;
                    case "3":
                        SalveazaDateInFisiere();
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        break;
                }
            }
        }
        
        static void MeniuStudent()
        {
            Console.Write("Introduceti numele studentului: ");
            string studentName = Console.ReadLine();
            Student student = studenti.FirstOrDefault(s => s.Nume == studentName);
            if (student != null)
            {
                while (true)
                {
                    Console.WriteLine("\nMeniu Student:");
                    Console.WriteLine("1. Cauta Resurse");
                    Console.WriteLine("2. Imprumuta Resursa");
                    Console.WriteLine("3. Rezerva Resursa");
                    Console.WriteLine("4. Returneaza Resursa");
                    Console.WriteLine("5. Extinde Imprumut");
                    Console.WriteLine("6. Vizualizeaza Istoric Imprumuturi");
                    Console.WriteLine("7. Inapoi");
                    Console.Write("Alegeti o optiune: ");
                    string optiune = Console.ReadLine();
                    switch (optiune)
                    {
                        case "1":
                            student.cautareResurse();
                            break;
                        case "2":
                            student.ImprumutareResursa();
                            break;
                        case "3":
                            Console.WriteLine("Introduceti titlul resursei pe care doriti sa o rezervati:");
                            string titluRezervare = Console.ReadLine();
                            Biblioteca resursaDeRezervat =
                                Biblioteca.resurse.FirstOrDefault(r => r.Titlu == titluRezervare);
                            if (resursaDeRezervat != null)
                            {
                                student.RezervaResursa(resursaDeRezervat);
                            }
                            else
                            {
                                Console.WriteLine("Resursa nu a fost gasita.");
                            }
                            break;
                        case "4":
                            student.ReturneazaResursa();
                            break;
                        case "5":
                            student.ExtindeImprumut();
                            break;
                        case "6":
                            student.Istoric();
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Optiune invalida. Incercati din nou.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Studentul nu a fost gasit.");
            }
        }
        
        static void MeniuAdministrator()
        {
            while (true)
            {
                Console.WriteLine("\nMeniu Administrator:");
                Console.WriteLine("1. Adauga Resursa");
                Console.WriteLine("2. Sterge Resursa");
                Console.WriteLine("3. Verifica Resurse");
                Console.WriteLine("4. Actualizeaza Stoc");
                Console.WriteLine("5. Inscrie Student la Curs");
                Console.WriteLine("6. Vizualizeaza Cursuri Student");
                Console.WriteLine("7. Adauga Utilizator");
                Console.WriteLine("8. Sterge Conturi Inactive");
                Console.WriteLine("9. Monitorizeaza Rezervari");
                Console.WriteLine("10. Inapoi");
                Console.Write("Alegeti o optiune: ");
                string optiune = Console.ReadLine();
                switch (optiune)
                {
                    case "1":
                        AdaugaResursa();
                        break;
                    case "2":
                        Console.Write("Introduceti ID-ul resursei de sters: ");
                        if (int.TryParse(Console.ReadLine(), out int idDeSters))
                        {
                            admin.StergeRESURSA(idDeSters);
                        }
                        else
                        {
                            Console.WriteLine("ID-ul trebuie sa fie un numar intreg.");
                        }
                        break;
                    case "3":
                        admin.VerificaResursa();
                        break;
                    case "4":
                        Console.Write("Introduceti ID-ul resursei pentru actualizare stoc: ");
                        if (int.TryParse(Console.ReadLine(), out int idActualizare))
                        {
                            Console.Write("Introduceti noul stoc: ");
                            if (int.TryParse(Console.ReadLine(), out int stocNou))
                            {
                                admin.ActualizareStoc(idActualizare, stocNou);
                            }
                            else
                            {
                                Console.WriteLine("Stocul nou trebuie sa fie un numar intreg.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID-ul trebuie sa fie un numar intreg.");
                        }
                        break;
                    case "5":
                        Console.Write("Introduceti numele studentului: ");
                        string studentName = Console.ReadLine();
                        Student student = studenti.FirstOrDefault(s => s.Nume.Equals(studentName, StringComparison.OrdinalIgnoreCase));
                        if (student != null)
                        {
                            Console.Write("Introduceti numele cursului: ");
                            string curs = Console.ReadLine();
                            admin.InscrieStudentLaCurs(student, curs);
                        }
                        else
                        {
                            Console.WriteLine("Studentul nu a fost gasit.");
                        }
                        break;
                    case "6":
                        Console.Write("Introduceti numele studentului: ");
                        string studentNameViz = Console.ReadLine();
                        Student studentViz = studenti.FirstOrDefault(s => s.Nume.Equals(studentNameViz, StringComparison.OrdinalIgnoreCase));
                        if (studentViz != null)
                        {
                            admin.VizualizeazaCursuriStudent(studentViz);
                        }
                        else
                        {
                            Console.WriteLine("Studentul nu a fost gasit.");
                        }
                        break;
                    case "7":
                        admin.AdaugaUtilizator(studenti);
                        break;
                    case "8":
                        admin.StergeConturiInactive(studenti);
                        break;
                    case "9":
                        admin.MonitorizeazaRezervari(studenti);
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        break;
                }
            }
        }
        
        static void AdaugaResursa()
        {
            Console.WriteLine("Alegeti tipul resursei:");
            Console.WriteLine("1. Carte de lectura");
            Console.WriteLine("2. Manual");
            Console.WriteLine("3. EBook");
            Console.WriteLine("4. Revista");
            Console.Write("Optiunea: ");
            string optiune = Console.ReadLine();
            Console.Write("Introduceti ID-ul: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Introduceti titlul: ");
            string titlu = Console.ReadLine();
            Console.Write("Introduceti autorul: ");
            string autor = Console.ReadLine();
            Console.Write("Introduceti genul: ");
            string gen = Console.ReadLine();
            Console.Write("Introduceti data publicarii (format: yyyy-MM-dd): ");
            DateTime dataPublicare = DateTime.Parse(Console.ReadLine());
            Console.Write("Introduceti stocul: ");
            int stoc = int.Parse(Console.ReadLine());
            Biblioteca resursa = null;
            switch (optiune)
            {
                case "1":
                    resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, stoc);
                    break;
                case "2":
                    Console.Write("Introduceti cursul asociat: ");
                    string curs = Console.ReadLine();
                    resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, stoc, curs);
                    break;
                case "3":
                    Console.Write("Introduceti link-ul: ");
                    string link = Console.ReadLine();
                    resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, link, stoc);
                    break;
                case "4":
                    Console.Write("Introduceti editia: ");
                    string editie = Console.ReadLine();
                    Console.Write("Introduceti numarul publicarii: ");
                    int nrPublicare = int.Parse(Console.ReadLine());
                    Console.Write("Introduceti luna publicarii: ");
                    int lunaPublicare = int.Parse(Console.ReadLine());
                    resursa = new Biblioteca(id, titlu, autor, gen, dataPublicare, stoc, editie, nrPublicare, lunaPublicare);
                    break;
                default:
                    Console.WriteLine("Optiune invalida.");
                    return;
            }
            if (resursa != null)
            {
                admin.AdaugaRESURSA(resursa);
            }
        }
        
        static void IncarcaDateDinFisiere()
        {
            Biblioteca.IncarcaDinFisier(bibliotecaFilePath); 
            // Incarcam studentii din fisier
            if (File.Exists(studentiFilePath))
            {
                string[] lines = File.ReadAllLines(studentiFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 3) // Cel putin 'esteAvansat', nume si un curs
                    {
                        try
                        {
                            // Prima parte ar trebui sa fie valoarea booleana pentru 'esteAvansat'
                            bool esteAvansat;
                            if (!bool.TryParse(parts[0], out esteAvansat))
                            {
                                Console.WriteLine($"Nu s-a putut parsa 'esteAvansat' pentru linia: {line}. Valoarea a fost: '{parts[0]}'. Setam la false implicit.");
                                esteAvansat = false;
                            }
                            // A doua parte este numele studentului
                            string nume = parts[1];
                            List<Biblioteca> carti = Biblioteca.resurse;
                            List<Biblioteca> istoric = new List<Biblioteca>();
                            // Generam un ID unic pentru fiecare student deoarece nu este furnizat in fisier
                            int id = studenti.Count + 1;
                            Student student = new Student(esteAvansat ? 5 : 3, carti, istoric, esteAvansat, nume);
                            student.NrImprumut = id;
                            // Adaugam cursurile, incepand de la a treia parte a liniei impartite
                            for (int i = 2; i < parts.Length; i++)
                            {
                                student.AdaugaCurs(parts[i]);
                            }
                            studenti.Add(student);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Eroare la procesarea liniei de date student: {line}");
                            Console.WriteLine($"Detalii eroare: {ex.Message}");
                            Console.WriteLine($"Numar de parti: {parts.Length}");
                            for (int i = 0; i < parts.Length; i++)
                            {
                                Console.WriteLine($"Partea[{i}]: {parts[i]}");
                            }
                            Console.ReadLine(); // Pauza pentru citire
                        }
                    }
                }
                Console.WriteLine($"Studentii au fost incarcati din fisierul '{studentiFilePath}'.");
                Console.WriteLine($"Studentii au fost incarcati din '{studentiFilePath}'.");
            }
            else
            {
                Console.WriteLine($"Fisierul '{studentiFilePath}' nu exista.");
            }
        }
        
        static void SalveazaDateInFisiere()
        {
            // Salvam resursele
            Biblioteca.SalveazaInFisier(bibliotecaFilePath);

            // Salvam studentii
            using (StreamWriter w = new StreamWriter(studentiFilePath))
            {
                foreach (Student student in studenti)
                {
                    // Presupunem ca studentii sunt acum salvati fara ID, doar nume, statut avansat si cursuri
                    string linie = $"{student.esteAvansat}|{student.Nume}";
                    foreach (string curs in student.CursuriInscrise)
                    {
                        linie += $"|{curs}";
                    }
                    w.WriteLine(linie);
                }
            }
            Console.WriteLine("Toate datele au fost salvate in fisierele corespunzatoare.");
        }
    }
}