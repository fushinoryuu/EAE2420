using System;
using System.Collections.Generic;

namespace Assignment5
{
    class ExpressionTree
    {
        public TreeNode<string> root;

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
                string[] expressionArray = new string[input.Length];
                expressionArray = input.Split();

                BuildNodes(tree, expressionArray);
            }

            private void BuildNodes(ExpressionTree tree, string[] expressionArray)
            {
                foreach (string item in expressionArray)
                {
                    double tempNumber;
                    if (double.TryParse(item, out tempNumber))
                    {
                        TreeNode<string> number_node = new TreeNode<string> { Data = tempNumber.ToString() };
                        numberStack.Push(number_node);
                    }
                    else
                    {
                        TreeNode<string> operator_node = new TreeNode<string> { Data = item };

                        if (operatorStack.Count != 0 && (item == "-" || item == "+") &&
                            (operatorStack.Peek().Data == "*" || operatorStack.Peek().Data == "/"))
                        {
                            TreeNode<string> subTree = operatorStack.Pop();
                            subTree.Right = numberStack.Pop();
                            subTree.Left = numberStack.Pop();
                            numberStack.Push(subTree);
                            operatorStack.Push(operator_node);
                        }
                        else
                        {
                            operatorStack.Push(operator_node);
                        }
                    }
                }
                BuildTree(tree);
            }

            private void BuildTree(ExpressionTree tree)
            {
                while (operatorStack.Count != 0)
                {
                    TreeNode<string> subRoot = operatorStack.Pop();
                    subRoot.Right = numberStack.Pop();
                    subRoot.Left = numberStack.Pop();
                    numberStack.Push(subRoot);
                }
                tree.root = numberStack.Pop();
            }
        }

        public void Evaluate(TreeNode<string> node)
        {
            if (node.Left != null)
                Evaluate(node.Left);
            if (node.Right != null)
                Evaluate(node.Right);
            switch (node.Data)
            {
                case "+":
                    double addResult = double.Parse(node.Left.Data) + double.Parse(node.Right.Data);
                    node.Data = addResult.ToString();
                    node.Left = null;
                    node.Right = null;
                    break;
                case "-":
                    double subResult = double.Parse(node.Left.Data) - double.Parse(node.Right.Data);
                    node.Data = subResult.ToString();
                    node.Left = null;
                    node.Right = null;
                    break;
                case "*":
                    double multResult = double.Parse(node.Left.Data) * double.Parse(node.Right.Data);
                    node.Data = multResult.ToString();
                    node.Left = null;
                    node.Right = null;
                    break;
                case "/":
                    double divResult = double.Parse(node.Left.Data) / double.Parse(node.Right.Data);
                    node.Data = divResult.ToString();
                    node.Left = null;
                    node.Right = null;
                    break;
                case "^":
                    double expResult = Math.Pow(double.Parse(node.Left.Data), double.Parse(node.Right.Data));
                    node.Data = expResult.ToString();
                    node.Left = null;
                    node.Right = null;
                    break;
            }
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