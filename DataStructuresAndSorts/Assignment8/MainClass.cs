using System;
using System.Collections.Generic;

namespace Assignment8
{
    class MainClass
    {
        public static void Main()
        {
            int BoardSize = 10;
            int Turns = 0;
            Random RandInt = new Random();
            List<Entity> EntityList = new List<Entity>();
            List<PowerUp> PowerUpList = new List<PowerUp>();

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

            Grid Board = new Grid(BoardSize, EntityList, PowerUpList);
            Board.Update();

            while (true)
            {
                foreach (Entity entity in EntityList)
                    entity.Update();
                AddMonster(EntityList, RandInt, Player, BoardSize);
                //if (Turns % 3 == 0)
                //    AddTeleporter(PowerUpList, Player, BoardSize);
                //else if (Turns % 7 == 0)
                //    AddLife();
                Board.Update();
                Turns++;
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

        private static void AddTeleporter(List<PowerUp> list, Entity player, int board_size)
        {
            PowerUp new_power = new Teleport(player, board_size);
            new_power.Name = "T";
            list.Add(new_power);
        }

        private static void AddLife()
        {

        }
    }
}