
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;

namespace CrearU3D.Estructura;
public class Escenario: InterfaceFigura
{
    public Dictionary<string, Objeto> Objetos { get; set; } = new Dictionary<string, Objeto>();
    public Punto Centro { get; set; } = new Punto(); 
    public Color4 ColorDeFondo { get; set; } = Color4.Black;
    public Escenario() { }

    public Escenario(Color4 colorDeFondo)
    {
        ColorDeFondo = colorDeFondo;
        Centro = new Punto(0, 0, 0);
    }

    public void AgregarObjeto(string id,Objeto objeto)
    {
        Objetos[id] = objeto;
    }

    public void EliminarObjeto(string id)
    {
        if (Objetos.ContainsKey(id))
            Objetos.Remove(id);
    }

    public Objeto? ObtenerObjeto(string id)
    {
        return Objetos.ContainsKey(id) ? Objetos[id] : null;
    }

    public void Dibujar()
    {
        foreach (var objeto in Objetos.Values)
            objeto.Dibujar();
    }

    public void Rotar(float angX, float angY, float angZ)
    {
        Punto centro = CalcularCentroDeMasa();
        foreach (var obj in Objetos.Values)
            foreach (var parte in obj.Partes.Values)
                foreach (var cara in parte.Caras.Values)
                {
                    cara.SetCentro(centro);
                    cara.Rotar(angX, angY, angZ);
                }
    }

    public void Trasladar(float deltaX, float deltaY, float deltaZ)
    {
        foreach (var obj in Objetos.Values)
            obj.Trasladar(deltaX, deltaY, deltaZ);
    }

    public void Escalar(float factor)
    {
        foreach (var obj in Objetos.Values)
            foreach (var parte in obj.Partes.Values)
                foreach (var cara in parte.Caras.Values)
                {
                    cara.SetCentro(Centro);
                    cara.Escalar(factor);
                }
    }

    public Punto CalcularCentroDeMasa()
    {
        if (Objetos == null || Objetos.Count == 0)
            return new Punto();
        float xProm = Objetos.Values.Average(obj => obj.CalcularCentro().X);
        float yProm = Objetos.Values.Average(obj => obj.CalcularCentro().Y);
        float zProm = Objetos.Values.Average(obj => obj.CalcularCentro().Z);

        return new Punto(xProm, yProm, zProm);
    }
}
