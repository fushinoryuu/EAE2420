using System;

namespace Assignment9
{
    class MaxHeap
    {
        private int[] UnderlyingArray;
        private int ElementCount = 0;

        public MaxHeap(int starting_size)
        {
            UnderlyingArray = new int[starting_size];
        }

        public MaxHeap()
        {
            UnderlyingArray = new int[1];
        }

        public int Count
        {
            get
            {
                return ElementCount;
            }
        }

        public void Add(int new_value)
        {
            if (ElementCount == UnderlyingArray.Length)
                Resize();

            UnderlyingArray[ElementCount] = new_value;
            Swim();
            ElementCount++;
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

        public int PopTop()
        {
            int max = UnderlyingArray[0];

            Swap(0, ElementCount);
            DeleteLast();
            Sink();
            
            return max;
        }

        private void Swap(int first, int second)
        {
            int temp = UnderlyingArray[first];
            UnderlyingArray[first] = UnderlyingArray[second];
            UnderlyingArray[second] = temp;
        }

        private void DeleteLast()
        {
            UnderlyingArray[ElementCount] = 0;
            ElementCount--;
        }

        //Finish
        private void Sink()
        {
            int index = 0;
            while (index < ElementCount)
            {


                index++;
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
    }
}