using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Graphics;
using CrearU3D.Serializacion;
using CrearU3D.Estructura;
using CrearU3D.Controles;
using CrearU3D.Utilidades;

namespace CrearU3D;

public class Game : GameWindow
{
    private Camara camara = null!;
    private Escenario escenario1, escenario2;
    private ControladorTeclado controladorTeclado = null!;
    private PlanoCartesiano PlanoCartesiano { get; set; } = new PlanoCartesiano(0.5, 0.10);
    private InterfaceFigura figura = null!;  
    private MouseState _lastMouseState;

    public Game() : base(1000, 1000, GraphicsMode.Default, "Examen Programación Gráfica")
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
        escenario1 = serializador.Cargar<Escenario>("escenario1") ?? throw new InvalidOperationException("No se pudo cargar el escenario desde el archivo JSON.");
        figura = escenario1;
        controladorTeclado = new ControladorTeclado(escenario1, escenario2, figura);
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
        controladorTeclado.ProcesarTeclado(Keyboard.GetState());
    }

}
