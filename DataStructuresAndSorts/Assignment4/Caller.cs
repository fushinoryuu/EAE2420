using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment4
{
    class Caller
    {
        MyList<int> myList = new MyList<int>(1);

        public static void Main()
        {
            Console.WriteLine("Hello World!\n");

            int[] qList = new[] { 9, 7, 2, 6, 1 };
            Console.WriteLine("List before quick sort: [{0}]", string.Join(", ", qList));
            QuickSort qSorter = new QuickSort();
            qSorter.sort(qList, 0, qList.Length);
            SortAsserter(qList);
            Console.WriteLine("List after quick sort: [{0}]\n", string.Join(", ", qList));

            int[] sList = new[] { 2, 6, 3, 1, 9 };
            Console.WriteLine("List before selection sort: [{0}]", string.Join(", ", sList));
            SelectionSort sSorter = new SelectionSort();
            sSorter.sort(sList, 0, 0);
            SortAsserter(sList);
            Console.WriteLine("List after selection sort: [{0}]\n", string.Join(", ", sList));

            int[] iList = new[] { 2, 8, 5, 7, 3 };
            Console.WriteLine("List before insertion sort: [{0}]", string.Join(", ", iList));
            InsertionSort iSorter = new InsertionSort();
            iSorter.sort(iList, 0, 0);
            SortAsserter(iList);
            Console.WriteLine("List after insertion sort: [{0}]\n", string.Join(", ", iList));

            int[] bList = new[] { 1, 7, 3, 2, 0 };
            Console.WriteLine("List before bubble sort: [{0}]", string.Join(", ", bList));
            BubbleSort bSorter = new BubbleSort();
            bSorter.sort(bList, 0, 0);
            SortAsserter(bList);
            Console.WriteLine("List after bubble sort: [{0}]\n", string.Join(", ", bList));

            int[] mList = new[] { 6, 8, 3, 0, 1 };
            Console.WriteLine("List before merge sort: [{0}]", string.Join(", ", mList));
            MergeSort mSorter = new MergeSort();
            mSorter.sort(mList, 0, mList.Length - 1);
            SortAsserter(mList);
            Console.WriteLine("List after merge sort: [{0}]\n", string.Join(", ", mList));

            //for (int index = 0; index < qList.Length; index++)
            //    myList.Add(qList[index]);

            //myList.Clear();

            //Console.WriteLine("My IList: [{0}]", string.Join(", ", myList.underlyingArray));
            //Console.WriteLine(myList.Count);

            //myList.Insert(0, 9);
            //myList.Add(8);
            //myList.RemoveAt(1);
            //myList.Remove(2);

            //Console.WriteLine("My IList: [{0}]", string.Join(", ", myList.underlyingArray));
            //Console.WriteLine(myList.Count);
        }

        private static void SortAsserter(int[] numbers)
        {
            for(int index = 0; index < numbers.Length; index++)
            {
                if (index < numbers.Length - 1)
                    Debug.Assert(numbers[index] <= numbers[index + 1], "List is not sorted in correct order.");
            }
        }

        private static void ListAsserter()
        {
            throw new NotImplementedException();
        }

        // TODO Implement TestList
        private static void TestList()
        {
            TestAdd();
            TestInsert();
            TestRemove();
            TestContains();
            TestClear();
        }

        // TODO Implement TestAdd
        private static void TestAdd()
        {
            throw new NotImplementedException();
        }

        // TODO Implement TestInsert
        private static void TestInsert()
        {
            throw new NotImplementedException();
        }

        // TODO Implement TestClear
        private static void TestClear()
        {
            throw new NotImplementedException();
        }

        // TODO Implement TestRemove
        private static void TestRemove()
        {
            throw new NotImplementedException();
        }

        // TODO Implement TestContains
        private static void TestContains()
        {
            throw new NotImplementedException();
        }

        // TODO Implement TestCount
        private static void TestCount()
        {
            throw new NotImplementedException();
        }
    }
}