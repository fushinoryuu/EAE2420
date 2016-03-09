﻿using System;
using System.Diagnostics;

namespace Assignment5
{
    class Caller
    {
        public static void Main()
        {
            BSTree();
            ETree();
        }

        private static void BSTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int[] temp = new int[] { 50, 25, 70, 15, 45, 30, 49, 90, 80 };

            for (int i = 0; i < temp.Length; i++)
                tree.Add(temp[i]);

            tree.Remove(tree.Contains(25));

            MyList<int> preList = new MyList<int>(tree.NodeCount);
            string preResult = tree.TraversePre(preList, tree.root);
            TestPre(preResult);
            Console.WriteLine("\nPre-order: [{0}]\n", preResult);

            MyList<int> inList = new MyList<int>(tree.NodeCount);
            string inResult = tree.TraverseIn(inList, tree.root);
            TestIn(inResult);
            Console.WriteLine("In-order: [{0}]\n", inResult);

            MyList<int> postList = new MyList<int>(tree.NodeCount);
            string postResult = tree.TraversePost(postList, tree.root);
            TestPost(postResult);
            Console.WriteLine("Post-order: [{0}]\n", postResult);

            Console.WriteLine(tree.root.height);


        }

        private static void ETree()
        {
            ExpressionTree ETree = new ExpressionTree();
            ExpressionParser parser = new ExpressionParser(ETree);

            //MyList<string> preList = new MyList<string>(5);
            //string preResult = ETree.TraversePre(preList, ETree.root);
            //Console.WriteLine("\nPre-order: [{0}]\n", preResult);

            //MyList<string> inList = new MyList<string>(5);
            //string inResult = ETree.TraverseIn(inList, ETree.root);
            //Console.WriteLine("In-order: [{0}]\n", inResult);

            //MyList<string> postList = new MyList<string>(5);
            //string postResult = ETree.TraversePost(postList, ETree.root);
            //Console.WriteLine("Post-order: [{0}]\n", postResult);
        }

        private static void TestPre(string result)
        {
            Debug.Assert(result == "50, 25, 15, 45, 30, 49, 70, 90, 80", "Order doesn't match!");
        }

        private static void TestIn(string result)
        {
            Debug.Assert(result == "15, 25, 30, 45, 49, 50, 70, 80, 90", "Order doesn't match!");
        }

        private static void TestPost(string result)
        {
            Debug.Assert(result == "15, 30, 49, 45, 25, 80, 90, 70, 50", "Order doesn't match!");
        }
    }
}