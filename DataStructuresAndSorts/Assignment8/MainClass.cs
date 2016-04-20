using System;
using System.Collections.Generic;

namespace Assignment8
{
    class MainClass
    {
        public static void Main()
        {
            Instructions();
            RunGame();
        }

        private static void Instructions()
        {
            Console.WriteLine("Use the WASD keys to move your character (P) around the grid.\n");
            Console.WriteLine("Make sure that you don't collide with Monsters or you will die and the game ends.\n");
            Console.WriteLine("Monsters come in two types, Slow monsters (S) and Fast monsters (F) and can move \nrandomly in any direction.\n");
            Console.WriteLine("Slow monsters move 1 space at a time, while Fast monsters move 2 spaces at a time.\n");
            Console.WriteLine("Monsters can only wrap around the grid, but the player can not.\n");
            Console.WriteLine("Collect Power Ups to stay alive longer by walking over them:\n");
            Console.WriteLine("- T will Teleport you randomly to any place in the grid.\n");
            Console.WriteLine("- I will make you Invulnerable until your next collision.\n");
        }

        private static void RunGame()
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
            Monster.Name = "S";
            Monster.AddComponent(new KeepInBounds(BoardSize));
            Monster.AddComponent(new KillOnContact(Player));
            Monster.AddComponent(new AiMovementSlow());

            EntityList.Add(Player);
            EntityList.Add(Monster);

            Grid Board = new Grid(BoardSize, EntityList, PowerUpList);
            Board.Update();

            while (true)
            {
                foreach (Entity entity in EntityList)
                    entity.Update();

                foreach (PowerUp powerup in PowerUpList)
                    powerup.Update();

                AddMonster(EntityList, RandInt, Player, BoardSize);

                Board.Update();
                Turns++;
            }
        }

        private static void AddMonster(List<Entity> list, Random randomizer, Entity player, int board_size)
        {
            if (RandomBool())
                SlowMonster(list, randomizer, player, board_size);
            else
                FastMonster(list, randomizer, player, board_size);
        }

        private static bool RandomBool()
        {
            return new Random().Next() % 2 == 0;
        }

        private static void SlowMonster(List<Entity> list, Random randomizer, Entity player, int board_size)
        {
            Entity new_monster = new Entity(randomizer.Next(0, board_size), randomizer.Next(0, board_size));
            new_monster.Name = "S";
            new_monster.AddComponent(new WrapAround(board_size));
            new_monster.AddComponent(new KillOnContact(player));
            new_monster.AddComponent(new AiMovementSlow());
            list.Add(new_monster);
        }

        private static void FastMonster(List<Entity> list, Random randomizer, Entity player, int board_size)
        {
            Entity new_monster = new Entity(randomizer.Next(0, board_size), randomizer.Next(0, board_size));
            new_monster.Name = "F";
            new_monster.AddComponent(new WrapAround(board_size));
            new_monster.AddComponent(new KillOnContact(player));
            new_monster.AddComponent(new AiMovementFast());
            list.Add(new_monster);
        }

        private static void AddTeleporter(List<PowerUp> list, Entity player, int board_size)
        {
            PowerUp new_power = new Teleport(player, board_size);
            list.Add(new_power);
        }

        private static void AddInvulnerable()
        {

        }
    }
}