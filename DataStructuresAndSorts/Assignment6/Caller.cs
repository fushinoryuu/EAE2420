using System;

namespace Assignment6
{
    class Caller
    {
        //public static void Main()
        //{
        //    Console.WriteLine("Pick your starting node:");
        //    string inputStart = Console.ReadLine();
        //    inputStart = inputStart.ToUpper();

        //    Console.WriteLine("Pick the end node:");
        //    string inputEnd = Console.ReadLine();
        //    inputEnd = inputEnd.ToUpper();

        //    AStar pathfinder = new AStar(inputStart, inputEnd);
        //}

        public static void Main()
        {
            Console.WriteLine("Pick your starting node:");
            string inputStart = Console.ReadLine();
            inputStart = inputStart.ToUpper();
            Console.WriteLine();

            Console.WriteLine("Pick the end node:");
            string inputEnd = Console.ReadLine();
            inputEnd = inputEnd.ToUpper();
            Console.WriteLine();

            NewAStar pathfinder = new NewAStar(inputStart, inputEnd);
        }
    }
}