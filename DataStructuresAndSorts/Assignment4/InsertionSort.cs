namespace Assignment4
{
    class InsertionSort : ISorter
    {
        // TODO: this function is not sorting the last element in the list.
        public void sort(int[] numbers, int low, int high)
        {
            for(int index = 0; index < numbers.Length - 1; index++)
            {
                int current = numbers[index];
                int next = index;
                while(next > 0 && numbers[next - 1] > current)
                {
                    numbers[next] = numbers[next - 1];
                    next--;
                }
                numbers[next] = current;
            }
        }
    }
}