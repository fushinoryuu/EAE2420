using System;
using System.Collections.Generic;

namespace Assignment8
{
    class Grid
    {
        private string[,] Board;
        private int Size;
        private List<Entity> EntityList;
        private List<PowerUp> PowerUpList;
        private int Turns;

        public Grid(int size, List<Entity> entity_list, List<PowerUp> powerup_list)
        {
            Size = size;
            Board = new string[size, size];
            EntityList = entity_list;
            PowerUpList = powerup_list;
            Turns = 0;
        }

        public void Update()
        {
            ClearGrid();
            SetGrid();
            DisplayGrid();
            Turns++;
        }

        private void ClearGrid()
        {
            Board = new string[Size, Size];
        }

        private void SetGrid()
        {
            foreach (Entity entity in EntityList)
                Board[entity.Position.X, entity.Position.Y] = entity.Name;

            foreach (PowerUp powerup in PowerUpList)
                if (powerup.IsVisible)
                    Board[powerup.Position.X, powerup.Position.Y] = powerup.Name;
        }

        private void DisplayGrid()
        {
            Console.WriteLine("\n\nTurns Survived: {0} Current Map:\n", Turns);

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (Board[x, y] == null)
                        Console.Write("[ ] ");
                    else
                        Console.Write("[{0}] ", Board[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}