using System;

namespace Assignment5
{
    class ExpressionTree
    {
        public TreeNode<string> root;
        //private int node_count;

        public ExpressionTree()
        {
            root = null;
        }

        public void Add(TreeNode<string> new_node)
        {
            if (root == null)
            {
                root = new_node;
            }
            else
            {
                TreeNode<string> crawler = root;

                while (crawler != null)
                {
                    new_node.parent = crawler;
                }
            }
        }

        public void Evaluate()
        {

        }

        public string TraversePre(MyList<string> list, TreeNode<string> node)
        {
            list.Add(node.data);
            if (node.left != null)
                TraversePre(list, node.left);
            if (node.right != null)
                TraversePre(list, node.right);
            return string.Join(", ", list);
        }

        public string TraverseIn(MyList<string> list, TreeNode<string> node)
        {
            if (node.left != null)
                TraverseIn(list, node.left);
            list.Add(node.data);
            if (node.right != null)
                TraverseIn(list, node.right);
            return string.Join(", ", list);
        }

        public string TraversePost(MyList<string> list, TreeNode<string> node)
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