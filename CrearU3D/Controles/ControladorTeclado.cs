using OpenTK.Input;
using CrearU3D.Estructura;
using OpenTK.Graphics.OpenGL;

namespace CrearU3D.Controles;

public class ControladorTeclado
{
    private InterfaceFigura figura;
    private Escenario escenario1, escenario2;
    private bool modoRotacion, modoEscalacion, modoTraslacion;

    public ControladorTeclado(Escenario escenario1, Escenario escenario2, InterfaceFigura figura)
    {
        this.escenario1 = escenario1;
        this.escenario2 = escenario2;
        this.figura = figura;
    }

    public void ProcesarTeclado(KeyboardState keyboard)
    {
        if (keyboard.IsKeyDown(Key.R))
        {
            modoRotacion = true;
            modoEscalacion = false;
            modoTraslacion = false;
            System.Threading.Thread.Sleep(200);
        }
        if (keyboard.IsKeyDown(Key.E))
        {
            modoEscalacion = true;
            modoRotacion = false;
            modoTraslacion = false;
            System.Threading.Thread.Sleep(200);
        }
        if (keyboard.IsKeyDown(Key.T))
        {
            modoEscalacion = false;
            modoRotacion = false;
            modoTraslacion = true;
            System.Threading.Thread.Sleep(200);
        }

        if (keyboard[Key.Number0])
            figura = escenario1;
        if (keyboard[Key.Number1])
            figura = escenario1.ObtenerObjeto("u1")!;
        if (keyboard[Key.Number2])
            figura = escenario1.ObtenerObjeto("h1")!;
        if (keyboard[Key.Number3])
            figura = escenario1.ObtenerObjeto("u1")!.ObtenerParte("Izquierdo")!;
        if (keyboard[Key.Number4])
            figura = escenario1.ObtenerObjeto("u1")!.ObtenerParte("Derecho")!;
        if (keyboard[Key.Number5])
            figura = escenario1.ObtenerObjeto("u1")!.ObtenerParte("Base")!;
        if (keyboard[Key.Number6])
            figura = escenario1.ObtenerObjeto("h1")!.ObtenerParte("Izquierdo")!;
        if (keyboard[Key.Number7])
            figura = escenario1.ObtenerObjeto("h1")!.ObtenerParte("Derecho")!;
        if (keyboard[Key.Number8])
            figura = escenario1.ObtenerObjeto("h1")!.ObtenerParte("Medio")!;
        if (keyboard[Key.Number9])
            figura = escenario1.ObtenerObjeto("h1")!.ObtenerParte("Medio")!.ObtenerCara("frontal")!;

        if (modoRotacion)
        {
            if (keyboard[Key.Down]) figura.Rotar(1, 0, 0);
            if (keyboard[Key.Up]) figura.Rotar(-1, 0, 0);
            if (keyboard[Key.Right]) figura.Rotar(0, 1, 0);
            if (keyboard[Key.Left]) figura.Rotar(0, -1, 0);
            if (keyboard[Key.X]) figura.Rotar(0, 0, 1);
            if (keyboard[Key.Z]) figura.Rotar(0, 0, -1);
        }

        if (modoEscalacion)
        {
            if (keyboard[Key.Up]) figura.Escalar(1.01f);
            if (keyboard[Key.Down]) figura.Escalar(0.99f);
        }

        if (modoTraslacion)
        {
            if (keyboard[Key.Up]) figura.Trasladar(0, 0.01f, 0);
            if (keyboard[Key.Down]) figura.Trasladar(0, -0.01f, 0);
            if (keyboard[Key.Left]) figura.Trasladar(-0.01f, 0, 0);
            if (keyboard[Key.Right]) figura.Trasladar(0.01f, 0, 0);
            if (keyboard[Key.Z]) figura.Trasladar(0, 0, -0.01f);
            if (keyboard[Key.X]) figura.Trasladar(0, 0, 0.01f);
        }

    }
}