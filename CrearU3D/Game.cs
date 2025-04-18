using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Graphics;
using CrearU3D.Serializacion;

namespace CrearU3D;

public class Game : GameWindow
{
    private Camara camara = null!;
    private Escenario escenario;
    private MouseState _lastMouseState;

    public Game() : base(800, 800, GraphicsMode.Default, "Al fin pude, pero falta:)))")
    {
        this.escenario = new Escenario(Color4.Black);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e); 
        camara = new Camara(Width, Height);
        Serializador serializador = new Serializador();
        GL.Enable(EnableCap.DepthTest);
        GL.ClearColor(escenario.ColorDeFondo);

        LetraU u1 = new LetraU(new Vertice(1, 1, 0), Color4.Blue);
        LetraU u2 = new LetraU(new Vertice(1, 1, 0), Color4.Yellow);
        LetraU u3 = new LetraU(new Vertice(-2, 0, 0), Color4.Red);
        //Objeto u2 = new Objeto(new Vertice(-1, 0, -1), Color4.ForestGreen, "C:\\Users\\msi\\source\\repos\\CrearU3D\\CrearU3D\\Objetos\\u.txt");
        //Objeto t = new Objeto(new Vertice(0, 0, -2), Color4.ForestGreen, "C:\\Users\\msi\\source\\repos\\CrearU3D\\CrearU3D\\Objetos\\ele.txt");
        ////rotacion, traslacion y escalacion, usar id y valor para escenario, objeto, parte y cara
        //escenario.AgregarObjeto("u1", u1);
        //escenario.AgregarObjeto("u2", u2);
        //escenario.AgregarObjeto("u3", u3);
        //u2.Escalar(0.9f);
        //serializador.Guardar(escenario, "escenario1");
        Escenario? escenario1 = serializador.Cargar<Escenario>("escenario1");
        escenario = escenario1 ?? throw new InvalidOperationException("No se pudo cargar el escenario desde el archivo JSON.");
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref camara.Proyeccion);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref camara.Vista);
        escenario.Dibujar();
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
        //camara.ProcesarInput(Keyboard.GetState());
        camara.ProcesarMouse(Mouse.GetState(), _lastMouseState, (float)e.Time);
        camara.ActualizarMatrices(Width, Height);
        _lastMouseState = Mouse.GetState();

        var keyboard = Keyboard.GetState();

        //Rotar todo el escenario con flechas
        if (keyboard.IsKeyDown(Key.Left))
            escenario.Rotar(0, -1, 0);
        if (keyboard.IsKeyDown(Key.Right))
            escenario.Rotar(0, 1, 0);
        if (keyboard.IsKeyDown(Key.Up))
            escenario.Rotar(-1, 0, 0);
        if (keyboard.IsKeyDown(Key.Down))
            escenario.Rotar(1, 0, 0);
        if (keyboard.IsKeyDown(Key.A))
            escenario.Objetos["u1"].Trasladar(0, -0.1f, 0);
        if (keyboard.IsKeyDown(Key.D))
            escenario.Objetos["u1"].Rotar(0, 1, 0);
        if (keyboard.IsKeyDown(Key.Z))
            escenario.Objetos["u1"].Partes["Base"].Rotar(0, 0, 1);
        if (keyboard.IsKeyDown(Key.V))
            escenario.Objetos["u1"].Partes["Base"].Trasladar(0.01f, 0, 0);
        if (keyboard.IsKeyDown(Key.B))
            escenario.Objetos["u2"].Escalar(1.01f);
    }

}