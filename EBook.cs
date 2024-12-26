namespace Proiect;

public class EBook:Resursele_Bibliotecii
{
    public string Link_descarcare { get; set; }
    public EBook(int id, string titlu, string autor, string tip, string gen, DateTime data_Publicarii,
        string stoc_Disponibil,string linkDescarcare) : base(id, titlu, autor, tip, gen, data_Publicarii,
        stoc_Disponibil)
    {
     Link_descarcare = linkDescarcare;   
    }
    
}