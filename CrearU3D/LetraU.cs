

using OpenTK.Graphics;

namespace CrearU3D;

public class LetraU : Objeto
{
    
    public LetraU(Vertice posicion, Color4 color) : base([], posicion)
    {
        List<Vertice> posteIzquierdo = [
            new Vertice(-0.5f, 0.6f, 0.0f),   // Arriba-frontal
            new Vertice(-0.3f, 0.6f, 0.0f),   // Arriba-trasero
            new Vertice(-0.3f, -0.3f, 0.0f),  // Abajo-trasero
            new Vertice(-0.5f, -0.3f, 0.0f),  // Abajo-frontal
            new Vertice(-0.5f, 0.6f, -0.2f),  // Arriba-frontal (profundidad)
            new Vertice(-0.3f, 0.6f, -0.2f),  // Arriba-trasero (profundidad)
            new Vertice(-0.3f, -0.3f, -0.2f), // Abajo-trasero (profundidad)
            new Vertice(-0.5f, -0.3f, -0.2f)  // Abajo-frontal (profundidad)
        ];

        this.Partes.Add(Utils.CrearBloque3D(posteIzquierdo, color));

        List<Vertice> posteDerecho = [
            new Vertice(0.3f, 0.6f, 0.0f),    // Arriba-frontal
            new Vertice(0.5f, 0.6f, 0.0f),    // Arriba-trasero
            new Vertice(0.5f, -0.3f, 0.0f),   // Abajo-trasero
            new Vertice(0.3f, -0.3f, 0.0f),   // Abajo-frontal
            new Vertice(0.3f, 0.6f, -0.2f),  // Arriba-frontal (profundidad)
            new Vertice(0.5f, 0.6f, -0.2f),   // Arriba-trasero (profundidad)
            new Vertice(0.5f, -0.3f, -0.2f),  // Abajo-trasero (profundidad)
            new Vertice(0.3f, -0.3f, -0.2f)   // Abajo-frontal (profundidad)
        ];

        this.Partes.Add(Utils.CrearBloque3D(posteDerecho, color));

        List<Vertice> travesaño = [
            new Vertice(-0.3f, -0.1f, 0.0f),  // Izquierda-frontal
            new Vertice(0.3f, -0.1f, 0.0f),   // Derecha-frontal
            new Vertice(0.3f, -0.3f, 0.0f),   // Derecha-abajo-frontal
            new Vertice(-0.3f, -0.3f, 0.0f),  // Izquierda-abajo-frontal
            new Vertice(-0.3f, -0.1f, -0.2f), // Izquierda-trasero
            new Vertice(0.3f, -0.1f, -0.2f),  // Derecha-trasero
            new Vertice(0.3f, -0.3f, -0.2f),  // Derecha-abajo-trasero
            new Vertice(-0.3f, -0.3f, -0.2f)  // Izquierda-abajo-trasero
        ];

        this.Partes.Add(Utils.CrearBloque3D(travesaño, color));
    }
}
