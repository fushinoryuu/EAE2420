using System;

namespace Assignment8
{
    class MainClass
    {
        static void Main()
        {
            Entity player = new Entity();

            while (true)
            {
                Console.WriteLine(player.Position);
                Console.ReadLine();
            }
        }
    }
}