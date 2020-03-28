using System;

namespace DataStructure
{
    public static class DepthFirstSearchExample
    {
        public static void Run()
        {
            var node = SampleTree();
            Print(node);
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
            if (node == null)
            return;

            Console.WriteLine($"{node.Key} ");
            Print(node.Left);
            Print(node.Right);
        }
    }
}