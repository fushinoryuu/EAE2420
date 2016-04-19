﻿using System;
using System.Collections.Generic;

namespace Assignment8
{
    class Grid
    {
        private string[,] Board;
        private int Size;
        private List<Entity> EntityList;

        public Grid(int size, List<Entity> entity_list)
        {
            Size = size;
            Board = new string[size, size];
            EntityList = entity_list;
        }

        public void Update()
        {
            ClearGrid();
            SetGrid();
            DisplayGrid();
        }

        private void ClearGrid()
        {
            Board = new string[Size, Size];
        }

        private void SetGrid()
        {
            foreach (Entity entity in EntityList)
                Board[entity.Position.X, entity.Position.Y] = entity.Name;
        }

        private void DisplayGrid()
        {
            Console.WriteLine("Current Map:\n");

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