using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment9
{
    class MaxHeap<T> : IEnumerable<T> where T : IComparable
    {
        private T[] UnderlyingArray;
        private int ElementCount = 0;
        private int OldCount = 0;
        private bool IsHeap = true;

        public MaxHeap(int starting_size)
        {
            UnderlyingArray = new T[starting_size];
        }

        public MaxHeap()
        {
            UnderlyingArray = new T[5];
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
            UnderlyingArray = new T[UnderlyingArray.Length];
        }

        public T this[int index]
        {
            get
            {
                return UnderlyingArray[index];
            }
        }

        public void Add(T new_value)
        {
            if (!IsHeap)
                BuildHeap();

            if (ElementCount == UnderlyingArray.Length)
                Resize();

            UnderlyingArray[ElementCount] = new_value;
            Swim();
            ElementCount++;
        }

        public T PopTop()
        {
            if (!IsHeap)
                BuildHeap();

            T max = UnderlyingArray[0];

            Swap(0, ElementCount - 1);
            UnderlyingArray[ElementCount - 1] = default(T);
            ElementCount--;
            Sink();
            
            return max;
        }

        public void Sort()
        {
            if (!IsHeap)
                BuildHeap();

            OldCount = ElementCount;

            for (int i = 0; i < OldCount; i++)
            {
                Swap(0, ElementCount - 1);
                ElementCount--;
                Sink();
            }

            IsHeap = false;
            ElementCount = OldCount;
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

                if (UnderlyingArray[current_index].CompareTo(UnderlyingArray[parent_index]) == 0)
                    break;

                else if (UnderlyingArray[current_index].CompareTo(UnderlyingArray[parent_index]) > 0)
                    Swap(current_index, parent_index);

                current_index = parent_index;
            }
        }

        private void Swap(int first, int second)
        {
            T temp = UnderlyingArray[first];
            UnderlyingArray[first] = UnderlyingArray[second];
            UnderlyingArray[second] = temp;
        }

        private void Sink()
        {
            int current_index = 0;

            while (current_index < ElementCount)
            {
                int max_child_index = current_index;
                int left_child_index = FindLeft(current_index);
                int right_child_index = FindRight(current_index);

                if (left_child_index >= ElementCount)
                    break;

                if (right_child_index >= ElementCount)
                    max_child_index = left_child_index;

                if (right_child_index < ElementCount &&
                    UnderlyingArray[left_child_index].CompareTo(UnderlyingArray[right_child_index]) == 0)
                    max_child_index = left_child_index;

                if (right_child_index < ElementCount && 
                    UnderlyingArray[left_child_index].CompareTo(UnderlyingArray[right_child_index]) > 0)
                    max_child_index = left_child_index;

                if (right_child_index < ElementCount && 
                    UnderlyingArray[left_child_index].CompareTo(UnderlyingArray[right_child_index]) < 0)
                    max_child_index = right_child_index;

                if (UnderlyingArray[max_child_index].CompareTo(UnderlyingArray[current_index]) == 0)
                    break;

                if (UnderlyingArray[max_child_index].CompareTo(UnderlyingArray[current_index]) > 0)
                    Swap(current_index, max_child_index);

                current_index = max_child_index;
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
            T[] new_array = new T[UnderlyingArray.Length * 2];

            for (int index = 0; index < UnderlyingArray.Length; index++)
                new_array[index] = UnderlyingArray[index];

            UnderlyingArray = new_array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < ElementCount; index++)
            {
                T temp = UnderlyingArray[index];
                //Console.WriteLine("Current Value: {0}", temp);
                yield return temp;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}