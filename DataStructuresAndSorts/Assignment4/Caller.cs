﻿using System;
using System.Diagnostics;

namespace Assignment4
{
    class Caller
    {
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

            MyList<int> myList = new MyList<int>(1);
            TestList(myList);
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
        private static void TestList(MyList<int> myList)
        {
            Console.WriteLine("Initial list: [{0}]\n", string.Join(", ", myList.underlyingArray));
            Console.WriteLine("Adding 1, 3, 5, 7, & 9 to the list...\n");
            TestAdd(myList);

            Console.WriteLine("Inserting 2 into index 4 and 5 into index 5...\n");
            TestInsert(myList);

            Console.WriteLine("Removing the first 5 from the list...\n");
            TestRemove(myList);

            Console.WriteLine("Removing 3 at index 1...\n");
            TestRemoveAt(myList);
            
            //TestContains();
            
            //TestClear();
        }

        private static void TestAdd(MyList<int> myList)
        {
            int[] testlist = new[] { 1, 3, 5, 7, 9 };
            for (int i = 0; i < testlist.Length; i++)
            {
                myList.Add(testlist[i]);
                Debug.Assert(myList.Contains(testlist[i]) == true, "List doesn't contain this number.");
            }
            Console.WriteLine("New list: [{0}]\n", string.Join(", ", myList.underlyingArray));
        }

        private static void TestInsert(MyList<int> myList)
        {
            myList.Insert(4, 2);
            myList.Insert(5, 5);
            Debug.Assert(myList.Contains(2) == true);
            Debug.Assert(myList.Contains(5) == true);
            Console.WriteLine("New list: [{0}]\n", string.Join(", ", myList.underlyingArray));
        }

        // TODO Implement TestClear
        private static void TestClear(MyList<int> myList)
        {
            throw new NotImplementedException();
        }

        private static void TestRemove(MyList<int> myList)
        {
            myList.Remove(5);
            Debug.Assert(myList.Contains(5) == true);
            Console.WriteLine("New list: [{0}]\n", string.Join(", ", myList.underlyingArray));
        }

        private static void TestRemoveAt(MyList<int> myList)
        {
            myList.RemoveAt(1);
            Debug.Assert(myList.Contains(3) == false);
            Console.WriteLine("New list: [{0}]\n", string.Join(", ", myList.underlyingArray));
        }

        // TODO Implement TestContains
        private static void TestContains(MyList<int> myList)
        {
            throw new NotImplementedException();
        }

        // TODO Implement TestCount
        private static void TestCount(MyList<int> myList)
        {
            throw new NotImplementedException();
        }
    }
}