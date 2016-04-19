using System;
using System.Collections.Generic;

namespace Assignment8
{
    class MainClass
    {
        public static void Main()
        {
            int BoardSize = 10;
            Random RandInt = new Random();
            List<Entity> EntityList = new List<Entity>();

            Entity Player = new Entity(RandInt.Next(0, BoardSize), RandInt.Next(0, BoardSize));
            Player.Name = "P";
            Player.AddComponent(new KeepInBounds(BoardSize));
            Player.AddComponent(new KeyboardMover());

            Entity Monster = new Entity(RandInt.Next(0, BoardSize), RandInt.Next(0, BoardSize));
            Monster.Name = "M";
            Monster.AddComponent(new KeepInBounds(BoardSize));
            Monster.AddComponent(new KillOnContact(Player));
            Monster.AddComponent(new AiMovement());

            EntityList.Add(Player);
            EntityList.Add(Monster);

            Grid Board = new Grid(BoardSize, EntityList);
            Board.Update();

            while (true)
            {
                foreach (Entity entity in EntityList)
                    entity.Update();
                AddMonster(EntityList, RandInt, Player, BoardSize);
                Board.Update();
            }
        }

        private static void AddMonster(List<Entity> list, Random randomizer, Entity player, int board_size)
        {
            Entity new_monster = new Entity(randomizer.Next(0, board_size), randomizer.Next(0, board_size));
            new_monster.Name = "M";
            new_monster.AddComponent(new WrapAround(board_size));
            new_monster.AddComponent(new KillOnContact(player));
            new_monster.AddComponent(new AiMovement());
            list.Add(new_monster);
        }
    }
}