using System;
using System.Collections.Generic;

namespace Assignment5
{
    class BinarySearchTree<T>
    {
        IComparer<T> comparer;
        public TreeNode<T> root;
        private int node_count;

        public BinarySearchTree(IComparer<T> comparer = null)
        {
            root = null;
            node_count = 0;
            this.comparer = comparer;
        }

        public void Add(T item, TreeNode<T> currentNode)
        {
            if (root == null)
                root = new TreeNode<T> { Data = item };
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
            node_count++;
            CalculateHeight(root);
        }

        public TreeNode<T> Contains(T item, TreeNode<T> currentNode)
        {
            if (currentNode != null)
            {
                if (comparer.Compare(item, currentNode.Data) == 0)
                    return currentNode;
                else if (comparer.Compare(item, currentNode.Data) < 0)
                    return Contains(item, currentNode.Left);
                else
                    return Contains(item, currentNode.Right);
            }
            else
            {
                Console.WriteLine("Value Not Found!");
                return null;
            }
        }

        // TODO Finish Remove function
        public void Remove(TreeNode<T> node)
        {
            if (node == null)
                Console.WriteLine("\nNode Not Found!\n");
            else
            {
                CalculateHeight(root);
            }
        }

        public void Clear()
        {
            root = null;
            node_count = 0;
        }

        public int NodeCount
        {
            get
            {
                return node_count;
            }
        }

        private void CalculateHeight(TreeNode<T> node)
        {
            if (node.Left != null)
                CalculateHeight(node.Left);
            if (node.Right != null)
                CalculateHeight(node.Right);

            if (node.Left != null && node.Right != null)
                node.Height = Math.Max(node.Left.Height, node.Right.Height) + 1;

            else if (node.Left != null && node.Right == null)
                node.Height = node.Left.Height + 1;

            else if (node.Left == null && node.Right != null)
                node.Height = node.Right.Height + 1;

            else if (node.Left == null && node.Right == null)
                node.Height = 1;

            CheckBalance(node);
        }

        private void CheckBalance(TreeNode<T> node)
        {
            if (node.Left == null && node.Right == null)
                return;

            else if (node.Left != null && node.Right == null)
                if (node.Left.Height > 1)
                    Rotate(node);

                else if (node.Left == null && node.Right != null)
                    if (node.Right.Height > 1)
                        Rotate(node);

                    else if (node.Left != null && node.Right != null)
                        if (node.Left.Height > node.Right.Height + 1)
                            Rotate(node.Left);
                        else if (node.Right.Height > node.Left.Height + 1)
                            Rotate(node.Right);
        }

        // TODO Finish Rotate function
        private void Rotate(TreeNode<T> node)
        {
            //TreeNode<int> temp = node;

            //node.left = temp;
            //node.left.parent = node;
            //node = node.right;
            //node.right.parent = node;
            //node.right = node.right.right;
        }

        // TO DO: Get output without list.
        public string TraversePre(MyList<T> list, TreeNode<T> node)
        {
            list.Add(node.Data);
            if (node.Left != null)
                TraversePre(list, node.Left);
            if (node.Right != null)
                TraversePre(list, node.Right);
            return string.Join(", ", list);
        }

        // TO DO: Get output without list.
        public string TraverseIn(MyList<T> list, TreeNode<T> node)
        {
            if (node.Left != null)
                TraverseIn(list, node.Left);
            list.Add(node.Data);
            if (node.Right != null)
                TraverseIn(list, node.Right);
            return string.Join(", ", list);
        }

        // TO DO: Get output without list.
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