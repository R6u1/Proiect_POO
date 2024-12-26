namespace Proiect;

public class Resursele_Bibliotecii
{
    public int ID { get; set; }
    public string Titlu { get; set; }
    public string Autor { get; set; }
    public string Tip { get; set; }
    public string Gen { get; set; }
    public DateTime Data_Publicarii { get; set; }
    public string Stoc_Disponibil { get; set; }

    public Resursele_Bibliotecii(int id, string titlu, string autor, string tip, string gen, DateTime data_Publicarii,
        string stoc_Disponibil)
    {
        ID = id;
        Titlu = titlu;
        Autor = autor;
        Tip = tip;
        Gen = gen;
        Data_Publicarii = data_Publicarii;
        Stoc_Disponibil= stoc_Disponibil;
    }
    
}