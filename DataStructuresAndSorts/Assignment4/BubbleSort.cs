namespace Assignment4
{
    class BubbleSort
    {
        public void bubble_sort(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                int current_item = 0;
                for(int next_item = 1; next_item < numbers.Length; next_item++)
                {
                    if (numbers[current_item] > numbers[next_item])
                        swap_numbers(numbers, current_item, next_item);
                    current_item++;
                }
            }
        }

        static void swap_numbers(int[] numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }
    }
}