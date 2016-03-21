using System;
using System.Diagnostics;

namespace Assignment5
{
    class Caller
    {
        public static void Main()
        {
            BSTree();
            //ETree();
            //CustomTree();
        }

        private static void BSTree()
        {

            BinarySearchTree<int> tree = new BinarySearchTree<int>(new numberComparer());
            int[] tempList = new int[] { 50, 25, 70, 15, 45, 30, 49, 90, 80 };

            foreach (int number in tempList)
                tree.Add(number);

            //tree.Remove(tree.Contains(25));

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
        }

        private static void CustomTree()
        {
            BinarySearchTree<Hero> heroTree = new BinarySearchTree<Hero>(new HeroComparer());

            MyList<Hero> heroList = new MyList<Hero>(10);
            heroList[0] = new Hero { Name = "Ashe", Health = 528, Attack = 57, Defense = 21 };
            heroList[1] = new Hero { Name = "Jinx", Health = 518, Attack = 58, Defense = 23 };
            heroList[2] = new Hero { Name = "Varus", Health = 538, Attack = 55, Defense = 23 };
            heroList[3] = new Hero { Name = "Vayne", Health = 498, Attack = 56, Defense = 19 };
            heroList[4] = new Hero { Name = "Kalista", Health = 518, Attack = 63, Defense = 19 };
            heroList[5] = new Hero { Name = "Jhin", Health = 540, Attack = 53, Defense = 20 };
            heroList[6] = new Hero { Name = "Caitlyn", Health = 524, Attack = 54, Defense = 23 };
            heroList[7] = new Hero { Name = "Draven", Health = 558, Attack = 56, Defense = 26 };
            heroList[8] = new Hero { Name = "Graves", Health = 551, Attack = 61, Defense = 24 };
            heroList[9] = new Hero { Name = "Lucian", Health = 554, Attack = 57, Defense = 24 };

            foreach (Hero hero in heroList)
                heroTree.Add(hero);
        }

        private static void ETree()
        {
            try
            {
                Console.Write("Type into the console the following expression 5 + 2 * 8 – 6 / 4: \n");
                string input = Console.ReadLine();

                ExpressionTree ETree = new ExpressionTree(input);

                MyList<string> preList = new MyList<string>(ETree.NodeCount);
                string preResult = ETree.TraversePre(preList, ETree.root);
                TestPre_ET(preResult);
                Console.WriteLine("\nPre-order: [{0}]\n", preResult);

                MyList<string> inList = new MyList<string>(ETree.NodeCount);
                string inResult = ETree.TraverseIn(inList, ETree.root);
                TestIn_ET(inResult);
                Console.WriteLine("In-order: [{0}]\n", inResult);

                MyList<string> postList = new MyList<string>(ETree.NodeCount);
                string postResult = ETree.TraversePost(postList, ETree.root);
                TestPost_ET(postResult);
                Console.WriteLine("Post-order: [{0}]\n", postResult);

                ETree.Evaluate(ETree.root);
                Console.WriteLine(ETree.root.Data);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nInput can't be empty, please try again.\n");
                ETree();
            }
        }

        private static void TestPre_BST(string result)
        {
            Debug.Assert(result == "50, 25, 15, 45, 30, 49, 70, 90, 80", "BINARY SEARCH TREE: Order doesn't match!");
        }

        private static void TestIn_BST(string result)
        {
            Debug.Assert(result == "15, 25, 30, 45, 49, 50, 70, 80, 90", "BINARY SEARCH TREE: Order doesn't match!");
        }

        private static void TestPost_BST(string result)
        {
            Debug.Assert(result == "15, 30, 49, 45, 25, 80, 90, 70, 50", "BINARY SEARCH TREE: Order doesn't match!");
        }

        private static void TestPre_ET(string result)
        {
            Debug.Assert(result == "+, 5, *, 2, -, 8, /, 6, 4", "EXPRESSION TREE: Order doesn't match!");
        }

        private static void TestIn_ET(string result)
        {
            Debug.Assert(result == "5, +, 2, *, 8, -, 6, /, 4", "EXPRESSION TREE: Order doesn't match!");
        }

        private static void TestPost_ET(string result)
        {
            Debug.Assert(result == "5, 2, 8, 6, 4, /, -, *, +", "EXPRESSION TREE: Order doesn't match!");
        }
    }
}