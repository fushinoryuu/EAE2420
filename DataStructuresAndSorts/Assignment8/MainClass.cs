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
            Console.WriteLine("Use the WASD keys to move your character (X) around the grid.\n");
            Console.WriteLine("Make sure that you don't collide with Monsters or you will die and the game ends.\n");
            Console.WriteLine("Monsters come in two types, Slow monsters (S) and Fast monsters (F) and can move \nrandomly in any direction.\n");
            Console.WriteLine("Slow monsters move 1 space at a time, while Fast monsters move 2 spaces at a time.\n");
            Console.WriteLine("More monsters get added every turn!\n");
            Console.WriteLine("Only monsters can wrap around the grid, the player can not.\n");
            Console.WriteLine("Collect Power Ups to stay alive longer by walking over them:\n");
            Console.WriteLine("- T will Teleport you randomly to any place in the grid.\n");
            Console.WriteLine("- I will make you Invulnerable until your next collision.\n");
            Console.WriteLine("Press P to quit at any time!\n");
            Console.WriteLine("-----------------------------------------------\n");
        }

        private static void RunGame()
        {
            int BoardSize = 10;
            int Turns = 0;
            List<Entity> EntityList = new List<Entity>();
            List<PowerUp> PowerUpList = new List<PowerUp>();

            Entity Player = new Entity(new Random().Next(0, BoardSize), new Random().Next(0, BoardSize));
            Player.Name = "X";
            Player.AddComponent(new KeepInBounds(BoardSize));
            Player.AddComponent(new KeyboardMover());
            EntityList.Add(Player);

            AddMonster(EntityList, Player, BoardSize);

            Grid Board = new Grid(BoardSize, EntityList, PowerUpList);
            Board.Update();

            while (true)
            {
                if (Turns != 0 && Turns % 5 == 0)
                    AddTeleporter(PowerUpList, Player, BoardSize);
                if (Turns != 0 && Turns % 5 == 0)
                    AddInvulnerable(PowerUpList, Player, BoardSize);

                foreach (Entity entity in EntityList)
                    entity.Update();

                foreach (PowerUp powerup in PowerUpList)
                    powerup.Update();

                AddMonster(EntityList, Player, BoardSize);

                Board.Update();
                Turns++;
            }
        }

        private static void AddMonster(List<Entity> list, Entity player, int board_size)
        {
            if (RandomBool())
                SlowMonster(list, player, board_size);
            else
                FastMonster(list, player, board_size);
        }

        private static bool RandomBool()
        {
            return new Random().Next() % 2 == 0;
        }

        private static void SlowMonster(List<Entity> list, Entity player, int board_size)
        {
            Entity new_monster = new Entity(new Random().Next(0, board_size), new Random().Next(0, board_size));
            new_monster.Name = "S";
            new_monster.AddComponent(new WrapAround(board_size));
            new_monster.AddComponent(new KillOnContact(player));
            new_monster.AddComponent(new AiMovementSlow());
            list.Add(new_monster);
        }

        private static void FastMonster(List<Entity> list, Entity player, int board_size)
        {
            Entity new_monster = new Entity(new Random().Next(0, board_size), new Random().Next(0, board_size));
            new_monster.Name = "F";
            new_monster.AddComponent(new WrapAround(board_size));
            new_monster.AddComponent(new KillOnContact(player));
            new_monster.AddComponent(new AiMovementFast());
            list.Add(new_monster);
        }

        private static void AddTeleporter(List<PowerUp> list, Entity player, int board_size)
        {
            Teleport new_teleport = new Teleport(player, board_size, list);

            list.Add(new_teleport);
        }

        private static void AddInvulnerable(List<PowerUp> list, Entity player, int boardSize)
        {
            Invulnerability new_invulnerable = new Invulnerability(player, boardSize, list);

            list.Add(new_invulnerable);
        }
    }
}