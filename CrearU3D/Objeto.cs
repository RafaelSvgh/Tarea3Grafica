using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace CrearU3D;

public class Objeto
{
    public List<Parte> Partes { get;private set; }
    public Vertice Posicion { get; set; }
    public Objeto(List<Parte> partes, Vertice posicion)
    {
        Partes = partes;
        Posicion = posicion;
    }

    public Objeto(Vertice posicion, Color4 color, string ruta)
    {
        Partes = [];
        Posicion = posicion;
        List<List<Vertice>> listaVertices = [];
        listaVertices = Utils.ProcesarArchivoVertices(ruta);
        if (listaVertices.Count > 0)
        {
            foreach (List<Vertice> vertices in listaVertices)
                this.Partes.Add(Utils.CrearBloque3D(vertices, color));
        }
        else
        {
            throw new Exception("No hay puntos que mostrar");
        }
    }

    public void Dibujar()
    {
        GL.PushMatrix();
        GL.Translate(Posicion.X, Posicion.Y, Posicion.Z);
        foreach (var parte in Partes)
        {
            parte.Dibujar();
        }

        GL.PopMatrix();
    }

}
