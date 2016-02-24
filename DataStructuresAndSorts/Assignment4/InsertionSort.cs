namespace Assignment4
{
    class InsertionSort : ISorter
    {
        public void sort(int[] numbers, int low, int high)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        swap_numbers(numbers, j - 1, j);
                    }
                    j--;
                }
            }
        }

        private static void swap_numbers(int[] numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }
    }
}