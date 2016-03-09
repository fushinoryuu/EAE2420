using System;

namespace Assignment5
{
    class TreeNode<T> : IComparable<T>
    {
        public T data { get; set; }
        public TreeNode<T> left { get; set; }
        public TreeNode<T> right { get; set; }
        public TreeNode<T> parent { get; set; }
        public int height { get; set; }

        public int CompareTo(T other)
        {
            return this.data - other;
        }
    }
}