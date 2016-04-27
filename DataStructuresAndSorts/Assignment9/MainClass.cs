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
            string invariant_error = "The invariants have been broken.";
            MaxHeap myHeap = new MaxHeap();

            int[] numberList = new int[] { 0, 5, 9, 2, 8, 1, 4, 7, 3, 6 };

            Console.WriteLine("Adding the following numbers to the heap: [{0}]\n", string.Join(", ", numberList));

            foreach (int number in numberList)
                myHeap.Add(number);

            Console.WriteLine("New heap: [{0}]\n", string.Join(", ", myHeap));

            Console.WriteLine("Performing Heap Sort...\n");

            myHeap.Sort();
            TestSort(myHeap, sort_error);

            Console.WriteLine("New heap: [{0}]\n", string.Join(", ", myHeap));

            Console.WriteLine("Rebuilding Heap...\n");

            myHeap.BuildHeap();

            Console.WriteLine("New heap: [{0}]\n", string.Join(", ", myHeap));

            Console.WriteLine("Poping the top value until heap is empty...\n");

            TestPop(myHeap, pop_error);

            Console.WriteLine("New heap: [{0}]\n", string.Join(", ", myHeap));

            int elements = 50000;
            myHeap = new MaxHeap(elements);
            int[] random_list = RandomIntArray(elements);

            Console.WriteLine("Adding {0} values to a new heap...\n", elements);

            foreach (int number in random_list)
            {
                myHeap.Add(number);
                TestInvariant(myHeap, invariant_error);
            }

            Console.WriteLine("Heap too big to print on console, current elements in heap: {0}\n", myHeap.Count);

            //for (int i = 0; i < elements / 2; i++)
            //{
            //    myHeap.PopTop();
            //    TestInvariant(myHeap, invariant_error);
            //}
        }

        // 1. Parent is grater than both of its children
        // 2. Complete array ???
        private static void TestInvariant(MaxHeap heap, string error)
        {
            //throw new NotImplementedException();
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

        private static int[] RandomIntArray(int elements)
        {
            Random randint = new Random();

            int[] list = new int[elements];

            for (int index = 0; index < elements; index++)
                list[index] = randint.Next(1, elements);

            return list;
        }
    }
}