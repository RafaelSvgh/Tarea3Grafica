using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Graphics;

namespace CrearU3D;

public class Game : GameWindow
{
    private Camara camara;
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

        GL.Enable(EnableCap.DepthTest);
        GL.ClearColor(escenario.ColorDeFondo);
        
        LetraU u1 = new LetraU(new Vertice(0,0,0), Color4.Blue);
        Objeto u2 = new Objeto(new Vertice(0,0,-1), Color4.ForestGreen, "C:\\Users\\msi\\source\\repos\\CrearU3D\\CrearU3D\\Objetos\\u.txt");
        Objeto t = new Objeto(new Vertice(0,0,-2), Color4.ForestGreen, "C:\\Users\\msi\\source\\repos\\CrearU3D\\CrearU3D\\Objetos\\t.txt");
        //rotacion, traslacion y escalacion, usar id y valor para escenario, objeto, parte y cara
        escenario.AgregarObjeto(u1);
        escenario.AgregarObjeto(u2);
        escenario.AgregarObjeto(t);
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
        var mouse = Mouse.GetState();
        camara.ProcesarInput(Keyboard.GetState());
        camara.ProcesarMouse(mouse, _lastMouseState, (float)e.Time);
        camara.ActualizarMatrices(Width, Height);
        _lastMouseState = mouse;
    }

}