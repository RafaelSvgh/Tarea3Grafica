using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;

namespace CrearU3D.Estructura;
public class Cara: InterfaceFigura
{
    public Dictionary<string, Punto> Vertices { get; set; } = new Dictionary<string, Punto>();
    public Color4 Color { get; set; }
    public Punto Centro { get; set; } = new Punto();

    public Cara() { }

    public Cara(Dictionary<string, Punto> vertices, Color4 color = default)
    {
        Vertices = vertices;
        Color = color == default ? Color4.White : color;
    }

    public void SetCentro(Punto centro)
    {
        Centro = centro;
    }

    public void Dibujar()
    {
        GL.Begin(PrimitiveType.LineLoop);
        GL.Color4(Color);
        foreach (var vertice in Vertices.Values)
            GL.Vertex3(vertice.X, vertice.Y, vertice.Z);

        GL.End();
    }

    public void Trasladar(float deltaX, float deltaY, float deltaZ)
    {
        Matrix4 traslacion = Matrix4.CreateTranslation(deltaX, deltaY, deltaZ);
        TransformarPuntos(traslacion);
        CalcularCentro();
    }

    public void Escalar(float factor)
    {
        Vector3 centro = new(Centro.X, Centro.Y, Centro.Z);
        Matrix4 transformacion =
            Matrix4.CreateTranslation(-centro) * 
            Matrix4.CreateScale(factor) *
            Matrix4.CreateTranslation(centro);
        TransformarPuntos(transformacion);
    }

    public void Rotar(float angX, float angY, float angZ)
    {
        Vector3 centro = new(Centro.X, Centro.Y, Centro.Z);
        Matrix4 rotacion =
            Matrix4.CreateTranslation(-centro) * 
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angZ)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angY)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angX)) *
            Matrix4.CreateTranslation(centro); 
        TransformarPuntos(rotacion);
    }

    public void CalcularCentro()
    {
        if (Vertices.Count == 0)
            Centro = new Punto(0, 0, 0);
        else
        {
            Centro = new Punto(
                Vertices.Values.Average(v => v.X),
                Vertices.Values.Average(v => v.Y),
                Vertices.Values.Average(v => v.Z)
            );
        }
    }

    public void TransformarPuntos(Matrix4 matrix)
    {
        foreach (var key in Vertices.Keys.ToList())
        {
            Punto v = Vertices[key];
            Vector4 punto = Vector4.Transform(new Vector4(v.X, v.Y, v.Z, 1), matrix);
            Vertices[key] = new Punto(punto.X, punto.Y, punto.Z);
        }
    }
}
