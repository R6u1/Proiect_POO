namespace Proiect_POO_;

public class Administrator
{
    // Proprietate pentru numele administratorului
    public string Name { get; set; }
    
    // Constructor pentru clasa Administrator
    public Administrator(string name)
    {
        Name = name;
    }
    
    // Metoda pentru adaugarea unei resurse in biblioteca
    public void AdaugaRESURSA(Biblioteca r)
    {
        Biblioteca.AdaugaResursa(r);
    }
    
    // Metoda pentru stergerea unei resurse din biblioteca dupa ID
    public void StergeRESURSA(int id)
    {
        Biblioteca.StergeResursa(id);
    }
    
    // Metoda pentru vizualizarea resurselor din biblioteca
    public void VerificaResursa()
    {
        Biblioteca.VizualizeazaResurse();
    }
    
    // Metoda pentru actualizarea stocului unei resurse
    public void ActualizareStoc(int id, int newStoc)
    {
        Biblioteca.ActualizeazaStoc(id, newStoc);
    }
    
    // Metoda pentru inscrierea unui student la un curs
    public void InscrieStudentLaCurs(Student student, string curs)
    {
        student.AdaugaCurs(curs);
        Console.WriteLine($"Studentul a fost inscris la cursul {curs}.");
    }
    
    // Metoda pentru vizualizarea cursurilor la care este inscris un student
    public void VizualizeazaCursuriStudent(Student student)
    {
        List<string> cursuri = student.GetCursuriInscrise();
        if (cursuri.Count == 0)
        {
            Console.WriteLine("Studentul nu este inscris la niciun curs.");
        }
        else
        {
            Console.WriteLine("Cursurile la care este inscris studentul:");
            foreach (string curs in cursuri)
            {
                Console.WriteLine($"- {curs}");
            }
        }
    }
    
    // Adaugare utilizator nou
    public void AdaugaUtilizator(List<Student> studenti, bool esteAvansat = false)
    {
        Console.WriteLine("Introduceti numele studentului:");
        string nume = Console.ReadLine();
        List<Biblioteca> carti = Biblioteca.resurse;
        List<Biblioteca> istoric = new List<Biblioteca>();
        Student studentNou = new Student(esteAvansat ? 5 : 3, carti, istoric, esteAvansat, nume);
        studenti.Add(studentNou);
        Console.WriteLine($"Utilizatorul {nume} a fost adaugat cu succes.");
    }
    
    // Stergere conturi inactive
    public void StergeConturiInactive(List<Student> studenti)
    {
        Console.WriteLine("Introduceti numarul de zile de inactivitate pentru a considera un cont inactiv:");
        if (int.TryParse(Console.ReadLine(), out int zileInactivitate))
        {
            DateTime dataLimita = DateTime.Now.AddDays(-zileInactivitate);
            var conturiDeSters = studenti.Where(s => s.UltimaActivitate <= dataLimita).ToList();

            foreach (var student in conturiDeSters)
            {
                studenti.Remove(student);
                Console.WriteLine($"Contul studentului {student.Nume} a fost sters din cauza inactivitatii.");
            }
        }
        else
        {
            Console.WriteLine("Introduceti un numar valid de zile.");
        }
    }
    
    // Monitorizarea rezervarilor si efectuarea imprumuturilor pentru resursele rezervate
    public void MonitorizeazaRezervari(List<Student> studenti)
    {
        foreach (Student student in studenti)
        {
            List<Biblioteca> rezervari = student.GetRezervari();
            foreach (Biblioteca resursa in rezervari.ToList()) // Folosim ToList() pentru a evita exceptia de modificare a colectiei
            {
                if (resursa.Stoc > 0)
                {
                    // Efectuam imprumutul
                    resursa.Stoc--;
                    student.ImprumutariPlus();
                    student.IstoricImprumutari.Add(resursa);
                    student.StergeRezervare(resursa);
                    Console.WriteLine($"Resursa '{resursa.Titlu}' a fost imprumutata studentului {student.Nume}.");
                }
            }
        }
    }
    
    // Metoda pentru incarcarea studentilor dintr-un fisier
    public List<Student> IncarcaStudentiDinFisier(string fileName)
    {
        List<Student> studenti = new List<Student>();
        if (File.Exists(fileName))
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string linie;
                while ((linie = r.ReadLine()) != null)
                {
                    string[] parts = linie.Split('|');
                    if (parts.Length >= 3) // Presupunem cel putin statutul avansat, numele si eventual cursurile
                    {
                        try
                        {
                            bool esteAvansat = bool.Parse(parts[0]);
                            string nume = parts[1];
                            List<Biblioteca> carti = Biblioteca.resurse;
                            List<Biblioteca> istoric = new List<Biblioteca>();
                            Student student = new Student(esteAvansat ? 5 : 3, carti, istoric, esteAvansat, nume);
                            // Daca sunt listate cursuri:
                            if (parts.Length > 2)
                            {
                                for (int i = 2; i < parts.Length; i++)
                                {
                                    student.AdaugaCurs(parts[i]);
                                }
                            }
                            studenti.Add(student);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Eroare la procesarea liniei student: {linie}\n{ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Linie incompleta de student: {linie}");
                    }
                }
            }
            Console.WriteLine($"Studentii au fost incarcati din '{fileName}'.");
        }
        else
        {
            Console.WriteLine($"Fisierul '{fileName}' nu exista.");
        }
        return studenti;
    }
}