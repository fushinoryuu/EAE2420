using System;
using System.Collections.Generic;

namespace Assignment5
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        IComparer<T> CustomeComparer;
        public TreeNode<T> Root;


        public BinarySearchTree(IComparer<T> comparer = null)
        {
            Root = null;
            CustomeComparer = comparer;
        }

        public void Add(T item)
        {
            AddHelper(item, Root);
        }

        private void AddHelper(T item, TreeNode<T> current_node)
        {
            if (Root == null)
            {
                Root = new TreeNode<T> { Data = item };
                current_node = Root;
            }
            else
            {
                if ((CustomeComparer.Compare(item, current_node.Data) < 0) || (item.CompareTo(current_node.Data) < 0))
                {
                    if (current_node.Left == null)
                        current_node.Left = new TreeNode<T> { Data = item };
                    else
                        AddHelper(item, current_node.Left);
                }
                else if ((CustomeComparer.Compare(item, current_node.Data) >= 0) || (item.CompareTo(current_node.Data) >= 0))
                {
                    if (current_node.Right == null)
                        current_node.Right = new TreeNode<T> { Data = item };
                    else
                        AddHelper(item, current_node.Right);
                }
            }
        }

        public bool Contains(T item)
        {
            return ContainsHelper(item, Root);
        }

        private bool ContainsHelper(T item, TreeNode<T> current_node)
        {
            if (current_node != null)
            {
                if (CustomeComparer.Compare(item, current_node.Data) == 0)
                    return true;
                else if (CustomeComparer.Compare(item, current_node.Data) < 0)
                    return ContainsHelper(item, current_node.Left);
                else
                    return ContainsHelper(item, current_node.Right);
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            Root = null;
        }

        public string TraversePre()
        {
            List<T> list = new List<T>();
            PreHelper(list, Root);
            return string.Join(", ", list);
        }

        private void PreHelper(List<T> list, TreeNode<T> current_node)
        {
            list.Add(current_node.Data);
            if (current_node.Left != null)
                PreHelper(list, current_node.Left);
            if (current_node.Right != null)
                PreHelper(list, current_node.Right);
        }

        public string TraverseIn()
        {
            List<T> list = new List<T>();
            InHelper(list, Root);
            return string.Join(", ", list);
        }

        private void InHelper(List<T> list, TreeNode<T> current_node)
        {
            if (current_node.Left != null)
                InHelper(list, current_node.Left);
            list.Add(current_node.Data);
            if (current_node.Right != null)
                InHelper(list, current_node.Right);
        }

        public string TraversePost()
        {
            List<T> list = new List<T>();
            PostHelper(list, Root);
            return string.Join(", ", list);
        }

        private void PostHelper(List<T> list, TreeNode<T> current_node)
        {
            if (current_node.Left != null)
                PostHelper(list, current_node.Left);
            if (current_node.Right != null)
                PostHelper(list, current_node.Right);
            list.Add(current_node.Data);
        }
    }
}