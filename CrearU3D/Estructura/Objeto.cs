namespace CrearU3D.Estructura;
public class Objeto : InterfaceFigura
{
    public Dictionary<string, Parte> Partes { get; set; } = new Dictionary<string, Parte>();
    public Punto Centro { get; set; } = new Punto();
    public Objeto(Dictionary<string, Parte> partes, Punto centro)
    {
        Partes = partes;
        Centro = centro;
    }
    public Objeto() { }

    public void AgregarParte(string id, Parte parte)
    {
        Partes[id] = parte;
    }

    public void EliminarParte(string id)
    {
        Partes.Remove(id);
    }

    public Parte? ObtenerParte(string id)
    {
        return Partes.ContainsKey(id) ? Partes[id] : null;
    }

    public void Dibujar()
    {
        foreach (Parte parte in Partes.Values)
            parte.Dibujar();
    }

    public void Rotar(float angX, float angY, float angZ)
    {
        Punto centro = CalcularCentro();
        foreach (var parte in Partes.Values)
            foreach (var cara in parte.Caras.Values)
            {
                cara.SetCentro(centro);
                cara.Rotar(angX, angY, angZ);
            }
    }

    public void Trasladar(float deltaX, float deltaY, float deltaZ)
    {
        foreach (var parte in Partes.Values)
            parte.Trasladar(deltaX, deltaY, deltaZ);
    }

    public void Escalar(float factor)
    {
        Punto centro = CalcularCentro();
        foreach (var parte in Partes.Values)
            foreach (var cara in parte.Caras.Values)
            {
                cara.SetCentro(centro);
                cara.Escalar(factor);
            }
    }

    public Punto CalcularCentro()
    {
        var vertices = Partes.Values.SelectMany(p => p.Caras.Values)
                                    .SelectMany(c => c.Vertices.Values).ToList();
        return new Punto(vertices.Average(v => v.X), vertices.Average(v => v.Y), vertices.Average(v => v.Z));
    }

}
