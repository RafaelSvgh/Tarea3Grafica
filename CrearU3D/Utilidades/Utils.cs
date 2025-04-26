using CrearU3D.Estructura;
using OpenTK.Graphics;

namespace CrearU3D.Utilidades;

public static class Utils
{
    public static Parte CrearBloque3D(List<Punto> vertices, Color4 color)
    {
        if (vertices.Count != 8)
            throw new ArgumentException("Se requieren exactamente 8 vértices para un bloque.");

        var caras = new Dictionary<string, Cara>
           {
               // Cara frontal
               { "frontal", new Cara(new Dictionary<string, Punto>
               {
                   { "v1", vertices[0] },
                   { "v2", vertices[1] },
                   { "v3", vertices[2] },
                   { "v4", vertices[3] }
               }, color) },
               // Cara trasera
               { "trasera", new Cara(new Dictionary<string, Punto>
               {
                   { "v1", vertices[4] },
                   { "v2", vertices[5] },
                   { "v3", vertices[6] },
                   { "v4", vertices[7] }
               }, color) },
               // Cara lateral izquierda
               { "lateralIzquierda", new Cara(new Dictionary<string, Punto>
               {
                   { "v1", vertices[0] },
                   { "v2", vertices[4] },
                   { "v3", vertices[7] },
                   { "v4", vertices[3] }
               }, color) },
               // Cara lateral derecha
               { "lateralDerecha", new Cara(new Dictionary<string, Punto>
               {
                   { "v1", vertices[1] },
                   { "v2", vertices[5] },
                   { "v3", vertices[6] },
                   { "v4", vertices[2] }
               }, color) },
               // Cara superior
               { "superior", new Cara(new Dictionary<string, Punto>
               {
                   { "v1", vertices[0] },
                   { "v2", vertices[4] },
                   { "v3", vertices[5] },
                   { "v4", vertices[1] }
               }, color) },
               // Cara inferior
               { "inferior", new Cara(new Dictionary<string, Punto>
               {
                   { "v1", vertices[3] },
                   { "v2", vertices[7] },
                   { "v3", vertices[6] },
                   { "v4", vertices[2] }
               }, color) }
           };
        return new Parte { Caras = caras };
    }
}
