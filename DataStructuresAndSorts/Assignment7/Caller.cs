using System;
using System.Collections.Generic;

namespace Assignment7
{
    class Caller
    {
        public static void Main()
        {
            NumberTable();
            //HeroTable();
        }

        public static void NumberTable()
        {
            MyHashTable<int, int> number_table = new MyHashTable<int, int>();

            //int[] array = new int[20];
            //RandomNumber(array);

            //foreach (int number in array)
            //    number_table.Add(number.GetHashCode(), number);

            number_table[55] = 1;
            number_table[55] = 5;
            Console.WriteLine(number_table[55]);

        }

        private static void RandomNumber(int[] array)
        {
            Random rand_int = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = rand_int.Next(1, 100);
        }

        public static void HeroTable()
        {
            MyHashTable<Hero, string> hero_table = new MyHashTable<Hero, string>();

            List<Hero> adc_list = new List<Hero>(10);
            adc_list[0] = new Hero { Name = "Ashe", Attack = 57 };
            adc_list[1] = new Hero { Name = "Jinx", Attack = 58 };
            adc_list[2] = new Hero { Name = "Varus", Attack = 55 };
            adc_list[3] = new Hero { Name = "Vayne", Attack = 56 };
            adc_list[4] = new Hero { Name = "Kalista", Attack = 63 };
            adc_list[5] = new Hero { Name = "Jhin", Attack = 53 };
            adc_list[6] = new Hero { Name = "Caitlyn", Attack = 54 };
            adc_list[7] = new Hero { Name = "Draven", Attack = 56 };
            adc_list[8] = new Hero { Name = "Graves", Attack = 61 };
            adc_list[9] = new Hero { Name = "Lucian", Attack = 57 };

            List<Hero> bruiser_list = new List<Hero>(10);
            bruiser_list[0] = new Hero { Name = "Garen", Attack = 58 };
            bruiser_list[1] = new Hero { Name = "Fiora", Attack = 60 };
            bruiser_list[2] = new Hero { Name = "Darius", Attack = 56 };
            bruiser_list[3] = new Hero { Name = "Vi", Attack = 56 };
            bruiser_list[4] = new Hero { Name = "Jinx", Attack = 58 }; // duplicate
            bruiser_list[5] = new Hero { Name = "Shyvana", Attack = 61 };
            bruiser_list[6] = new Hero { Name = "Caitlyn", Attack = 50 }; // duplicate, attack
            bruiser_list[7] = new Hero { Name = "Pantheon", Attack = 56 };
            bruiser_list[8] = new Hero { Name = "Riven", Attack = 56 };
            bruiser_list[9] = new Hero { Name = "Illaoi", Attack = 60 };

            foreach (Hero adc in adc_list)
            {
                hero_table.Add(adc, adc.Name);
            }
        }
    }
}