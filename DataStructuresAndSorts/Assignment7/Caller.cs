using System;
using System.Collections.Generic;

namespace Assignment7
{
    class Caller
    {
        public static void Main()
        {
            MyHashTable<int, int> hashtable = new MyHashTable<int, int>();

            List<Hero> first_list = new List<Hero>(10);
            first_list[0] = new Hero { Name = "Ashe", Attack = 57 };
            first_list[1] = new Hero { Name = "Jinx", Attack = 58 };
            first_list[2] = new Hero { Name = "Varus", Attack = 55 };
            first_list[3] = new Hero { Name = "Vayne", Attack = 56 };
            first_list[4] = new Hero { Name = "Kalista", Attack = 63 };
            first_list[5] = new Hero { Name = "Jhin", Attack = 53 };
            first_list[6] = new Hero { Name = "Caitlyn", Attack = 54 };
            first_list[7] = new Hero { Name = "Draven", Attack = 56 };
            first_list[8] = new Hero { Name = "Graves", Attack = 61 };
            first_list[9] = new Hero { Name = "Lucian", Attack = 57 };

            List<Hero> second_list = new List<Hero>(10);
            second_list[0] = new Hero { Name = "Garen", Attack = 58 };
            second_list[1] = new Hero { Name = "Fiora", Attack = 60 };
            second_list[2] = new Hero { Name = "Darius", Attack = 56 };
            second_list[3] = new Hero { Name = "Vi", Attack = 56 };
            second_list[4] = new Hero { Name = "Trundle", Attack = 60 };
            second_list[5] = new Hero { Name = "Shyvana", Attack = 61 };
            second_list[6] = new Hero { Name = "Nasus", Attack = 59 };
            second_list[7] = new Hero { Name = "Pantheon", Attack = 56 };
            second_list[8] = new Hero { Name = "Riven", Attack = 56 };
            second_list[9] = new Hero { Name = "Illaoi", Attack = 60 };
        }
    }
}