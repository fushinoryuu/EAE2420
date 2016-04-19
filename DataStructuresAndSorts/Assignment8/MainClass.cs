using System;
using System.Collections.Generic;

namespace Assignment8
{
    class MainClass
    {
        static void Main()
        {
            int BoardSize = 15;
            Random RandInt = new Random();
            List<Entity> EntityList = new List<Entity>();

            Entity Player = new Entity(RandInt.Next(0, BoardSize), RandInt.Next(0, BoardSize));
            Player.Name = "P";
            Player.AddComponent(new KeyboardMover());
            Player.AddComponent(new KeepInBounds(BoardSize));
            EntityList.Add(Player);

            Grid Board = new Grid(BoardSize, EntityList);
            Board.Update();

            while (true)
            {
                Player.Update();
                Board.Update();
            }
        }
    }
}