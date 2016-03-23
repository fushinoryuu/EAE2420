using System;
using System.Collections.Generic;

namespace Assignment5
{
    class BinarySearchTree<T>
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
                if (comparer.Compare(item, currentNode.Data) < 0)
                {
                    if (currentNode.Left == null)
                        currentNode.Left = new TreeNode<T> { Data = item };
                    else
                        Add(item, currentNode.Left);
                }
                else if (comparer.Compare(item, currentNode.Data) >= 0)
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

        public string TraversePre(MyList<T> list, TreeNode<T> node)
        {
            list.Add(node.Data);
            if (node.Left != null)
                TraversePre(list, node.Left);
            if (node.Right != null)
                TraversePre(list, node.Right);
            return string.Join(", ", list);
        }

        public string TraverseIn(MyList<T> list, TreeNode<T> node)
        {
            if (node.Left != null)
                TraverseIn(list, node.Left);
            list.Add(node.Data);
            if (node.Right != null)
                TraverseIn(list, node.Right);
            return string.Join(", ", list);
        }

        public string TraversePost(MyList<T> list, TreeNode<T> node)
        {
            if (node.Left != null)
                TraversePost(list, node.Left);
            if (node.Right != null)
                TraversePost(list, node.Right);
            list.Add(node.Data);
            return string.Join(", ", list);
        }
    }
}