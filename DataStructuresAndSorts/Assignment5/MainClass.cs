using System;
using System.Diagnostics;

namespace Assignment5
{
    class MainClass
    {
        public static void Main()
        {
            NumberTree();
            HeroTree();
            ExpressionTree();
        }

        private static void NumberTree()
        {
            BinarySearchTree<int> number_tree = new BinarySearchTree<int>(new NumberComparer());
            int[] tempList = new int[] { 50, 25, 70, 15, 45, 30, 49, 90, 80 };
            
            Console.WriteLine("Adding the following numbers to a Binary Search Tree: [{0}]\n",
                string.Join(", ", tempList));

            foreach (int number in tempList)
                number_tree.Add(number);
            
            string traverseError = "BINARY SEARCH TREE: Order doesn't match!";
            string nullError = "BINARY SEARCH TREE: Tree is not null!";
            string containsError = "BINARY SEARCH TREE: Result not as expected!";
            string preExpected = "50, 25, 15, 45, 30, 49, 70, 90, 80";
            string inExpected = "15, 25, 30, 45, 49, 50, 70, 80, 90";
            string postExpected = "15, 30, 49, 45, 25, 80, 90, 70, 50";

            bool containsResult = number_tree.Contains(25);
            TestContains(containsResult, true, containsError);
            Console.WriteLine("Checking if 25 is in the tree... {0}\n", containsResult);

            containsResult = number_tree.Contains(44);
            TestContains(containsResult, false, containsError);
            Console.WriteLine("Checking if 44 is in the tree... {0}\n", containsResult);

            string preResult = number_tree.TraversePre();
            TestTraversals(preResult, preExpected, traverseError);
            Console.WriteLine("Pre-order Traversal: [{0}]\n", preResult);
            
            string inResult = number_tree.TraverseIn();
            TestTraversals(inResult, inExpected, traverseError);
            Console.WriteLine("In-order Traversal: [{0}]\n", inResult);
            
            string postResult = number_tree.TraversePost();
            TestTraversals(postResult, postExpected, traverseError);
            Console.WriteLine("Post-order Traversal: [{0}]\n", postResult);

            Console.WriteLine("Clearing the Binary Search Tree...\n");
            number_tree.Clear();
            TestNullTree(number_tree.root, nullError);

            Console.WriteLine("-------------------------------------------------------\n");
        }

        private static void HeroTree()
        {
            BinarySearchTree<Hero> hero_tree = new BinarySearchTree<Hero>(new HeroComparer());
            
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

            Console.WriteLine("Adding the following Heros to a Binary Search Tree, being sorted by their attack damage:\n");

            foreach (Hero hero in heroList)
            {
                Console.WriteLine("Name: {0}, Health: {1}, Attack: {2}, Defense: {3}",
                    hero.Name, hero.Health, hero.Attack, hero.Defense);
                hero_tree.Add(hero);
            }

            string traverseError = "HERO TREE: Order doesn't match!";
            string nullError = "HERO TREE: Tree is not null!";
            string preExpected = "Ashe, Varus, Jhin, Caitlyn, Vayne, Draven, Jinx, Lucian, Kalista, Graves";
            string inExpected = "Jhin, Caitlyn, Varus, Vayne, Draven, Ashe, Lucian, Jinx, Graves, Kalista";
            string postExpected = "Caitlyn, Jhin, Draven, Vayne, Varus, Lucian, Graves, Kalista, Jinx, Ashe";

            string preResult = hero_tree.TraversePre();
            TestTraversals(preResult, preExpected, traverseError);
            Console.WriteLine("\nPre-order Traversal: [{0}]\n", preResult);

            string inResult = hero_tree.TraverseIn();
            TestTraversals(inResult, inExpected, traverseError);
            Console.WriteLine("In-order Traversal: [{0}]\n", inResult);

            string postResult = hero_tree.TraversePost();
            TestTraversals(postResult, postExpected, traverseError);
            Console.WriteLine("Post-order Traversal: [{0}]\n", postResult);

            Console.WriteLine("Clearing the Hero Binary Search Tree...\n");
            hero_tree.Clear();
            TestNullTree(hero_tree.root, nullError);

            Console.WriteLine("-------------------------------------------------------\n");
        }

        private static void ExpressionTree()
        {
            Console.WriteLine("Type into the console the following expression '5 + 2 * 8 – 6 / 4' :\n");
            string input = Console.ReadLine();

            Console.WriteLine("\nTurning expression to an expression tree...\n", 
                input);

            ExpressionParser parser = new ExpressionParser();
            ExpressionTree expression_tree = parser.Parse(input);

            string traverseError = "EXPRESSION TREE: Order doesn't match!";
            string resultError = "EXPRESSION TREE: Result is not correct!";
            string preExpected = "-, +, 5, *, 2, 8, /, 6, 4";
            string inExpected = "5, +, 2, *, 8, -, 6, /, 4";
            string postExpected = "5, 2, 8, *, +, 6, 4, /, -";

            string preResult = expression_tree.TraversePre();
            TestTraversals(preResult, preExpected, traverseError);
            Console.WriteLine("Pre-order Traversal: [{0}]\n", preResult);

            
            string inResult = expression_tree.TraverseIn();
            TestTraversals(inResult, inExpected, traverseError);
            Console.WriteLine("In-order Traversal: [{0}]\n", inResult);
                        
            string postResult = expression_tree.TraversePost();
            TestTraversals(postResult, postExpected, traverseError);
            Console.WriteLine("Post-order Traversal: [{0}]\n", postResult);

            Console.WriteLine("Evaluating {0}...\n", input);
            expression_tree.Evaluate(expression_tree.root);
            TestResult(double.Parse(expression_tree.root.Data), 19.5, resultError);
            Console.WriteLine("Result = {0}\n", expression_tree.root.Data);
        }

        private static void TestTraversals(string actual, string expected, string error)
        {
            Debug.Assert(actual == expected, error);
        }

        private static void TestNullTree(TreeNode<int> root, string error)
        {
            Debug.Assert(root == null, error);
        }

        private static void TestNullTree(TreeNode<Hero> root, string error)
        {
            Debug.Assert(root == null, error);
        }

        private static void TestContains(bool actual, bool expected, string error)
        {
            Debug.Assert(actual == expected, error);
        }

        private static void TestResult(double actual, double expected, string error)
        {
            Debug.Assert(actual == expected, error);
        }
    }
}