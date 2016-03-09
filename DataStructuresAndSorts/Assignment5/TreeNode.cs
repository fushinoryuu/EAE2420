using System;

namespace Assignment5
{
    class TreeNode<T> //: IComparable<T>
    {
        public T data { get; set; }
        public TreeNode<T> left { get; set; }
        public TreeNode<T> right { get; set; }
        public TreeNode<T> parent { get; set; }
        public int height { get; set; }

        public int CompareTo(T other)
        {
            return data - other;
        }

        //public T data;
        //public TreeNode<T> left, right, parent;
        //public int height;

        //public TreeNode(T data, TreeNode<T> left = null, TreeNode<T> right = null, TreeNode<T> parent = null, int height = 0)
        //{
        //    this.data = data;
        //    this.left = left;
        //    this.right = right;
        //    this.parent = parent;
        //    this.height = height;
        //}

        //public int CompareTo(T other)
        //{
        //    return this.data - other;
        //}
    }
}