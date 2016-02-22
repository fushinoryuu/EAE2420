using System;
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

        /// <summary>
        /// Asserts that each item on the list is property sorted.
        /// </summary>
        /// <param name="numbers">Array to test.</param>
        private static void SortAsserter(int[] numbers)
        {
            for(int index = 0; index < numbers.Length; index++)
            {
                if (index < numbers.Length - 1)
                    Debug.Assert(numbers[index] <= numbers[index + 1], "List is not sorted in correct order.");
            }
        }

        /// <summary>
        /// Calls all the other Test functions for my customer list. 
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestList(MyList<int> myList)
        {
            Console.Write("Initial list: [{0}]", string.Join(", ", myList));
            TestCount(myList, 0);

            TestIsReadOnly(myList);
            TestInterface(myList);

            Console.WriteLine("Adding 1, 3, 5, 7, & 9 to the list...\n");
            TestAdd(myList);
            TestCount(myList, 5);

            Console.WriteLine("Inserting 2 into index 3 and 8 into index 5...\n");
            TestInsert(myList);
            TestCount(myList, 7);

            TestIndexOf(myList, 7);

            Console.WriteLine("Removing 5 from the list...\n");
            TestRemove(myList);
            TestCount(myList, 6);

            Console.WriteLine("Removing 3 at index 1...\n");
            TestRemoveAt(myList);
            TestCount(myList, 5);

            Console.WriteLine("Clearing the list...\n");
            TestClear(myList);
            TestCount(myList, 0);
        }

        /// <summary>
        /// Tests that a number can be added to the list.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestAdd(MyList<int> myList)
        {
            int[] testlist = new[] { 1, 3, 5, 7, 9 };
            for (int i = 0; i < testlist.Length; i++)
            {
                myList.Add(testlist[i]);
                Debug.Assert(myList.Contains(testlist[i]) == true, "List doesn't contain this number.");
            }
            Console.Write("New list: [{0}]", string.Join(", ", myList));
            
        }

        /// <summary>
        /// Tests that a number can be inserted into the list.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestInsert(MyList<int> myList)
        {
            myList.Insert(3, 2);
            myList.Insert(5, 8);
            Debug.Assert(myList.Contains(2) == true);
            Debug.Assert(myList.Contains(5) == true);
            Console.Write("New list: [{0}]", string.Join(", ", myList));
        }

        /// <summary>
        /// Tests that the list can be cleared and reset to default value.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestClear(MyList<int> myList)
        {
            myList.Clear();
            Debug.Assert(myList.Count == 0);
            Console.Write("New list: [{0}]", string.Join(", ", myList));
        }

        /// <summary>
        /// Tests that a number can be removed from the list.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestRemove(MyList<int> myList)
        {
            myList.Remove(5);
            Debug.Assert(myList.Contains(5) == false);
            Console.Write("New list: [{0}]", string.Join(", ", myList));
        }

        /// <summary>
        /// Test that a number can be removed at a specific index.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestRemoveAt(MyList<int> myList)
        {
            myList.RemoveAt(1);
            Debug.Assert(myList.Contains(3) == false);
            Console.Write("New list: [{0}]", string.Join(", ", myList));
        }

        /// <summary>
        /// Tests how many items are in the list.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        /// <param name="count">How many items are suppose to be in the list.</param>
        private static void TestCount(MyList<int> myList, int count)
        {
            Debug.Assert(myList.Count == count, "The total count doesn't match.");
            Console.WriteLine(" Items in list: {0}\n", myList.Count);
        }

        /// <summary>
        /// Tests for the index of a paticular number.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        /// <param name="value">Number to look for on the list.</param>
        private static void TestIndexOf(MyList<int> myList, int value)
        {
            Debug.Assert(myList.Contains(value));
            Console.WriteLine("The index of 7 is: {0}\n",myList.IndexOf(value));
        }

        /// <summary>
        /// Test to make sure the list implements the customer interface for the assignment.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestInterface(MyList<int> myList)
        {
            Debug.Assert(myList is MyList<int> == true, "The object doesn't implement the interface.");
            Console.WriteLine("Does the list implement MyList interface? {0}\n", myList is MyList<int> == true);
        }

        /// <summary>
        /// Tests if the list is read only.
        /// </summary>
        /// <param name="myList">Array to test.</param>
        private static void TestIsReadOnly(MyList<int> myList)
        {
            Debug.Assert(myList.IsReadOnly == false);
            Console.WriteLine("Is the list ready only? {0}\n", myList.IsReadOnly);
        }
    }
}