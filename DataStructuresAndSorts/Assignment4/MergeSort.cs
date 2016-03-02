using System;

namespace Assignment4
{
    class MergeSort : ISorter
    {
        public void sort(int[] numbers, int left, int right)
        {
            int mid;

            if (left < right)
            {
                mid = (right + left) / 2;
                sort(numbers, left, mid);
                sort(numbers, (mid + 1), right);

                merge(numbers, left, (mid + 1), right);
            }
        }

        private static void merge(int[] numbers, int left, int middle, int right)
        {
            int[] temp = new int[numbers.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (middle - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (middle <= right))
            {
                if (numbers[left] <= numbers[middle])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[middle++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (middle <= right)
                temp[tmp_pos++] = numbers[middle++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
    }
}