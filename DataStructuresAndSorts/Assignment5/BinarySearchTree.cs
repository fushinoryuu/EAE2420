using System;

namespace Assignment5
{
    class BinarySearchTree
    {
        public TreeNode<int> root;
        private int node_count;

        public BinarySearchTree()
        {
            root = null;
            node_count = 0;
        }

        public void Add(int item)
        {
            TreeNode<int> new_node = new TreeNode<int>(item);

            if (root == null)
                root = new_node;
            else
            {
                TreeNode<int> crawler = root;

                while (crawler != null)
                {
                    new_node.parent = crawler;
                    if (item >= crawler.data)
                        crawler = crawler.right;
                    else
                        crawler = crawler.left;
                }

                if (item >= new_node.parent.data)
                    new_node.parent.right = new_node;
                else
                    new_node.parent.left = new_node;
            }
            node_count++;
            CalculateHeight(root);
        }

        public TreeNode<int> Contains(int item)
        {
            TreeNode<int> crawler = root;

            while (crawler != null)
            {
                if (item == crawler.data)
                    return crawler;
                else if (item >= crawler.data)
                    crawler = crawler.right;
                else
                    crawler = crawler.left;
            }
            return null;
        }

        // TODO Finish Remove function
        public void Remove(TreeNode<int> node)
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

        private void CalculateHeight(TreeNode<int> node)
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

            CheckBalance(node);
        }

        private void CheckBalance(TreeNode<int> node)
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
        private void Rotate(TreeNode<int> node)
        {
            //TreeNode<int> temp = node;
            
            //node.left = temp;
            //node.left.parent = node;
            //node = node.right;
            //node.right.parent = node;
            //node.right = node.right.right;
        }

        public string TraversePre(MyList<int> list, TreeNode<int> node)
        {
            list.Add(node.data);
            if (node.left != null)
                TraversePre(list, node.left);
            if (node.right != null)
                TraversePre(list, node.right);
            return string.Join(", ", list);
        }

        public string TraverseIn(MyList<int> list, TreeNode<int> node)
        {
            if (node.left != null)
                TraverseIn(list, node.left);
            list.Add(node.data);
            if (node.right != null)
                TraverseIn(list, node.right);
            return string.Join(", ", list);
        }

        public string TraversePost(MyList<int> list, TreeNode<int> node)
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