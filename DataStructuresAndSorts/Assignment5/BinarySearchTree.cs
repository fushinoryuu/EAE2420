namespace Assignment5
{
    class BinarySearchTree
    {
        public TreeNode<int> root;

        public BinarySearchTree()
        {
            root = null;
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
        }

        public bool Contains(int item)
        {
            TreeNode<int> crawler = root;
            while (crawler != null)
            {
                if (item == crawler.data)
                    return true;
                else if (item >= crawler.data) 
                    crawler = crawler.right;
                else
                    crawler = crawler.left;
            }
            return false;
        }

        public void Clear()
        {
            root = null;
        }
    }
}
