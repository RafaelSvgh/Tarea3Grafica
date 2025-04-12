using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using OpenTK.Input;
using OpenTK.Graphics;

namespace CrearU3D;

public class Game : GameWindow
{
    private Matrix4 projectionMatrix;
    private Matrix4 viewMatrix;
    private Escenario escenario;
    private float _cameraDistance = 5.0f;
    private float _cameraAngleX = 30.0f; // Ángulo vertical
    private float _cameraAngleY = 45.0f; // Ángulo horizontal

    public Game() : base(800, 800, GraphicsMode.Default, "Al fin pude, pero falta:)))")
    {
        this.escenario = new Escenario(Color4.Black);
    }


    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.Enable(EnableCap.DepthTest);
        GL.ClearColor(escenario.ColorDeFondo);
        float aspectRatio = (float)Width / Height;
        projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
            MathHelper.PiOver4, // 45 grados
            aspectRatio,
            0.1f,               // Plano cercano
            100.0f);            // Plano lejano

        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Ortho(-1.0, 1.0, -1.0, 1.0, -1.0, 1.0);

        // Configuración de vista   
        viewMatrix = Matrix4.LookAt(
            new Vector3(3, 2, 3),  // Cámara en (0,0,3)
            Vector3.Zero,          // Mirando al origen
            Vector3.UnitY);        // Vector arriba

        LetraU u1 = new LetraU(new Vertice(1,0,0), Color4.Blue);
        LetraU u2 = new LetraU(new Vertice(-1,0,0), Color4.Blue);
        escenario.AgregarObjeto(u1);
        escenario.AgregarObjeto(u2);
        Console.WriteLine(u1.Partes[0].CentroDeMasa().X);
        Console.WriteLine(u1.Partes[0].CentroDeMasa().Y);
        Console.WriteLine(u1.Partes[0].CentroDeMasa().Z);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projectionMatrix);

        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref viewMatrix);

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
        KeyboardState keyboard = Keyboard.GetState();
        if (keyboard[Key.Up]) _cameraAngleX += 1.0f;
        if (keyboard[Key.Down]) _cameraAngleX -= 1.0f;
        if (keyboard[Key.Left]) _cameraAngleY -= 1.0f;
        if (keyboard[Key.Right]) _cameraAngleY += 1.0f;
        if (keyboard[Key.W]) _cameraDistance -= 0.1f;
        if (keyboard[Key.S]) _cameraDistance += 0.1f;
        float camX = (float)(_cameraDistance * Math.Sin(MathHelper.DegreesToRadians(_cameraAngleY)) *
                             Math.Cos(MathHelper.DegreesToRadians(_cameraAngleX)));
        float camY = (float)(_cameraDistance * Math.Sin(MathHelper.DegreesToRadians(_cameraAngleX)));
        float camZ = (float)(_cameraDistance * Math.Cos(MathHelper.DegreesToRadians(_cameraAngleY)) *
                             Math.Cos(MathHelper.DegreesToRadians(_cameraAngleX)));

        viewMatrix = Matrix4.LookAt(
            new Vector3(camX, camY, camZ), 
            Vector3.Zero,                  
            Vector3.UnitY);
    }

}