using System;
using System.Collections.Generic;

namespace Assignment5
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        IComparer<T> comparer;
        public TreeNode<T> root;


        public BinarySearchTree(IComparer<T> comparer = null)
        {
            root = null;
            this.comparer = comparer;
        }

        public void Add(T item, TreeNode<T> currentNode)
        {
            if (root == null)
            {
                root = new TreeNode<T> { Data = item };
                currentNode = root;
            }
            else
            {
                if ((comparer.Compare(item, currentNode.Data) < 0) || (item.CompareTo(currentNode.Data) < 0))
                {
                    if (currentNode.Left == null)
                        currentNode.Left = new TreeNode<T> { Data = item };
                    else
                        Add(item, currentNode.Left);
                }
                else if ((comparer.Compare(item, currentNode.Data) >= 0) || (item.CompareTo(currentNode.Data) >= 0))
                {
                    if (currentNode.Right == null)
                        currentNode.Right = new TreeNode<T> { Data = item };
                    else
                        Add(item, currentNode.Right);
                }
            }
        }

        public bool Contains(T item, TreeNode<T> currentNode)
        {
            if (currentNode != null)
            {
                if (comparer.Compare(item, currentNode.Data) == 0)
                    return true;
                else if (comparer.Compare(item, currentNode.Data) < 0)
                    return Contains(item, currentNode.Left);
                else
                    return Contains(item, currentNode.Right);
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            root = null;
        }

        public string TraversePre()
        {
            MyList<T> list = new MyList<T>(10);
            PreHelper(list, root);
            return string.Join(", ", list);
        }

        private void PreHelper(MyList<T> list, TreeNode<T> node)
        {
            list.Add(node.Data);
            if (node.Left != null)
                PreHelper(list, node.Left);
            if (node.Right != null)
                PreHelper(list, node.Right);
        }

        public string TraverseIn()
        {
            MyList<T> list = new MyList<T>(10);
            InHelper(list, root);
            return string.Join(", ", list);
        }

        private void InHelper(MyList<T> list, TreeNode<T> node)
        {
            if (node.Left != null)
                InHelper(list, node.Left);
            list.Add(node.Data);
            if (node.Right != null)
                InHelper(list, node.Right);
        }

        public string TraversePost()
        {
            MyList<T> list = new MyList<T>(10);
            PostHelper(list, root);
            return string.Join(", ", list);
        }

        private void PostHelper(MyList<T> list, TreeNode<T> node)
        {
            if (node.Left != null)
                PostHelper(list, node.Left);
            if (node.Right != null)
                PostHelper(list, node.Right);
            list.Add(node.Data);
        }
    }
}