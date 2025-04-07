
namespace CrearU3D;

public class Parte
{
    public List<Cara> Caras {  get; private set; }

    public Parte(List<Cara> caras)
    {
        Caras = caras;
    }

    public Parte() 
    {
        Caras = [];
    }

    public void Dibujar()
    {
        foreach (Cara cara in Caras)
            cara.Dibujar();
    }

}
