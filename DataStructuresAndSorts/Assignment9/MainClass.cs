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
            string pop_error = "The current value is not grater than the next value on the array";
            MaxHeap myHeap = new MaxHeap();

            int[] numberList = new int[] { 0, 5, 9, 2, 8, 1, 4, 7, 3, 6 };

            foreach (int number in numberList)
                myHeap.Add(number);

            Console.WriteLine("Values in heap: [{0}]", string.Join(", ", myHeap));

            myHeap.Sort();
            TestSort(myHeap, sort_error);

            myHeap.BuildHeap();
            TestPop(myHeap, pop_error);
        }

        private static void TestInvariant(MaxHeap heap, string error)
        {

        }

        private static void TestPop(MaxHeap heap, string error)
        {
            int temp1 = heap.PopTop();
            int count = heap.Count;

            for (int i = 0; i < count; i++)
            {
                int temp2 = heap.PopTop();
                Debug.Assert(temp1 >= temp2, error);
                temp1 = temp2;
            }
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