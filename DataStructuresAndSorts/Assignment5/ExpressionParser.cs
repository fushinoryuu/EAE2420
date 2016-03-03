using System;
using System.Collections;

namespace Assignment5
{
    class ExpressionParser
    {
        private Stack xStack;

        public ExpressionParser()
        {
            xStack = new Stack();

            Console.WriteLine("Enter an expression");
            string input = Console.ReadLine();

            Parser(input);
        }

        public void Parser(string input)
        {
            string[] expression = new string[input.Length];
            expression = input.Split();

            ToStack(expression);
        }

        private void ToStack(string[] expression)
        {
            foreach (string s in expression)
            {
                if(s is int)
                {
                    xStack.Push(s);
                }
                else
                {

                }
            }
        }
    }
}
