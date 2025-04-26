using CrearU3D.Estructura;
using CrearU3D.Utilidades;
using OpenTK.Graphics;

namespace CrearU3D.Formas;

public class H3D : Objeto
{
    public H3D(Punto posicion, Color4 color) : base([], posicion)
    {
        // Parte vertical izquierda
        List<Punto> pataIzquierda = [
            new Punto(-0.5f, 0.5f, 0.0f),   // Superior frontal izquierdo
            new Punto(-0.3f, 0.5f, 0.0f),   // Superior frontal derecho
            new Punto(-0.3f, -0.5f, 0.0f),  // Inferior frontal derecho
            new Punto(-0.5f, -0.5f, 0.0f),  // Inferior frontal izquierdo
            new Punto(-0.5f, 0.5f, -0.2f), // Superior trasero izquierdo
            new Punto(-0.3f, 0.5f, -0.2f),  // Superior trasero derecho
            new Punto(-0.3f, -0.5f, -0.2f), // Inferior trasero derecho
            new Punto(-0.5f, -0.5f, -0.2f) // Inferior trasero izquierdo
        ];
        AgregarParte("Izquierdo", Utils.CrearBloque3D(pataIzquierda, color));

        // Parte vertical derecha
        List<Punto> pataDerecha = [
            new Punto(0.3f, 0.5f, 0.0f),    // Superior frontal izquierdo
            new Punto(0.5f, 0.5f, 0.0f),    // Superior frontal derecho
            new Punto(0.5f, -0.5f, 0.0f),   // Inferior frontal derecho
            new Punto(0.3f, -0.5f, 0.0f),   // Inferior frontal izquierdo
            new Punto(0.3f, 0.5f, -0.2f),   // Superior trasero izquierdo
            new Punto(0.5f, 0.5f, -0.2f),   // Superior trasero derecho
            new Punto(0.5f, -0.5f, -0.2f),  // Inferior trasero derecho
            new Punto(0.3f, -0.5f, -0.2f)   // Inferior trasero izquierdo
        ];
        AgregarParte("Derecho", Utils.CrearBloque3D(pataDerecha, color));

        // Parte horizontal central
        List<Punto> travesaño = [
            new Punto(-0.3f, 0.1f, 0.0f),  // Frontal izquierdo superior
            new Punto(0.3f, 0.1f, 0.0f),    // Frontal derecho superior
            new Punto(0.3f, -0.1f, 0.0f),   // Frontal derecho inferior
            new Punto(-0.3f, -0.1f, 0.0f),  // Frontal izquierdo inferior
            new Punto(-0.3f, 0.1f, -0.2f),  // Trasero izquierdo superior
            new Punto(0.3f, 0.1f, -0.2f),  // Trasero derecho superior
            new Punto(0.3f, -0.1f, -0.2f), // Trasero derecho inferior
            new Punto(-0.3f, -0.1f, -0.2f)  // Trasero izquierdo inferior
        ];
        AgregarParte("Medio", Utils.CrearBloque3D(travesaño, color));

        Trasladar(posicion.X, posicion.Y, posicion.Z);
    }
}