
using CrearU3D.Estructura;

namespace CrearU3D;

public interface InterfaceFigura
{
    Punto Centro { get; set; }

    public void Dibujar();

    public void Rotar(float angX, float angY, float angZ);

    public void Trasladar(float deltaX, float deltaY, float deltaZ);

    public void Escalar(float factor);
}
