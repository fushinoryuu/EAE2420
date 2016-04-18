using System;

namespace Assignment8
{
    class MainClass
    {
        static void Main()
        {
            Entity player = new Entity();
            player.AddComponent(new KeyboardMover());

            while (true)
            {
                Console.WriteLine(player.Position);
                player.Update();
                Console.ReadLine();
            }
        }
    }
}