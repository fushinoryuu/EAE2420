namespace Assignment5
{
    class TreeNode<T>
    {
        public T data;
        public TreeNode<T> left, right, parent;
        public int height;

        public TreeNode(T data, TreeNode<T> left = null, TreeNode<T> right = null, TreeNode<T> parent = null, int height = 0)
        {
            this.data = data;
            this.left = left;
            this.right = right;
            this.parent = parent;
            this.height = height;
        }
    }
}
