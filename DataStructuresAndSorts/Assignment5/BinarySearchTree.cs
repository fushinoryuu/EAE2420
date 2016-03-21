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

        // TODO Make Recursive
        //public void Add(T item)
        //{
        //    TreeNode<T> new_node = new TreeNode<T> { Data = item };

        //    if (root == null)
        //        root = new_node;
        //    else
        //    {
        //        TreeNode<T> crawler = root;
        //        TreeNode<T> tracker = crawler;

        //        while (crawler != null)
        //        {
        //            tracker = crawler;

        //            if (comparer.Compare(new_node.Data, crawler.Data) < 0)
        //                crawler = crawler.Left;
        //            else
        //                crawler = crawler.Right;
        //        }

        //        if (comparer.Compare(new_node.Data, tracker.Data) < 0)
        //            tracker.Left = new_node;
        //        else
        //            tracker.Right = new_node;
        //    }
        //    node_count++;
        //    CalculateHeight(root);
        //}

        public void Add(T item, TreeNode<T> currentNode = null, TreeNode<T> previousNode = null)
        {
            previousNode = currentNode;

            if (root == null)
                root = new TreeNode<T> { Data = item };
            else
            {
                if (currentNode == null)
                    return;
                else if (comparer.Compare(item, currentNode.Data) < 0)
                    Add(item, currentNode.Left, previousNode);
                else
                    Add(item, currentNode.Right, previousNode);
            }
            node_count++;
            CalculateHeight(root);
        }

        // TODO Make Recursive
        public TreeNode<T> Contains(T item)
        {
            TreeNode<T> crawler = root;

            while (crawler != null)
            {
                if (comparer.Compare(item, crawler.Data) == 0)
                    return crawler;
                else if (comparer.Compare(item, crawler.Data) < 0)
                    crawler = crawler.Left;
                else
                    crawler = crawler.Right;
            }
            return null;
        }

        public TreeNode<T> RecursiveContains(T item)
        {
            throw new NotImplementedException();
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