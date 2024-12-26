namespace Proiect;

public class Carte_de_lectura:Resursele_Bibliotecii
{
    public Carte_de_lectura(int id, string titlu, string autor, string tip, string gen, DateTime data_Publicarii,
        string stoc_Disponibil) : base(id, titlu, autor, tip, gen, data_Publicarii,
        stoc_Disponibil)
    {
        
    }
}