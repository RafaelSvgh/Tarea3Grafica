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
            new ([vertices[0], vertices[1], vertices[2], vertices[3]], color),
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

    public static List<List<Vertice>> ProcesarArchivoVertices(string rutaArchivo)
    {
        List<List<Vertice>> partes = [];
        List<Vertice> verticesActuales = [];
        
        foreach (string linea in File.ReadAllLines(rutaArchivo))
        {
            // Si es comentario o línea vacía
            if (string.IsNullOrWhiteSpace(linea))
                continue;

            if (linea.StartsWith("#"))
            {
                // Nueva parte - guardar la anterior si existe
                if (verticesActuales != null && verticesActuales.Count > 0)
                {
                    partes.Add(verticesActuales);
                }
                verticesActuales = new List<Vertice>();
                continue;
            }

            // Procesar línea de vértice
            string[] coordenadas = linea.Split(',');
            if (
                float.TryParse(coordenadas[0], out float x) &&
                float.TryParse(coordenadas[1], out float y) &&
                float.TryParse(coordenadas[2], out float z))
            {
                verticesActuales?.Add(new Vertice(x/10, y/10, z / 10));
            }
        }

        // Añadir la última parte si existe
        if (verticesActuales != null && verticesActuales.Count > 0)
        {
            partes.Add(verticesActuales);
        }

        return partes;
    }

}
