using System;

namespace Assignment4
{
    class MergeSort : ISorter
    {
        public void sort(int[] numbers, int low, int high)
        {
            if (low < high)
            {
                int middle = (high + low) / 2;
                sort(numbers, low, middle);
                sort(numbers, middle + 1, high);

                merge(numbers, low, middle + 1, high);
            }
        }

        private void merge(int[] numbers, int low, int middle, int high)
        {
            int[] temp = new int[numbers.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (middle - 1);
            tmp_pos = low;
            num_elements = (high - low + 1);

            while ((low <= left_end) && (middle <= high))
            {
                if (numbers[low] <= numbers[middle])
                    temp[tmp_pos++] = numbers[low++];
                else
                    temp[tmp_pos++] = numbers[middle++];
            }

            while (low <= left_end)
                temp[tmp_pos++] = numbers[low++];

            while (middle <= high)
                temp[tmp_pos++] = numbers[middle++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[high] = temp[high];
                high--;
            }
        }
    }
}