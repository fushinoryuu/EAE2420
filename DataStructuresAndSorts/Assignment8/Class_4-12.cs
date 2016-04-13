using System;

class Caller
{
    public static void Main()
    {
        Grid map = new Grid(10, 10, 8, 1, 4, 4);

        map.printGrid();
        map.flood();
    }
}

class Grid
{
    private Cell[,] grid;
    public int width, height;
    int startx;
    int starty;
    int endx;
    int endy;

    private class Cell
    {
        public int Value { get; set; }
        public bool Updated { get; set; }
    }

    public Grid(int startWidth, int startHeight, int startX, int startY, int endX, int endY)
    {
        grid = new Cell[startWidth, startHeight];

        for (int x = 0; x < startWidth; x++)
        {
            for (int y = 0; y < startHeight; y++)
            {
                grid[x, y] = new Cell() { Value = 0 };
            }
        }

        this.width = startWidth;
        this.height = startHeight;
        this.startx = startX;
        this.starty = startY;
        this.endx = endX;
        this.endy = endY;

        grid[startx, starty].Value = 1;
    }

    public void printGrid()
    {
        Console.WriteLine("Current map:");
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == startx && y == starty)
                    Console.Write("X ");
                else if (x == endx && y == endy)
                    Console.Write("D ");
                else
                    Console.Write("{0} ", grid[x, y].Value);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void flood()
    {
        while (grid[endx, endy].Value == 0)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (grid[x, y].Value > 0 && grid[x, y].Updated == false)
                    {
                        grid[x, y].Value++;
                        grid[x, y].Updated = true;

                        if (x + 1 < width && grid[x + 1, y].Updated == false)
                        {
                            grid[x + 1, y].Value++;
                            grid[x + 1, y].Updated = true;
                        }

                        if (x - 1 >= 0 && grid[x - 1, y].Updated == false)
                        {
                            grid[x - 1, y].Value++;
                            grid[x - 1, y].Updated = true;
                        }

                        if (y + 1 < height && grid[x, y + 1].Updated == false)
                        {
                            grid[x, y + 1].Value++;
                            grid[x, y + 1].Updated = true;
                        }

                        if (y - 1 >= 0 && grid[x, y - 1].Updated == false)
                        {
                            grid[x, y - 1].Value++;
                            grid[x, y - 1].Updated = true;
                        }
                    }
                }
            }
            printGrid();
            cleaFlag();
        }
    }

    private void cleaFlag()
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                grid[x, y].Updated = false;
    }
}