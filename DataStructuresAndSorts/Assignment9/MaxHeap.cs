using System;

namespace Assignment9
{
    class MaxHeap<T> where T: IComparable<T>
    {
        private T[] UnderlyingArray;
        private int ElementCount = 1;

        public MaxHeap(int starting_size)
        {
            UnderlyingArray = new T[starting_size];
            UnderlyingArray[0] = default(T);
        }

        public MaxHeap()
        {
            UnderlyingArray = new T[10];
            UnderlyingArray[0] = default(T);
        }

        public int Count
        {
            get
            {
                return ElementCount - 1;
            }
        }

        //Finish
        public void Add(int value)
        {

        }

        public T PopTop()
        {
            T max = UnderlyingArray[1];

            SwapFirstLast();
            DeleteLast();
            ReHeapafy();
            
            return max;
        }

        private void SwapFirstLast()
        {
            T temp = UnderlyingArray[1];
            UnderlyingArray[1] = UnderlyingArray[ElementCount];
            UnderlyingArray[ElementCount] = temp;
        }

        private void Swap(int first, int second)
        {
            T temp = UnderlyingArray[first];
            UnderlyingArray[first] = UnderlyingArray[second];
            UnderlyingArray[second] = temp;
        }

        private void DeleteLast()
        {
            UnderlyingArray[ElementCount] = default(T);
            ElementCount--;
        }

        //Finish
        private void ReHeapafy()
        {
            int index = 1;
            while (index < ElementCount)
            {


                index++;
            }
        }

        private int FindParet(int current_index)
        {
            return current_index / 2;
        }

        private int FindLeft(int current_index)
        {
            return current_index * 2;
        }

        private int FindRight(int current_index)
        {
            return (current_index * 2) + 1;
        }
    }
}