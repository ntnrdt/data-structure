using System;

namespace DataStructure
{
    public static class BinarySearchTreeExample
    {
        public static TreeNode Root { get; set; }

        public static void Run()
        {
            Add(15);
            Add(2);
            Add(7);
            Add(3);
            Add(10);
            Add(5);
            Add(8);

            TreeNode node = Find(5);
            int depth = GetTreeDepth();

            Console.WriteLine("PreOrder Traversal:");
            TraversePreOrder(Root);
            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:");
            TraverseInOrder(Root);
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:");
            TransversePostOrder(Root);
            Console.WriteLine();

            Remove(7);
            Remove(8);

            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            TraversePreOrder(Root);
            Console.WriteLine();

            Console.ReadLine();
        }

        /// <summary>
        /// Reciving a value, set the root or the children nodes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Add(int value)
        {
            // Before starts with the Root Node and later will be the PARENT Node.
            TreeNode before = null;

            // Initially is the Root and then navigates until the correct Node.
            TreeNode after = Root;

            // Navigates through the Nodes until sets the variable after with the correct New Node (null Node)
            while (after != null)
            {
                // Before any changes, set the variable before with the parent Node.
                before = after;

                if (value < after.Key) // If value is less than the parent node value, it's a left node
                    after = after.Left;
                else if (value > after.Key) // If the value is bigger than the parent node value, it's a right node
                    after = after.Right;
                else // Else is the same value
                    return false;
            }

            // New node to be set in the Root (IF IT'S THE FIRST CALL) or it will be set in the Left or Right node from parent.
            TreeNode newNode = new TreeNode(value);

            if (Root == null) // If tree is empty (it will be when the function is called for the first time)
                Root = newNode;
            else
            {
                // If the input value is less thant the parent node value, set the new node to the left node on the parent node.
                if (value < before.Key)
                    before.Left = newNode;
                else // Else set to the right node
                    before.Right = newNode;
            }

            return true;
        }

        /// <summary>
        /// Find Node based on its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TreeNode Find(int value)
        {
            return Find(value, Root);
        }

        /// <summary>
        /// Recusively search for the node with the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static TreeNode Find(int value, TreeNode parent)
        {
            if (parent != null)
            {
                if (value == parent.Key)
                    return parent;
                if (value < parent.Key)
                    return Find(value, parent.Left);
                if (value > parent.Key)
                    return Find(value, parent.Right);
            }

            return null;
        }

        /// <summary>
        /// Remove Node based on its value
        /// </summary>
        /// <param name="value"></param>
        public static void Remove(int value)
        {
            // Starting from the root, it will navigate throu the nodes until find and delete the node with the value provided.
            Remove(Root, value);
        }

        /// <summary>
        /// Giving a Parent and Key(value), it will remove the Node with the respective value.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static TreeNode Remove(TreeNode parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Key)
                parent.Left = Remove(parent.Left, key);
            else if (key > parent.Key)
                parent.Right = Remove(parent.Right, key);
            else // if value is same as parent's value, then this is the node to be deleted
            {

                // Node with only one child or no child
                if (parent.Left == null)
                    return parent.Right;
                else if (parent.Right == null)
                    return parent.Left;

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                parent.Key = MinValue(parent.Right);

                // Delete the inorder successor
                parent.Right = Remove(parent.Right, parent.Key);
            }

            return parent;
        }

        /// <summary>
        /// Navigate through the Tree and return its length
        /// </summary>
        /// <returns></returns>
        public static int GetTreeDepth()
        {
            return GetTreeDepth(Root);
        }

        /// <summary>
        /// Recursively will return the length of the tree
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static int GetTreeDepth(TreeNode parent)
        {
            /* 
                The function GetTreeDepth will be called giving the Left and Right node, 
                with this, if one side of the tree has more children nodes than the other side, 
                it will keep being calle until there's no more children to be checked and then return
                the bigger side (left or right)
            */
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.Left), GetTreeDepth(parent.Right)) + 1;
        }

        /// <summary>
        /// Navigate through the nodes until find the first available LeftNode and return its value.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static int MinValue(TreeNode node)
        {
            var minv = node.Key;

            while (node.Left != null)
            {
                minv = node.Left.Key;
                node = node.Left;
            }

            return minv;
        }

        /// <summary>
        /// Root -> Left Node -> Right Node
        /// </summary>
        /// <param name="parent"></param>
        public static void TraversePreOrder(TreeNode parent)
        {
            if (parent != null)
            {
                Console.WriteLine($"{parent.Key} ");
                TraversePreOrder(parent.Left);
                TraversePreOrder(parent.Right);
            }
        }

        /// <summary>
        /// Left Node -> Root -> Right Node
        /// </summary>
        /// <param name="parent"></param>
        public static void TraverseInOrder(TreeNode parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.Left);
                Console.WriteLine($"{parent.Key} ");
                TraverseInOrder(parent.Right);
            }
        }

        /// <summary>
        /// Left Node -> Right Node -> Root
        /// </summary>
        /// <param name="parent"></param>
        public static void TransversePostOrder(TreeNode parent)
        {
            if (parent != null)
            {
                TransversePostOrder(parent.Left);
                TransversePostOrder(parent.Right);
                Console.WriteLine($"{parent.Key} ");
            }
        }
    }
}