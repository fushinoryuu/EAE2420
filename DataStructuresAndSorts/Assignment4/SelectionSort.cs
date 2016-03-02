namespace Assignment4
{
    class SelectionSort : ISorter
    {
        public void sort(int[] numbers, int low, int high)
        {
            for(int index = 0; index < numbers.Length - 1; index++)
            {
                int min_value = numbers[index];
                for(int next = index + 1; next < numbers.Length; next++)
                {
                    if (numbers[next] < min_value)
                        min_value = numbers[next];
                }
                if (min_value != numbers[index])
                    swap_numbers(numbers, find_index(numbers, min_value), index);
            }
        }

        private static int find_index(int[] numbers, int value)
        {
            int index = 0;
            foreach(int item in numbers)
            {
                if (value != item)
                    index++;
                else if (value == item)
                    return index;
            }
            return -1;
        }

        private static void swap_numbers(int[] numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }
    }
}