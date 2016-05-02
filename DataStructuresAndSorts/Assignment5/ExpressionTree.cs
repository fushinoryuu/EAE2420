using System;
using System.Collections.Generic;

namespace Assignment5
{
    class ExpressionTree
    {
        public TreeNode<string> Root;

        public ExpressionTree()
        {
            Root = null;
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

        public string TraversePre()
        {
            List<string> list = new List<string>();
            PreHelper(list, Root);
            return string.Join(", ", list);
        }

        private void PreHelper(List<string> list, TreeNode<string> Current_node)
        {
            list.Add(Current_node.Data);
            if (Current_node.Left != null)
                PreHelper(list, Current_node.Left);
            if (Current_node.Right != null)
                PreHelper(list, Current_node.Right);
        }

        public string TraverseIn()
        {
            List<string> list = new List<string>();
            InHelper(list, Root);
            return string.Join(", ", list);
        }

        private void InHelper(List<string> list, TreeNode<string> current_node)
        {
            if (current_node.Left != null)
                InHelper(list, current_node.Left);
            list.Add(current_node.Data);
            if (current_node.Right != null)
                InHelper(list, current_node.Right);
        }

        public string TraversePost()
        {
            List<string> list = new List<string>();
            PostHelper(list, Root);
            return string.Join(", ", list);
        }

        private void PostHelper(List<string> list, TreeNode<string> current_node)
        {
            if (current_node.Left != null)
                PostHelper(list, current_node.Left);
            if (current_node.Right != null)
                PostHelper(list, current_node.Right);
            list.Add(current_node.Data);
        }
    }
}