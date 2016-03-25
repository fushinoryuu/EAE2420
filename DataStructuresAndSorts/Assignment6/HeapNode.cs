namespace Assignment6
{
    class HeapNode<T>
    {
        public T Value { get; set; }
        HeapNode<T> Left { get; set; }
        HeapNode<T> Right { get; set; }
    }
}