using System;
using System.Collections.Generic;

namespace Assignment5
{
    class ExpressionTree
    {
        public TreeNode<string> root;

        public ExpressionTree()
        {
            root = null;
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
            PreHelper(list, root);
            return string.Join(", ", list);
        }

        private void PreHelper(List<string> list, TreeNode<string> node)
        {
            list.Add(node.Data);
            if (node.Left != null)
                PreHelper(list, node.Left);
            if (node.Right != null)
                PreHelper(list, node.Right);
        }

        public string TraverseIn()
        {
            List<string> list = new List<string>();
            InHelper(list, root);
            return string.Join(", ", list);
        }

        private void InHelper(List<string> list, TreeNode<string> node)
        {
            if (node.Left != null)
                InHelper(list, node.Left);
            list.Add(node.Data);
            if (node.Right != null)
                InHelper(list, node.Right);
        }

        public string TraversePost()
        {
            List<string> list = new List<string>();
            PostHelper(list, root);
            return string.Join(", ", list);
        }

        private void PostHelper(List<string> list, TreeNode<string> node)
        {
            if (node.Left != null)
                PostHelper(list, node.Left);
            if (node.Right != null)
                PostHelper(list, node.Right);
            list.Add(node.Data);
        }
    }
}