using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace CrearU3D;

public class Objeto
{
    public List<Parte> Partes { get; private set; }
    public Vertice Posicion { get; set; }

    public Vector3 Rotacion { get; set; } = Vector3.Zero;
    public Objeto(List<Parte> partes, Vertice posicion)
    {
        Partes = partes;
        Posicion = posicion;
    }

    public void Dibujar()
    {
        GL.PushMatrix();
        GL.Translate(Posicion.X, Posicion.Y, Posicion.Z);
        GL.Rotate(Rotacion.X, Vector3.UnitX); // Rotación X
        GL.Rotate(Rotacion.Y, Vector3.UnitY); // Rotación Y
        GL.Rotate(Rotacion.Z, Vector3.UnitZ); // Rotación Z
        foreach (var parte in Partes)
        {
            parte.Dibujar();
        }

        GL.PopMatrix();
    }

}
