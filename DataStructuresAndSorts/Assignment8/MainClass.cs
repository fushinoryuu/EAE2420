using System;

namespace Assignment8
{
    class MainClass
    {
        static void Main()
        {
            Entity player = new Entity();
            player.AddComponent(new KeyboardMover());
            player.AddComponent(new KeepInBounds(5));
            //Grid board = new Grid(15);
            //board.DisplayGrid();

            while (true)
            {
                player.Update();
                //board.DisplayGrid();
            }
        }
    }
}