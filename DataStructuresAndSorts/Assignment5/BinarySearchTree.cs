using System;
using System.Collections.Generic;

namespace Assignment5
{
    class BinarySearchTree<T>
    {
        //IComparer<T> comparer;
        public TreeNode<T> root;
        private int node_count;

        public BinarySearchTree()
        {
            root = null;
            node_count = 0;
        }

        public void Add(T item)
        {
            //TreeNode<T> new_node = new TreeNode<T>(item);
            TreeNode<T> new_node = new TreeNode<T> { data = item };

            if (root == null)
                root = new_node;
            else
            {
                TreeNode<T> crawler = root;

                while (crawler != null)
                {
                    new_node.parent = crawler;
                    if (crawler.CompareTo(item) > 0) //item >= crawler.data)
                        crawler = crawler.right;
                    else
                        crawler = crawler.left;
                }

                if (crawler.CompareTo(item) < 0) //item >= new_node.parent.data)
                    new_node.parent.right = new_node;
                else
                    new_node.parent.left = new_node;
            }
            node_count++;
            CalculateHeight(root);
            Console.WriteLine("");
        }

        // TODO Make recursive
        public TreeNode<T> Contains(T item)
        {
            TreeNode<T> crawler = root;

            while (crawler != null)
            {
                if (EqualityComparer<T>.Default.Equals(item, crawler.data)) //item == crawler.data)
                    return crawler;
                else if (crawler.CompareTo(item) > 0) //item >= crawler.data)
                    crawler = crawler.right;
                else
                    crawler = crawler.left;
            }
            return null;
        }

        // TODO Finish Remove function
        public void Remove(TreeNode<T> node)
        {
            if (node == null)
                Console.WriteLine("\nCould not remove the node you were looking for!\n");
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
            if (node.left != null)
                CalculateHeight(node.left);
            if (node.right != null)
                CalculateHeight(node.right);

            if (node.left != null && node.right != null)
                node.height = Math.Max(node.left.height, node.right.height) + 1;

            else if (node.left != null && node.right == null)
                node.height = node.left.height + 1;

            else if (node.left == null && node.right != null)
                node.height = node.right.height + 1;

            else if (node.left == null && node.right == null)
                node.height = 1;
            Console.WriteLine("Node value: {0} Node Height: {1}", node.data, node.height);
            CheckBalance(node);
        }

        private void CheckBalance(TreeNode<T> node)
        {
            if (node.left == null && node.right == null)
                return;

            else if (node.left != null && node.right == null)
                if (node.left.height > 1)
                    Rotate(node);

                else if (node.left == null && node.right != null)
                    if (node.right.height > 1)
                        Rotate(node);

                    else if (node.left != null && node.right != null)
                    {
                        if (node.left.height > node.right.height + 1)
                            Rotate(node.left);
                        else if (node.right.height > node.left.height + 1)
                            Rotate(node.right);
                    }
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

        public string TraversePre(MyList<T> list, TreeNode<T> node)
        {
            list.Add(node.data);
            if (node.left != null)
                TraversePre(list, node.left);
            if (node.right != null)
                TraversePre(list, node.right);
            return string.Join(", ", list);
        }

        public string TraverseIn(MyList<T> list, TreeNode<T> node)
        {
            if (node.left != null)
                TraverseIn(list, node.left);
            list.Add(node.data);
            if (node.right != null)
                TraverseIn(list, node.right);
            return string.Join(", ", list);
        }

        public string TraversePost(MyList<T> list, TreeNode<T> node)
        {
            if (node.left != null)
                TraversePost(list, node.left);
            if (node.right != null)
                TraversePost(list, node.right);
            list.Add(node.data);
            return string.Join(", ", list);
        }
    }
}