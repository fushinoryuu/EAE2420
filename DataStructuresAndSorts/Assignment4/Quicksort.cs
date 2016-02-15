namespace Assignment4
{
    class QuickSort : ISorter
    {
        private static void swap_numbers(int[] numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }

        private static int partition(int[] numbers, int low, int high)
        {
            int pivot = numbers[low];
            int wall = low;
            for(int i = low + 1; i < high; i++)
            {
                if(numbers[i] < pivot)
                {
                    wall++;
                    swap_numbers(numbers, i, wall);
                }

            }
            swap_numbers(numbers, low, wall);
            return wall;
        }

        public void sort(int[] numbers, int low, int high)
        {
            if(low < high)
            {
                int pivot_location = partition(numbers, low, high);
                sort(numbers, low, pivot_location);
                sort(numbers, pivot_location + 1, high);
            }
        }
    }
}