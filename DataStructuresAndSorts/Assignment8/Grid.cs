using System;

namespace Assignment8
{
    class Grid
    {
        private string[,] Board;
        private int Size;

        public Grid(int size)
        {
            Size = size;
            Board = new string[size, size];
        }

        public void DisplayGrid()
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