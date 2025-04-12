using OpenTK.Graphics;

namespace CrearU3D;

public static class Utils
{
    public static Parte CrearBloque3D(List<Vertice> vertices, Color4 color)
    {
        if (vertices.Count != 8)
            throw new ArgumentException("Se requieren exactamente 8 vértices para un bloque.");

        var caras = new List<Cara>
        {
            // Cara frontal
            new([vertices[0], vertices[1], vertices[2], vertices[3]], color),
            // Cara trasera
            new([vertices[4], vertices[5], vertices[6], vertices[7]], color),
            // Cara lateral izquierda
            new([vertices[0], vertices[4], vertices[7], vertices[3]], color),
            // Cara lateral derecha
            new([vertices[1], vertices[5], vertices[6], vertices[2]], color),
            // Cara superior
            new([vertices[0], vertices[4], vertices[5], vertices[1]], color),
            // Cara inferior
            new([vertices[3], vertices[7], vertices[6], vertices[2]], color)
        };
        return new Parte(caras);
    }
}
