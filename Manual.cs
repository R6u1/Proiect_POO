namespace Proiect;

public class Manual:Resursele_Bibliotecii
{
    public string Camp { get; set; }
    public Manual(int id, string titlu, string autor, string tip, string gen, DateTime data_Publicarii,
        string stoc_Disponibil,string camp) : base(id, titlu, autor, tip, gen,
        data_Publicarii,stoc_Disponibil)
    {
        Camp = camp;
    }
}