﻿using System;

namespace Assignment8
{
    class KeyboardMover : Component
    {
        public override void Update()
        {
            Console.WriteLine("Which way to move? (WASD)");

            char choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case 'w':
                    Container.Position.Y++;
                    break;
                case 'a':
                    Container.Position.X--;
                    break;
                case 's':
                    Container.Position.Y--;
                    break;
                case 'd':
                    Container.Position.X++;
                    break;
                case 'q':
                    Environment.Exit(1);
                    break;
            }
        }
    }
}