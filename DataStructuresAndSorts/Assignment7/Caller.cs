﻿using System;
using System.Collections.Generic;

namespace Assignment7
{
    class Caller
    {
        public static void Main()
        {
            //NumberTable();
            HeroTable();
        }

        public static void NumberTable()
        {
            MyHashTable<int, int> number_table = new MyHashTable<int, int>();

            //int[] array = new int[20];
            //RandomNumber(array);

            //foreach (int number in array)
            //    number_table.Add(new KeyValuePair<int, int>(number, number));

            number_table[55] = 1;
            number_table[55] = 1;
            number_table[55] = 2;
            number_table[55] = 3;
            number_table[55] = 4;
            number_table[55] = 4;

            Console.WriteLine("Values in the Hashtable: [{0}]\n", string.Join(", ", number_table));
        }

        public static void HeroTable()
        {
            MyHashTable<Hero, string> hero_table = new MyHashTable<Hero, string>();

            List<Hero> adc_list = new List<Hero>();
            adc_list.Add(new Hero { Name = "Ashe", Attack = 57 });
            adc_list.Add(new Hero { Name = "Jinx", Attack = 58 });
            adc_list.Add(new Hero { Name = "Varus", Attack = 55 });
            adc_list.Add(new Hero { Name = "Vayne", Attack = 56 });
            adc_list.Add(new Hero { Name = "Kalista", Attack = 63 });
            adc_list.Add(new Hero { Name = "Jhin", Attack = 53 });
            adc_list.Add(new Hero { Name = "Caitlyn", Attack = 54 });
            adc_list.Add(new Hero { Name = "Draven", Attack = 56 });
            adc_list.Add(new Hero { Name = "Graves", Attack = 61 });
            adc_list.Add(new Hero { Name = "Lucian", Attack = 57 });

            List<Hero> bruiser_list = new List<Hero>();
            bruiser_list.Add(new Hero { Name = "Garen", Attack = 58 });
            bruiser_list.Add(new Hero { Name = "Fiora", Attack = 60 });
            bruiser_list.Add(new Hero { Name = "Darius", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Vi", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Jinx", Attack = 58 }); // duplicate
            bruiser_list.Add(new Hero { Name = "Shyvana", Attack = 61 });
            bruiser_list.Add(new Hero { Name = "Caitlyn", Attack = 50 }); // duplicate name, not attack
            bruiser_list.Add(new Hero { Name = "Pantheon", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Riven", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Illaoi", Attack = 60 });

            foreach (Hero adc in adc_list)
            {
                hero_table.Add(new KeyValuePair<Hero, string>(adc, adc.Name));
            }

            foreach (Hero bruiser in bruiser_list)
            {
                hero_table.Add(new KeyValuePair<Hero, string>(bruiser, bruiser.Name));
            }
        }

        private static void RandomNumber(int[] array)
        {
            Random rand_int = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = rand_int.Next(1, 100);
        }
    }
}