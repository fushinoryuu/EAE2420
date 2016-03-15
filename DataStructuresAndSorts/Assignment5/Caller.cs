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
            int[] tempList = new int[] { 50, 25, 70, 15, 45, 30, 49, 90, 80 };

            for (int i = 0; i < tempList.Length; i++)
                tree.Add(tempList[i]);

            //for (int i = 0; i < tempList.Length; i++)
            //    tree.RecursiveAdd(tempList[i], tree.root);

            tree.Remove(tree.Contains(25));

            MyList<int> preList = new MyList<int>(tree.NodeCount);
            string preResult = tree.TraversePre(preList, tree.root);
            TestPre_BST(preResult);
            Console.WriteLine("\nPre-order: [{0}]\n", preResult);

            MyList<int> inList = new MyList<int>(tree.NodeCount);
            string inResult = tree.TraverseIn(inList, tree.root);
            TestIn_BST(inResult);
            Console.WriteLine("In-order: [{0}]\n", inResult);

            MyList<int> postList = new MyList<int>(tree.NodeCount);
            string postResult = tree.TraversePost(postList, tree.root);
            TestPost_BST(postResult);
            Console.WriteLine("Post-order: [{0}]\n", postResult);

            Console.WriteLine(tree.root.height);
        }

        private static void ETree()
        {
            try
            {
                Console.Write("Enter an expression: ");
                string input = Console.ReadLine();

                //Console.WriteLine("Expression to evaluate: 5 + 2 * 8 – 6 / 4");
                //string input = "5 + 2 * 8 – 6 / 4";

                ExpressionTree ETree = new ExpressionTree();
                ExpressionParser parser = new ExpressionParser(ETree, input);

                MyList<string> preList = new MyList<string>(ETree.node_count);
                string preResult = ETree.TraversePre(preList, ETree.root);
                TestPre_ET(preResult);
                Console.WriteLine("\nPre-order: [{0}]\n", preResult);

                MyList<string> inList = new MyList<string>(ETree.node_count);
                string inResult = ETree.TraverseIn(inList, ETree.root);
                TestIn_ET(inResult);
                Console.WriteLine("In-order: [{0}]\n", inResult);

                MyList<string> postList = new MyList<string>(ETree.node_count);
                string postResult = ETree.TraversePost(postList, ETree.root);
                TestPost_ET(postResult);
                Console.WriteLine("Post-order: [{0}]\n", postResult);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nInput can't be empty, please try again.\n");
                ETree();
            }
        }

        private static void TestPre_BST(string result)
        {
            Debug.Assert(result == "50, 25, 15, 45, 30, 49, 70, 90, 80", "Order doesn't match!");
        }

        private static void TestIn_BST(string result)
        {
            Debug.Assert(result == "15, 25, 30, 45, 49, 50, 70, 80, 90", "Order doesn't match!");
        }

        private static void TestPost_BST(string result)
        {
            Debug.Assert(result == "15, 30, 49, 45, 25, 80, 90, 70, 50", "Order doesn't match!");
        }

        private static void TestPre_ET(string result)
        {
            Debug.Assert(result == "+, 5, *, 2, -, 8, /, 6, 4", "Order doesn't match!");
        }

        private static void TestIn_ET(string result)
        {
            Debug.Assert(result == "5, +, 2, *, 8, -, 6, /, 4", "Order doesn't match!");
        }

        private static void TestPost_ET(string result)
        {
            Debug.Assert(result == "5, 2, 8, 6, 4, /, -, *, +", "Order doesn't match!");
        }
    }
}