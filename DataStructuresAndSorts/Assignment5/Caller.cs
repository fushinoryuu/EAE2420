using System;

namespace Assignment5
{
    class Caller
    {
        public static void Main()
        {
            BinarySearchTree sTree = new BinarySearchTree();
            int[] list = new int[] { 5, 7, 2 };

            for (int i = 0; i < list.Length; i++)
                sTree.Add(list[i]);

            Console.WriteLine(sTree.root.data);
            Console.WriteLine(sTree.root.left.data);
            Console.WriteLine(sTree.root.right.data);

            Console.WriteLine(sTree.Contains(1));

            ExpressionParser xTree = new ExpressionParser();
        }
    }
}