using System;

using CrearU3D;

class Program
{
    static void Main(string[] args)
    {
        using (Game game = new Game())
        {
            game.Run(120.0); // Opcional: Ejecuta el juego a 60 FPS
        }
    }
}