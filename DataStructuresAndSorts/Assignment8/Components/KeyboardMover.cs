using System;

namespace Assignment8
{
    class KeyboardMover : Component
    {
        public override void Update()
        {
            Console.WriteLine("\nWhich way to move? (WASD)\n");

            char choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case 'w':
                    Container.Position.X--;
                    break;
                case 'a':
                    Container.Position.Y--;
                    break;
                case 's':
                    Container.Position.X++;
                    break;
                case 'd':
                    Container.Position.Y++;
                    break;
                case 'p':
                    Console.WriteLine("\n\nThanks for playing!!");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(1);
                    break;
            }
        }
    }
}