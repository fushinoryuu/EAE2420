namespace Assignment5
{
    class TreeNode
    {
        public int data;
        public TreeNode left, right, parent;

        public TreeNode(int data, TreeNode left = null, TreeNode right = null, TreeNode parent = null)
        {
            this.data = data;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
    }
}
