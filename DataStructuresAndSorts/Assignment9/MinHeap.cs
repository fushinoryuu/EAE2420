using System;

namespace Assignment9
{
    class MinHeap<T> : Heap<T> where T : IComparable
    {
        public MinHeap(int starting_size)
        {
            UnderlyingArray = new T[starting_size];
        }

        public MinHeap()
        {
            UnderlyingArray = new T[5];
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

        public override T PopTop()
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
            throw new NotImplementedException();
        }

        private void Swim()
        {
            int current_index = ElementCount;

            while (current_index != 0)
            {
                int parent_index = FindParent(current_index);

                if (UnderlyingArray[current_index].CompareTo(UnderlyingArray[parent_index]) == 0)
                    break;

                else if (UnderlyingArray[current_index].CompareTo(UnderlyingArray[parent_index]) < 0)
                    Swap(current_index, parent_index);

                current_index = parent_index;
            }
        }
    }
}
