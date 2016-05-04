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

            MaxHeap<int> myHeap = new MaxHeap<int>();

            int[] numberList = new int[] { 2, 5, 9, 2, 8, 1, 4, 7, 3, 6 };

            Console.WriteLine("Adding the following numbers to the heap: [{0}]\n", 
                string.Join(", ", numberList));

            foreach (int number in numberList)
                myHeap.Add(number);

            Console.WriteLine("New Heap: [{0}]\n", string.Join(", ", myHeap));

            Console.WriteLine("Performing Heap Sort...\n");

            myHeap.Sort();
            TestSort(myHeap, sort_error);

            Console.WriteLine("New Heap: [{0}]\n", string.Join(", ", myHeap));

            Console.WriteLine("Rebuilding Heap...\n");

            myHeap.BuildHeap();

            Console.WriteLine("New Heap: [{0}]\n", string.Join(", ", myHeap));

            Console.WriteLine("Poping the top value until heap is empty...\n");

            TestPop(myHeap, pop_error);

            int elements = 20000;
            myHeap = new MaxHeap<int>(elements);
            int[] random_list = RandomIntArray(elements);

            Console.WriteLine("Adding {0} values to a new heap and verifying the invariants...\n", elements);

            Console.WriteLine("This part will take a while...\n");

            foreach (int number in random_list)
            {
                myHeap.Add(number);
                TestInvariant(myHeap, invariant_error);
            }

            Console.WriteLine("Heap too big to print on console, current elements in heap: {0}\n", myHeap.Count);

            Console.WriteLine("Going to pop half of the values out of the heap and verifying the invariants...\n");

            Console.WriteLine("Again... This part will take a while...\n");

            for (int i = 0; i < elements / 2; i++)
            {
                myHeap.PopTop();
                TestInvariant(myHeap, invariant_error);
            }

            Console.WriteLine("Heap too big to print on console, current elements in heap: {0}\n", myHeap.Count);
        }

        private static void TestInvariant(MaxHeap<int> heap, string error)
        {
            if (heap.Count % 500 == 0)
                Console.WriteLine("Cycle {0}\n", heap.Count);

            heap.Sort();

            for (int index = 0; index < heap.Count - 1; index++)
            {
                Debug.Assert(heap[index] <= heap[index + 1], error);
            }

            heap.BuildHeap();
        }

        private static void TestPop(MaxHeap<int> heap, string error)
        {
            int temp1 = heap.PopTop();
            int count = heap.Count;
            Console.WriteLine("New Heap: [{0}]\n", string.Join(", ", heap));

            for (int i = 0; i < count; i++)
            {
                int temp2 = heap.PopTop();
                Debug.Assert(temp1 >= temp2, error);
                temp1 = temp2;

                Console.WriteLine("New Heap: [{0}]\n", string.Join(", ", heap));
            }
        }

        private static void TestSort(MaxHeap<int> heap, string error)
        {
            for (int index = 0; index < heap.Count - 1; index++)
            {
                Debug.Assert(heap[index] <= heap[index + 1], error);
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