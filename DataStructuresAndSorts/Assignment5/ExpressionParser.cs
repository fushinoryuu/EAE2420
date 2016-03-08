using System;
using System.Collections;

namespace Assignment5
{
    class ExpressionParser
    {
        private Stack numberStack, operatorStack;

        public ExpressionParser(ExpressionTree ETree)
        {
            numberStack = new Stack();
            operatorStack = new Stack();

            Parser(ETree);
        }

        public void Parser(ExpressionTree ETree)
        {
            Console.Write("Enter an expression: ");
            string input = Console.ReadLine();

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
                    TreeNode<string> number_node = new TreeNode<string>(tempInt.ToString());
                    numberStack.Push(number_node);
                }
                else
                {
                    TreeNode<string> operator_node = new TreeNode<string>(item);
                    operatorStack.Push(operator_node);
                }
            }
            BuildTree(ETree);
        }

        private void BuildTree(ExpressionTree ETree)
        {
            while(numberStack.Count != 0)
            {
                if(operatorStack.Count != 0)
                {
                    ETree.Add((TreeNode<string>)operatorStack.Pop());
                    ETree.Add((TreeNode<string>)numberStack.Pop());
                }
            }
        }
    }
}
            //foreach (string item in expressions)
            //{
            //    int tempInt;
            //    if (Int32.TryParse(item, out tempInt))
            //    {
            //        TreeNode<string> number_node = new TreeNode<string>(tempInt.ToString());
            //        stack.Push(number_node);
            //    }
            //    else
            //    {
            //        TreeNode<string> operator_node = new TreeNode<string>(item);
            //        if (operator_node.left == null && stack.Count != 0)
            //        {
            //            operator_node.left = (TreeNode<string>)stack.Pop();
            //        }
            //        if (operator_node.right == null & stack.Count != 0)
            //        {
            //            operator_node.right = (TreeNode<string>)stack.Pop();
            //        }
            //        stack.Push(operator_node);
            //    }
            //}
            //ETree.root = (TreeNode<string>)stack.Pop();
//        }
//    }
//}