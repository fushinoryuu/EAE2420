using System;
using System.Collections.Generic;

namespace Assignment5
{
    class ExpressionTree
    {
        public TreeNode<string> root;
        private int node_count;

        public ExpressionTree(string input)
        {
            root = null;
            ExpressionParser parser = new ExpressionParser(this, input);
        }

        private class ExpressionParser
        {
            private Stack<TreeNode<string>> numberStack, operatorStack;

            public ExpressionParser(ExpressionTree tree, string input)
            {
                numberStack = new Stack<TreeNode<string>>();
                operatorStack = new Stack<TreeNode<string>>();
                Console.WriteLine(input.Length);
                string[] expressionArray = new string[input.Length];
                expressionArray = input.Split();

                BuildNodes(tree, expressionArray);
            }

            private void BuildNodes(ExpressionTree tree, string[] expressionArray)
            {
                foreach (string item in expressionArray)
                {
                    int tempInt;
                    if (Int32.TryParse(item, out tempInt))
                    {
                        TreeNode<string> number_node = new TreeNode<string> { Data = tempInt.ToString() };
                        numberStack.Push(number_node);
                    }
                    else
                    {
                        TreeNode<string> operator_node = new TreeNode<string> { Data = item };
                        operatorStack.Push(operator_node);
                    }
                }
                BuildTree(tree);
            }

            private void BuildTree(ExpressionTree tree)
            {
                tree.node_count = numberStack.Count + operatorStack.Count;

                while (operatorStack.Count != 0)
                {
                    TreeNode<string> tempRoot = operatorStack.Pop();
                    tempRoot.Right = numberStack.Pop();
                    tempRoot.Left = numberStack.Pop();
                    numberStack.Push(tempRoot);
                }

                tree.root = numberStack.Pop();
            }
        }

        public int NodeCount
        {
            get
            {
                return node_count;
            }
        }

        // TODO Finish Evaluate
        public void Evaluate(MyList<string> list, TreeNode<string> node)
        {
            if (node.Left != null)
                Evaluate(list, node.Left);
            if (node.Right != null)
                Evaluate(list, node.Right);
            throw new NotImplementedException();
        }

        public string TraversePre(MyList<string> list, TreeNode<string> node)
        {
            list.Add(node.Data);
            if (node.Left != null)
                TraversePre(list, node.Left);
            if (node.Right != null)
                TraversePre(list, node.Right);
            return string.Join(", ", list);
        }

        public string TraverseIn(MyList<string> list, TreeNode<string> node)
        {
            if (node.Left != null)
                TraverseIn(list, node.Left);
            list.Add(node.Data);
            if (node.Right != null)
                TraverseIn(list, node.Right);
            return string.Join(", ", list);
        }

        public string TraversePost(MyList<string> list, TreeNode<string> node)
        {
            if (node.Left != null)
                TraversePost(list, node.Left);
            if (node.Right != null)
                TraversePost(list, node.Right);
            list.Add(node.Data);
            return string.Join(", ", list);
        }
    }
}