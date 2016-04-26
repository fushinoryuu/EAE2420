using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment9
{
    class MaxHeap : IEnumerable
    {
        private int[] UnderlyingArray;
        private int ElementCount = 0;
        private int OldCount = 0;
        private bool IsHeap = true;

        public MaxHeap(int starting_size)
        {
            UnderlyingArray = new int[starting_size];
        }

        public MaxHeap()
        {
            UnderlyingArray = new int[5];
        }

        public int Count
        {
            get
            {
                return ElementCount;
            }
        }

        public void Clear()
        {
            UnderlyingArray = new int[UnderlyingArray.Length];
        }

        public int this[int index]
        {
            get
            {
                return UnderlyingArray[index];
            }
        }

        public void Add(int new_value)
        {
            if (!IsHeap)
                BuildHeap();

            if (ElementCount == UnderlyingArray.Length)
                Resize();

            UnderlyingArray[ElementCount] = new_value;
            Swim();
            ElementCount++;
        }

        public int PopTop()
        {
            int max = UnderlyingArray[0];

            Swap(0, ElementCount - 1);
            UnderlyingArray[ElementCount - 1] = 0;
            Sink();
            ElementCount--;

            return max;
        }

        public void Sort()
        {
            OldCount = ElementCount;

            for (int index = 0; index < OldCount; index++)
            {
                Swap(index, ElementCount - 1);
                Sink();
                ElementCount--;
            }

            IsHeap = false;
        }

        public void BuildHeap()
        {
            if (IsHeap)
                return;

            int last_item = OldCount - 1;

            for (int index = 0; index < OldCount / 2; index++)
            {
                Swap(index, last_item);
                last_item--;
            }

            ElementCount = OldCount;
            IsHeap = true;
        }

        private void Swim()
        {
            int current_index = ElementCount;

            while (current_index != 0)
            {
                int parent_index = FindParent(current_index);

                if (UnderlyingArray[current_index] > UnderlyingArray[parent_index])
                    Swap(current_index, parent_index);

                current_index = parent_index;
            }
        }

        private void Swap(int first, int second)
        {
            int temp = UnderlyingArray[first];
            UnderlyingArray[first] = UnderlyingArray[second];
            UnderlyingArray[second] = temp;
        }

        //Finish
        private void Sink()
        {
            int current_index = 0;

            while (current_index < ElementCount)
            {
                if (current_index > ElementCount)
                    break;


            }
        }

        private int FindParent(int current_index)
        {
            return (current_index - 1) / 2;
        }

        private int FindLeft(int current_index)
        {
            return (current_index * 2) + 1;
        }

        private int FindRight(int current_index)
        {
            return (current_index * 2) + 2;
        }

        private void Resize()
        {
            int[] new_array = new int[UnderlyingArray.Length * 2];

            for (int index = 0; index < UnderlyingArray.Length; index++)
                new_array[index] = UnderlyingArray[index];

            UnderlyingArray = new_array;
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < ElementCount; index++)
                yield return UnderlyingArray[index];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}