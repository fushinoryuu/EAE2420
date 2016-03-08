using System;
using System.Collections;

namespace Assignment5
{
    class ExpressionParser
    {
        private Stack stack;

        public ExpressionParser()
        {
            stack = new Stack();

            Parser();
        }

        public void Parser()
        {
            Console.Write("Enter an expression: ");
            string input = Console.ReadLine();

            string[] expressions = new string[input.Length];
            expressions = input.Split();

            BuildTree(expressions);
        }

        private void BuildTree(string[] expressions)
        {
            ExpressionTree tree = new ExpressionTree();

            foreach (string s in expressions)
            {
                int temp;
                if (Int32.TryParse(s, out temp))
                {
                    TreeNode<string> new_node = new TreeNode<string>(temp.ToString());

                }

                //int temp;
                //if(Int32.TryParse(s, out temp))
                //{
                //    Console.WriteLine("Its a Number");
                //    TreeNode<int> iNode = new TreeNode<int>(temp);
                //    stack.Push(iNode);
                //}
                //else
                //{
                //    Console.WriteLine("Not a Number");
                //    TreeNode<string> sNode = new TreeNode<string>(s);

                //    //More work needed here. 

                //    stack.Push(sNode);
                //}
            }
        }
    }
}