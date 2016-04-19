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
            Player.AddComponent(new KeepInBounds(BoardSize));
            Player.AddComponent(new KeyboardMover());

            Entity Monster = new Entity(RandInt.Next(0, BoardSize), RandInt.Next(0, BoardSize));
            Monster.Name = "M";
            Monster.AddComponent(new KeepInBounds(BoardSize));
            Monster.AddComponent(new KillPlayer(Player));

            EntityList.Add(Player);
            EntityList.Add(Monster);

            Grid Board = new Grid(BoardSize, EntityList);
            Board.Update();

            while (true)
            {
                foreach (Entity entity in EntityList)
                    entity.Update();
                Board.Update();
            }
        }
    }
}