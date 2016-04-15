using System.Collections.Generic;

namespace Assignment5
{
    class ExpressionParser
    {
        private Stack<TreeNode<string>> NumberStack, OperatorStack;

        public ExpressionParser()
        {
            NumberStack = new Stack<TreeNode<string>>();
            OperatorStack = new Stack<TreeNode<string>>();
        }

        public ExpressionTree Parse(string input)
        {
            string[] expressionArray = new string[input.Length];
            expressionArray = input.Split();

            BuildNodes(expressionArray);
            BuildTree();

            ExpressionTree tree = new ExpressionTree();
            tree.Root = NumberStack.Pop();
            tree.Root = RotateLeft(tree.Root);
            return tree;
        }

        private void BuildNodes(string[] expressionArray)
        {
            foreach (string item in expressionArray)
            {
                double tempNumber;
                if (double.TryParse(item, out tempNumber))
                {
                    TreeNode<string> number_node = new TreeNode<string> { Data = tempNumber.ToString() };
                    NumberStack.Push(number_node);
                }
                else
                {
                    TreeNode<string> operator_node = new TreeNode<string> { Data = item };
                    OperatorStack.Push(operator_node);
                }
            }
        }

        private void BuildTree()
        {
            while (OperatorStack.Count != 0)
            {
                TreeNode<string> temp_root = OperatorStack.Pop();

                temp_root.Right = NumberStack.Pop();
                temp_root.Left = NumberStack.Pop();

                temp_root = CheckPrecedence(temp_root);

                NumberStack.Push(temp_root);
            }
        }

        private TreeNode<string> CheckPrecedence(TreeNode<string> sub_root)
        {
            if ((sub_root.Data == "*" || sub_root.Data == "/" || sub_root.Data == "^") && 
                (sub_root.Right.Data == "+" || sub_root.Right.Data == "-"))
                sub_root = RotateLeft(sub_root);

            else if ((sub_root.Data == "*" || sub_root.Data == "/" || sub_root.Data == "^") && 
                (sub_root.Left.Data == "+" || sub_root.Left.Data == "-"))
                sub_root = RotateRight(sub_root);

            return sub_root;
        }

        private TreeNode<string> RotateLeft(TreeNode<string> current_node)
        {
            TreeNode<string> temp_node = current_node;

            current_node = current_node.Right;
            temp_node.Right = current_node.Left;
            current_node.Left = temp_node;

            return current_node;
        }

        private TreeNode<string> RotateRight(TreeNode<string> current_node)
        {
            TreeNode<string> temp_node = current_node;

            current_node = current_node.Left;
            temp_node.Left = current_node.Right;
            current_node.Right = temp_node;

            return current_node;
        }
    }
}