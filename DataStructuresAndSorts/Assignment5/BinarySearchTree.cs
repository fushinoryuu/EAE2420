namespace Assignment5
{
    class BinarySearchTree
    {
        public TreeNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void Add(int item)
        {
            TreeNode new_node = new TreeNode(item);
            if (root == null)
                root = new_node;
            else
            {
                TreeNode crawler = root;

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

        public void Clear()
        {
            root = null;
        }

    }
}
