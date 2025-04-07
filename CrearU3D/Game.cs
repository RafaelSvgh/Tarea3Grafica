using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using OpenTK.Input;
using OpenTK.Graphics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        Vertice[] verticesCubo = {
            new Vertice(-0.5f,0.5f,0.0f),
            new Vertice(0.5f,0.5f,0.0f),
            new Vertice(0.5f,-0.5f,0.0f),
            new Vertice(-0.5f,-0.5f,0.0f),
            new Vertice(-0.5f,0.5f,-0.5f),
            new Vertice(0.5f,0.5f,-0.5f),
            new Vertice(0.5f,-0.5f,-0.5f),
            new Vertice(-0.5f,-0.5f,-0.5f),
        };

        Vertice[] verticesU = {
            new Vertice(-0.5f,0.6f,0.0f),
            new Vertice(-0.3f,0.6f,0.0f),
            new Vertice(-0.3f,-0.3f,0.0f),
            new Vertice(-0.5f,-0.3f,0.0f),
            

            new Vertice(-0.5f,0.6f,-0.2f),
            new Vertice(-0.3f,0.6f,-0.2f),
            new Vertice(-0.3f,-0.3f,-0.2f),
            new Vertice(-0.5f,-0.3f,-0.2f),
            

            new Vertice(0.3f,0.6f,0.0f),
            new Vertice(0.5f,0.6f,0.0f),
            new Vertice(0.5f,-0.3f,0.0f),
            new Vertice(0.3f,-0.3f,0.0f),

            new Vertice(0.3f,0.6f,-0.2f),
            new Vertice(0.5f,0.6f,-0.2f),
            new Vertice(0.5f,-0.3f,-0.2f),
            new Vertice(0.3f,-0.3f,-0.2f),
            
            new Vertice(-0.3f,-0.1f,0.0f),
            new Vertice(-0.3f,-0.1f,-0.2f),
            new Vertice(0.3f,-0.1f,0.0f),
            new Vertice(0.3f,-0.1f,-0.2f),

        };


        Cara[] carasCubo = {
            new Cara(new List<Vertice>{ verticesCubo[0], verticesCubo[1], verticesCubo[2], verticesCubo[3]}, Color4.Teal),
            new Cara(new List<Vertice>{ verticesCubo[0], verticesCubo[4], verticesCubo[7], verticesCubo[3]}, Color4.Red),
            new Cara(new List<Vertice>{ verticesCubo[0], verticesCubo[4], verticesCubo[5], verticesCubo[1]}, Color4.Green),
            new Cara(new List<Vertice>{ verticesCubo[3], verticesCubo[7], verticesCubo[6], verticesCubo[2]}, Color4.GreenYellow),
            new Cara(new List<Vertice>{ verticesCubo[1], verticesCubo[5], verticesCubo[6], verticesCubo[2]}, Color4.Purple),
            new Cara(new List<Vertice>{ verticesCubo[4], verticesCubo[5], verticesCubo[6], verticesCubo[7]}, Color4.Orange),
        };

        Cara[] carasU = {
            new Cara(new List<Vertice>{verticesU[0], verticesU[1], verticesU[2], verticesU[3]}, Color4.Salmon),
            new Cara(new List<Vertice>{verticesU[4], verticesU[5], verticesU[6], verticesU[7]}, Color4.SandyBrown),
            new Cara(new List<Vertice>{verticesU[0], verticesU[4], verticesU[7], verticesU[3]}, Color4.SkyBlue),
            new Cara(new List<Vertice>{verticesU[1], verticesU[5], verticesU[6], verticesU[2]}, Color4.SteelBlue),
            new Cara(new List<Vertice>{verticesU[0], verticesU[4], verticesU[5], verticesU[1]}, Color4.PapayaWhip),
            new Cara(new List<Vertice>{verticesU[3], verticesU[7], verticesU[6], verticesU[2]}, Color4.MediumSeaGreen),
            
            
            new Cara(new List<Vertice>{verticesU[8], verticesU[9], verticesU[10], verticesU[11]}, Color4.LightPink),
            new Cara(new List<Vertice>{verticesU[12], verticesU[13], verticesU[14], verticesU[15]}, Color4.LightGray),
            new Cara(new List<Vertice>{verticesU[8], verticesU[12], verticesU[15], verticesU[11]}, Color4.LightCoral),
            new Cara(new List<Vertice>{verticesU[9], verticesU[13], verticesU[14], verticesU[10]}, Color4.LemonChiffon),
            new Cara(new List<Vertice>{verticesU[8], verticesU[12], verticesU[13], verticesU[9]}, Color4.LavenderBlush),
            new Cara(new List<Vertice>{verticesU[11], verticesU[15], verticesU[14], verticesU[10]}, Color4.LightBlue),
            
            
            new Cara(new List<Vertice>{verticesU[2], verticesU[6], verticesU[15], verticesU[11]}, Color4.Khaki),
            new Cara(new List<Vertice>{verticesU[2], verticesU[16], verticesU[18], verticesU[11]}, Color4.Indigo),
            new Cara(new List<Vertice>{verticesU[6], verticesU[17], verticesU[19], verticesU[15]}, Color4.Honeydew),
            new Cara(new List<Vertice>{verticesU[16], verticesU[17], verticesU[19], verticesU[18]}, Color4.Gainsboro),
        };

        Objeto u = new Objeto(new List<Parte> { new Parte(new List<Cara>(carasU)) }, new Vertice(0, 0, 0));
        Objeto u2 = new Objeto(new List<Parte> { new Parte(new List<Cara>(carasU)) }, new Vertice(-2, 0, 0));
        Objeto u3 = new Objeto(new List<Parte> { new Parte(new List<Cara>(carasU)) }, new Vertice(-2, -2, 0));
        Objeto cubo = new Objeto(new List<Parte> { new Parte(new List<Cara>(carasCubo))}, new Vertice(3, -2,1));


        escenario.AgregarObjeto(u);
        escenario.AgregarObjeto(u2);
        escenario.AgregarObjeto(u3);
        escenario.AgregarObjeto(cubo);
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
        if (keyboard[Key.Q]) this.escenario.objetos[0].Rotacion += new Vector3(1, 0, 0);
        if (keyboard[Key.E]) this.escenario.objetos[0].Rotacion += new Vector3(0, 1, 0);
        if (keyboard[Key.R]) this.escenario.objetos[0].Rotacion += new Vector3(0, 0, 1);
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