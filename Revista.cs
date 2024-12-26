namespace Proiect;

public class Revista:Resursele_Bibliotecii
{
    public string Editie { get; set; }
    public int Numar_publicare { get; set; }
    public int Luna_publicare { get; set; }
    
    public Revista(int id, string titlu, string autor, string tip, string gen, DateTime data_Publicarii,
        string stoc_Disponibil,string editie,int numarPublicare,int lunaPublicare) : 
        base(id, titlu, autor, tip, gen, data_Publicarii, stoc_Disponibil)
    {
        Editie = editie;
        Numar_publicare = numarPublicare;
        Luna_publicare = lunaPublicare;
    }
}