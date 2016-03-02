using System;

namespace Assignment5
{
    class Caller
    {
        public static void Main()
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] list = new int[] { 5, 7, 2 };

            for (int i = 0; i < list.Length; i++)
                tree.Add(list[i]);

            Console.WriteLine(tree.root.data);
            Console.WriteLine(tree.root.left.data);
            Console.WriteLine(tree.root.right.data);
        }
    }
}