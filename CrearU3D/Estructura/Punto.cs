namespace CrearU3D.Estructura;
public class Punto
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Punto(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Punto() { }
}
