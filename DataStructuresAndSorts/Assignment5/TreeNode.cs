namespace Assignment5
{
    class TreeNode<T>
    {
        public T data;
        public TreeNode<T> left, right, parent;

        public TreeNode(T data, TreeNode<T> left = null, TreeNode<T> right = null, TreeNode<T> parent = null)
        {
            this.data = data;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
    }
}
