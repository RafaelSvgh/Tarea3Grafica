using CrearU3D.Estructura;
using CrearU3D.Utilidades;
using OpenTK.Graphics;

namespace CrearU3D.Formas;

public class U3D : Objeto
{

    public U3D(Punto posicion, Color4 color) : base([], posicion)
    {
        List<Punto> Izquierda = [
            new Punto(-0.5f, 0.6f, 0.0f),   // Arriba-frontal
            new Punto(-0.3f, 0.6f, 0.0f),   // Arriba-trasero
            new Punto(-0.3f, -0.3f, 0.0f),  // Abajo-trasero
            new Punto(-0.5f, -0.3f, 0.0f),  // Abajo-frontal
            new Punto(-0.5f, 0.6f, -0.2f),  // Arriba-frontal (profundidad)
            new Punto(-0.3f, 0.6f, -0.2f),  // Arriba-trasero (profundidad)
            new Punto(-0.3f, -0.3f, -0.2f), // Abajo-trasero (profundidad)
            new Punto(-0.5f, -0.3f, -0.2f)  // Abajo-frontal (profundidad)
        ];

        AgregarParte("Izquierdo", Utils.CrearBloque3D(Izquierda, color));

        List<Punto> Derecho = [
            new Punto(0.3f, 0.6f, 0.0f),    // Arriba-frontal
            new Punto(0.5f, 0.6f, 0.0f),    // Arriba-trasero
            new Punto(0.5f, -0.3f, 0.0f),   // Abajo-trasero
            new Punto(0.3f, -0.3f, 0.0f),   // Abajo-frontal
            new Punto(0.3f, 0.6f, -0.2f),  // Arriba-frontal (profundidad)
            new Punto(0.5f, 0.6f, -0.2f),   // Arriba-trasero (profundidad)
            new Punto(0.5f, -0.3f, -0.2f),  // Abajo-trasero (profundidad)
            new Punto(0.3f, -0.3f, -0.2f)   // Abajo-frontal (profundidad)
        ];

        AgregarParte("Derecho", Utils.CrearBloque3D(Derecho, color));

        List<Punto> baseU = [
            new Punto(-0.3f, -0.1f, 0.0f),  // Izquierda-frontal
            new Punto(0.3f, -0.1f, 0.0f),   // Derecha-frontal
            new Punto(0.3f, -0.3f, 0.0f),   // Derecha-abajo-frontal
            new Punto(-0.3f, -0.3f, 0.0f),  // Izquierda-abajo-frontal
            new Punto(-0.3f, -0.1f, -0.2f), // Izquierda-trasero
            new Punto(0.3f, -0.1f, -0.2f),  // Derecha-trasero
            new Punto(0.3f, -0.3f, -0.2f),  // Derecha-abajo-trasero
            new Punto(-0.3f, -0.3f, -0.2f)  // Izquierda-abajo-trasero
        ];

        AgregarParte("Base", Utils.CrearBloque3D(baseU, color));
        Trasladar(posicion.X, posicion.Y, posicion.Z);
    }
}
