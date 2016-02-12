using System;

namespace Assignment4
{
    class Caller
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] quick_list = new[] { 9, 7, 2, 6, 0, 1 };
            Console.WriteLine("List before quick sort: [{0}]", string.Join(", ", quick_list));
            QuickSort.sort(quick_list, 0, quick_list.Length);
            Console.WriteLine("List after quick sort: [{0}]", string.Join(", ", quick_list));
        }
    }
}