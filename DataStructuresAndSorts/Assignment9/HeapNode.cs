namespace Assignment9
{
    class HeapNode<T>
    {
        public T Data { get; set; }
        public HeapNode<T> Left { get; set; }
        public HeapNode<T> Right { get; set; }
    }
}
