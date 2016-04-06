using System;

namespace Assignment6
{
    class Caller
    {
        public static void Main()
        {
            Console.WriteLine("Pick the starting node:");
            string inputStart = Console.ReadLine();
            inputStart = inputStart.ToUpper();
            Console.WriteLine();

            Console.WriteLine("Pick the end node:");
            string inputEnd = Console.ReadLine();
            inputEnd = inputEnd.ToUpper();
            Console.WriteLine();

            AStar pathfinder = new AStar(inputStart, inputEnd);
            string solution = pathfinder.ReconstructPath();

            Console.WriteLine("The Path is: {0}\n", solution);

            Console.WriteLine("Do you want to find another path? y/n\n");
            string again = Console.ReadLine();
            again = again.ToUpper();
            Console.WriteLine();

            if (again == "Y")
                Main();
            else
                Environment.Exit(1);
        }
    }
}