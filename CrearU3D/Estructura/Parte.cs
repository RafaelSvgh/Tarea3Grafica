namespace CrearU3D.Estructura;
public class Parte: InterfaceFigura
{
    public Dictionary<string, Cara> Caras { get; set; } = new Dictionary<string, Cara>(); 
    public Punto Centro { get; set; } = new Punto(); 
    public Parte(Dictionary<string, Cara> caras)
    {
        Caras = caras;
        Centro = CalcularCentro();
    }

    public Parte() { }

    public Cara? ObtenerCara(string id)
    {
        return Caras.ContainsKey(id) ? Caras[id] : null;
    }

    public void Dibujar()
    {
        foreach (Cara cara in Caras.Values)
            cara.Dibujar();
    }
    public void Rotar(float angX, float angY, float angZ)
    {
        Punto centro = CalcularCentro();
        foreach (var cara in Caras.Values)
        {
            cara.SetCentro(centro);
            cara.Rotar(angX, angY, angZ);
        }
    }

    public void Trasladar(float deltaX, float deltaY, float deltaZ)
    {
        foreach (var cara in Caras.Values)
            cara.Trasladar(deltaX, deltaY, deltaZ);
    }

    public void Escalar(float factor)
    {
        Punto centro = CalcularCentro();
        foreach (var cara in Caras.Values)
        {
            cara.SetCentro(centro);
            cara.Escalar(factor);
        }
            
    }
    private Punto CalcularCentro()
    {
        var vertices = Caras.Values.SelectMany(c => c.Vertices.Values).ToList();
        return new Punto(vertices.Average(v => v.X), vertices.Average(v => v.Y), vertices.Average(v => v.Z));
    }

}
