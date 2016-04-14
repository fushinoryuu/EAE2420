using System;
using System.Collections.Generic;

namespace Assignment7
{
    class MainClass
    {
        public static void Main()
        {
            NumberTable();
            //HeroTable();

            test();
        }

        public static void test()
        {
            Dictionary<int, int> table = new Dictionary<int, int>(5);

            int[] array = new int[] { 5, 8, 19, 39, 13, 99, 40, 38, 84, 66, 75, 1, 45, 0 };

            foreach (int number in array)
                table.Add(number, number);

            table[55] = 1;
            table[55] = 1;
            table[55] = 2;
            table[55] = 3;
            table[55] = 4;
            table[55] = 4;

            Console.WriteLine("\nValues in the TEST Hashtable: {0}\n", string.Join(", ", table));
            Console.WriteLine("\nElements in the TEST Hashtable: {0}\n", table.Count);
        }

        public static void NumberTable()
        {
            MyHashTable<int, int> number_table = new MyHashTable<int, int>();

            int[] array = new int[] { 5, 8, 19, 39, 13, 99, 40, 38, 84, 66, 75, 1, 45, 0 };

            foreach (int number in array)
                number_table.Add(new KeyValuePair<int, int>(number, number));

            number_table[55] = 1;
            number_table[55] = 1;
            number_table[55] = 2;
            number_table[55] = 3;
            number_table[55] = 4;
            number_table[55] = 4;

            Console.WriteLine("Values in the Hashtable: {0}\n", string.Join(", ", number_table));
            Console.WriteLine("\nElements in the Hashtable: {0}\n", number_table.Count);
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
            bruiser_list.Add(new Hero { Name = "Jinx", Attack = 58 }); // duplicate
            bruiser_list.Add(new Hero { Name = "Shyvana", Attack = 61 });
            bruiser_list.Add(new Hero { Name = "Caitlyn", Attack = 50 }); // duplicate name, not attack
            bruiser_list.Add(new Hero { Name = "Pantheon", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Riven", Attack = 56 });
            bruiser_list.Add(new Hero { Name = "Illaoi", Attack = 60 });

            foreach (Hero adc in adc_list)
            {
                hero_table.Add(new KeyValuePair<string, int>(adc.Name, adc.Attack));
            }

            foreach (Hero bruiser in bruiser_list)
            {
                hero_table.Add(new KeyValuePair<string, int>(bruiser.Name, bruiser.Attack));
            }

            Console.WriteLine("Values in the Hashtable: {0}\n", string.Join(", ", hero_table));
        }
    }
}