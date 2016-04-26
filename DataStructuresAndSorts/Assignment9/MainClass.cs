using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment9
{
    class MainClass
    {
        public static void Main()
        {
            string sort_error = "The current value is not less than the next value on the array.";
            MaxHeap myHeap = new MaxHeap();

            int[] numberList = new int[] { 0, 5, 9, 2, 8, 1, 4, 7, 3, 6 };

            foreach (int number in numberList)
                myHeap.Add(number);

            foreach (int number in myHeap)
                Console.WriteLine(number);

            Console.WriteLine("Values in heap: [{0}]", string.Join(", ", myHeap));

            myHeap.Sort();
            TestSort(myHeap, sort_error);

            myHeap.Add(11);
        }

        private static void TestInvariant(MaxHeap heap, string error)
        {

        }

        private static void TestPop(MaxHeap heap, string error)
        {

        }

        private static void TestSort(MaxHeap heap, string error)
        {
            for (int index = 0; index < heap.Count - 1; index++)
            {
                Debug.Assert(heap[index] < heap[index + 1], error);
            }
        }
    }
}