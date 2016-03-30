using System;

namespace Assignment6
{
    class Caller
    {
        public static void Main()
        {
            Console.WriteLine("Pick your starting node:");
            string startingNode = Console.ReadLine();
            startingNode = startingNode.ToUpper();

            Console.WriteLine("Pick the end node:");
            string endingNode = Console.ReadLine();
            endingNode = endingNode.ToUpper();

            AStar pathfinder = new AStar(startingNode, endingNode);
        }
    }
}