using System;
using System.Collections.Generic;

namespace Assignment5
{
    class TreeNode<T> : IComparable<T>//, IComparer<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode<T> Parent { get; set; } // TODO Remove Parent once BST is recursive
        public int Height { get; set; }

        public int CompareTo(T other)
        {
            var tempOne = Data.ToString();
            var tempTwo = other.ToString();
            return Int32.Parse(tempOne) - Int32.Parse(tempTwo);
        }

        //public int Compare(T x, T y)
        //{
        //    throw new NotImplementedException();
        //}
    }
}