using System;

namespace Assignment9
{
    class MaxHeap<T> : Heap<T> where T : IComparable
    {
        public MaxHeap()
        {
            UnderlyingArray = new T[5];
        }
        
        public MaxHeap(int starting_size)
        {
            UnderlyingArray = new T[starting_size];
        }

        public override void Add(T new_value)
        {
            if (!IsHeap)
                BuildHeap();

            if (ElementCount == UnderlyingArray.Length)
                Resize();

            UnderlyingArray[ElementCount] = new_value;
            Swim();
            ElementCount++;
        }

        public T PopMax()
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

        public override void Sort()
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

        private void Sink()
        {
            int current_index = 0;

            while (current_index < ElementCount)
            {
                int max_child = current_index;
                int left_child = FindLeft(current_index);
                int right_child = FindRight(current_index);

                if (left_child >= ElementCount)
                    break;

                if (right_child >= ElementCount)
                    max_child = left_child;

                if (right_child < ElementCount &&
                    UnderlyingArray[left_child].CompareTo(UnderlyingArray[right_child]) == 0)
                    max_child = left_child;

                if (right_child < ElementCount &&
                    UnderlyingArray[left_child].CompareTo(UnderlyingArray[right_child]) > 0)
                    max_child = left_child;

                if (right_child < ElementCount &&
                    UnderlyingArray[left_child].CompareTo(UnderlyingArray[right_child]) < 0)
                    max_child = right_child;

                if (UnderlyingArray[max_child].CompareTo(UnderlyingArray[current_index]) == 0)
                    break;

                if (UnderlyingArray[max_child].CompareTo(UnderlyingArray[current_index]) > 0)
                    Swap(current_index, max_child);

                current_index = max_child;
            }
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
    }
}