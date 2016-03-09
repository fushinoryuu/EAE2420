using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment5
{
    class ExpressionParser
    {
        private Stack<TreeNode<string>> numberStack, operatorStack;

        public ExpressionParser(ExpressionTree ETree, string input)
        {
            numberStack = new Stack<TreeNode<string>>();
            operatorStack = new Stack<TreeNode<string>>();

            ToArray(ETree, input);
        }

        public void ToArray(ExpressionTree ETree, string input)
        {
            string[] expressions = new string[input.Length];
            expressions = input.Split();

            BuildNodes(expressions, ETree);
        }

        private void BuildNodes(string[] expressions, ExpressionTree ETree)
        {
            foreach (string item in expressions)
            {
                int tempInt;
                if (Int32.TryParse(item, out tempInt))
                {
                    TreeNode<string> number_node = new TreeNode<string> { data = tempInt.ToString() };
                    numberStack.Push(number_node);
                }
                else
                {
                    TreeNode<string> operator_node = new TreeNode<string> { data = item };
                    operatorStack.Push(operator_node);
                }
            }
            BuildTree(ETree);
        }

        private void BuildTree(ExpressionTree ETree)
        {
            ETree.node_count = numberStack.Count + operatorStack.Count;

            while (operatorStack.Count != 0)
            {
                TreeNode<string> tempRoot = operatorStack.Pop();
                tempRoot.right = numberStack.Pop();
                tempRoot.left = numberStack.Pop();
                numberStack.Push(tempRoot);
            }

            ETree.root = numberStack.Pop();
        }
    }
}