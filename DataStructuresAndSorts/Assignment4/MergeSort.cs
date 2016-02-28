using System;

namespace Assignment4
{
    class MergeSort : ISorter
    {
        public void sort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                sort(numbers, left, middle);

                sort(numbers, middle + 1, right);

                merge(numbers, left, middle, right);
            }
        }

        private static void merge(int[] numbers, int left, int middle, int right)
        {
            int lengthLeft = middle - left + 1;
            int lengthRight = right - middle;

            int[] leftArray = new int[lengthLeft + 1];
            int[] rightArray = new int[lengthRight + 1];

            for (int i = 0; i < lengthLeft; i++)
                leftArray[i] = numbers[left + i - 1];

            for (int j = 0; j < lengthRight; j++)
                rightArray[j] = numbers[middle + j];

            leftArray[lengthLeft] = Int32.MaxValue;
            rightArray[lengthRight] = Int32.MaxValue;

            int iIndex = 0;
            int jIndex = 0;

            for (int k = left; k < right; k++)
            {
                if (leftArray[iIndex] <= rightArray[jIndex])
                {
                    numbers[k] = leftArray[iIndex];
                    iIndex++;
                }
                else
                {
                    numbers[k] = rightArray[jIndex];
                    jIndex++;
                }
            }
        }
    }
}