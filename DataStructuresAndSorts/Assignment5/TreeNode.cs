using System;
using System.Collections.Generic;

namespace Assignment5
{
    class TreeNode<T> : IComparable<T>//, IComparer<T>
    {
        public T data { get; set; }
        public TreeNode<T> left { get; set; }
        public TreeNode<T> right { get; set; }
        public TreeNode<T> parent { get; set; } // TODO Remove Parent once BST is recursive
        public int height { get; set; }

        public int CompareTo(T other)
        {
            var tempOne = data.ToString();
            var tempTwo = other.ToString();
            return Int32.Parse(tempOne) - Int32.Parse(tempTwo);
        }

        //public int Compare(T x, T y)
        //{
        //    throw new NotImplementedException();
        //}
    }
}