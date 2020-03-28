using System;
using System.Collections.Generic;

namespace DataStructure
{
    public static class BreadthFirstSearchExample
    {
        public static void Run()
        {
            var root = SampleTree();

            Print(root);
        }

        public static TreeNode SampleTree()
        {
            var root =
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(3), new TreeNode(4)),
                    new TreeNode(5,
                        new TreeNode(6), new TreeNode(7,
                                                    new TreeNode(8), null)));

            return root;
        }

        public static void Print(TreeNode node)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                node = q.Dequeue();

                Console.WriteLine($"{node.Key} ");

                if (node.Left != null)
                    q.Enqueue(node.Left);

                if (node.Right != null)
                    q.Enqueue(node.Right);
            }
        }
    }
}