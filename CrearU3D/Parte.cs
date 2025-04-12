
using System.Collections;

namespace CrearU3D;

public class Parte
{
    public List<Cara> Caras { get; private set; }

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

    public Vertice CentroDeMasa()
    {
        HashSet<Vertice> verticesUnicos = new HashSet<Vertice>();

        foreach (var cara in Caras)
        {
            foreach (var vertice in cara.Vertices)
            {
                verticesUnicos.Add(vertice);
            }
        }

        // Suma todas las coordenadas
        float sumX = 0, sumY = 0, sumZ = 0;
        foreach (var vertice in verticesUnicos)
        {
            sumX += vertice.X;
            sumY += vertice.Y;
            sumZ += vertice.Z;
        }

        // Calcula el promedio (centro de masa)
        int totalVertices = verticesUnicos.Count;
        return new Vertice(
            sumX / totalVertices,
            sumY / totalVertices,
            sumZ / totalVertices
        );
    }

}
