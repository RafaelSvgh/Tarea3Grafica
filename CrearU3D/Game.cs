using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Graphics;
using CrearU3D.Serializacion;
using CrearU3D.Estructura;
using CrearU3D.Controles;
using CrearU3D.Formas;

namespace CrearU3D;

public class Game : GameWindow
{
    private Camara camara = null!;
    private Escenario escenario1, escenario2;
    private bool modoRotacion, modoEscalacion, modoTraslacion = false;
    private PlanoCartesiano PlanoCartesiano { get; set; } = new PlanoCartesiano(0.5, 0.10);
    private InterfaceFigura figura = null!;  
    private MouseState _lastMouseState;

    public Game() : base(800, 800, GraphicsMode.Default, "Al fin pude, pero falta:)))")
    {
        this.escenario1 = new Escenario(Color4.Black);
        this.escenario2 = new Escenario(Color4.LightGray);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        camara = new Camara(Width, Height);
        Serializador serializador = new Serializador();
        GL.Enable(EnableCap.DepthTest);
        GL.ClearColor(escenario1.ColorDeFondo);
        //H3D h1 = new H3D(new Punto(1, 0, 0), Color4.Blue);
        //U3D u1 = new U3D(new Punto(-1, 0, 0), Color4.Brown);
        //H3D h2 = new H3D(new Punto(0, 1, 0), Color4.Blue);
        U3D u2 = new U3D(new Punto(-1, 0, 1), Color4.Red);
        //escenario1.AgregarObjeto("h1", h1);
        //escenario1.AgregarObjeto("u1", u1);
        //escenario2.AgregarObjeto("h1", h2);
        //escenario2.AgregarObjeto("u1", u2);
        //serializador.Guardar(escenario1, "escenario1");
        //serializador.Guardar(escenario2, "escenario2");
        escenario1 = serializador.Cargar<Escenario>("escenario1") ?? throw new InvalidOperationException("No se pudo cargar el escenario desde el archivo JSON.");
        escenario2 = serializador.Cargar<Escenario>("escenario2") ?? throw new InvalidOperationException("No se pudo cargar el escenario desde el archivo JSON.");
        figura = escenario1;
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref camara.Proyeccion);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref camara.Vista);
        PlanoCartesiano.Dibujar();
        escenario1.Dibujar();
        SwapBuffers();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Width, Height);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        camara.ProcesarMouse(Mouse.GetState(), _lastMouseState, (float)e.Time);
        camara.ActualizarMatrices(Width, Height);
        _lastMouseState = Mouse.GetState();
        var keyboard = Keyboard.GetState();

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

        if (keyboard[Key.P])
        {
            escenario1 = escenario2;
            GL.ClearColor(escenario1.ColorDeFondo);
        }
            
    }
}
