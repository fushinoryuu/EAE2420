using System.Collections.Generic;

namespace Assignment5
{
    class ExpressionParser
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
}
