using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment7
{
    class MainClass
    {
        public static void Main()
        {
            NumberTable();
            HeroTable();
        }

        public static void NumberTable()
        {
            MyHashTable<int, int> number_table = new MyHashTable<int, int>();

            int[] first_list = new int[] { 5, 8, 19, 39, 13, 99, 40, 38, 84, 66, 75, 1, 45, 92 };

            int[] second_list = new int[] { 6, 9, 20, 43, 14, 100, 41, 37, 85, 67, 76, 2, 46, 3 };

            foreach (int number in first_list)
                number_table.Add(new KeyValuePair<int, int>(number, number));

            foreach (int number in second_list)
                number_table.Add(number, number);

            number_table[55] = 4;

            Console.WriteLine("Values in the Interger Hashtable: {0}\n", string.Join(", ", number_table));

            Console.WriteLine("Keys in the Integer Hashtable: {0}\n", string.Join(", ", number_table.Keys));

            Console.WriteLine("Values in the Integer Hashtable: {0}\n", string.Join(", ", number_table.Values));

            Console.WriteLine("Does the Hashtable contain the Key 101: {0}\n", number_table.ContainsKey(101));

            TestCount(29, number_table.Count, "Element count doesn't match!");
            Console.WriteLine("Elements in the Hashtable: {0}\n", number_table.Count);
        }

        public static void HeroTable()
        {
            MyHashTable<string, int> hero_table = new MyHashTable<string, int>();

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
            bruiser_list.Add(new Hero { Name = "Wukong", Attack = 60 });
            bruiser_list.Add(new Hero { Name = "Shyvana", Attack = 61 });
            bruiser_list.Add(new Hero { Name = "Olaf", Attack = 60 });
            bruiser_list.Add(new Hero { Name = "Pantheon", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Riven", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Illaoi", Attack = 60 });

            foreach (Hero adc in adc_list)
            {
                hero_table.Add(new KeyValuePair<string, int>(adc.Name, adc.Attack));
            }

            foreach (Hero bruiser in bruiser_list)
            {
                hero_table.Add(bruiser.Name, bruiser.Attack);
            }

            hero_table["Irelia"] = 62;

            Console.WriteLine("Values in the Hero Hashtable: {0}\n", string.Join(", ", hero_table));

            Console.WriteLine("Keys in the Hero Hashtable: {0}\n", string.Join(", ", hero_table.Keys));

            Console.WriteLine("Values in the Hero Hashtable: {0}\n", string.Join(", ", hero_table.Values));

            Console.WriteLine("Does the Hashtable contain the Key 'Ahri': {0}\n", hero_table.ContainsKey("Ahri"));

            TestCount(21, hero_table.Count, "Element count doesn't match!");
            Console.WriteLine("Elements in the Hashtable: {0}\n", hero_table.Count);
        }

        private static void TestCount(int expect, int actual, string error)
        {
            Debug.Assert(expect == actual, error);
        }
    }
}