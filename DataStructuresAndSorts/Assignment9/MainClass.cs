using System;
using System.Collections.Generic;

namespace Assignment9
{
    class MainClass
    {
        public static void Main()
        {
            MaxHeap myHeap = new MaxHeap();

            int[] numberList = new int[] { 0, 5, 9, 2, 8, 1, 4, 7, 3, 6 };

            foreach (int number in numberList)
                myHeap.Add(number);
        }
    }
}