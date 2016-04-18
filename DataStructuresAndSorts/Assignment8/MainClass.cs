using System;

namespace Assignment8
{
    class MainClass
    {
        static void Main()
        {
            int BoardSize = 15;
            Random RandInt = new Random();

            Entity player = new Entity(RandInt.Next(0, BoardSize), RandInt.Next(0, BoardSize));
            player.AddComponent(new KeyboardMover());
            player.AddComponent(new KeepInBounds(BoardSize));
            //Grid board = new Grid(BoardSize);
            //board.DisplayGrid();

            while (true)
            {
                player.Update();
                //board.DisplayGrid();
            }
        }
    }
}