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

            string[] expression = new string[input.Length];
            expression = input.Split();

            BuildTree(expression);
        }

        private void BuildTree(string[] expression)
        {
            foreach (string s in expression)
            {
                int temp;
                if(Int32.TryParse(s, out temp))
                {
                    Console.WriteLine("Its a Number");
                    TreeNode<int> iNode = new TreeNode<int>(temp);
                    stack.Push(iNode);
                }
                else
                {
                    Console.WriteLine("Not a Number");
                    TreeNode<string> sNode = new TreeNode<string>(s);

                    //More work needed here. 

                    stack.Push(sNode);
                }
            }
        }
    }
}
