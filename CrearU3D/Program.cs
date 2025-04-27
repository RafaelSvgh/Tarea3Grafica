using System;

using CrearU3D;

class Program
{
    static void Main(string[] args)
    {
        using (Game game = new())
        {
            game.Run(120.0);
        }
    }
}