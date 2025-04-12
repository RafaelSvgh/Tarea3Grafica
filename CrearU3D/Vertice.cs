using OpenTK;
namespace CrearU3D;

public class Vertice
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vertice(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Comparación por valor (no por referencia)
    public override bool Equals(object? obj)
    {
        if (obj is Vertice other)
           return X == other.X && Y == other.Y && Z == other.Z;
       return false;
    }

    // Hash único basado en coordenadas
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }
}
