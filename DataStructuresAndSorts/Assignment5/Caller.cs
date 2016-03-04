using System;

namespace Assignment5
{
    class Caller
    {
        public static void Main()
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] temp = new int[] { 50, 25, 70, 15, 45, 30, 49, 90, 80 };

            for (int i = 0; i < temp.Length; i++)
                tree.Add(temp[i]);

            MyList<int> preList = new MyList<int>(tree.NodeCount);
            tree.TraversePre(preList, tree.root);
            Console.WriteLine("Pre-order: [{0}]", string.Join(", ", preList));

            MyList<int> inList = new MyList<int>(tree.NodeCount);
            tree.TraverseIn(inList, tree.root);
            Console.WriteLine("In-order: [{0}]", string.Join(", ", inList));

            MyList<int> postList = new MyList<int>(tree.NodeCount);
            tree.TraversePost(postList, tree.root);
            Console.WriteLine("Post-order: [{0}]", string.Join(", ", postList));

            //ExpressionParser xTree = new ExpressionParser();
        }
    }
}