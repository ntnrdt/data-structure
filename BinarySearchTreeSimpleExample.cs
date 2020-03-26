using System;

namespace DataStructure
{
    public static class BinarySearchTreeSimpleExample
    {
        public static TreeNode Root;

        public static void Run()
        {

            /* Let us create following BST  
                   50  
                 /    \  
                30     70  
                / \   / \  
               20 40 60 80 
            */

            Insert(50);
            Insert(30);
            Insert(20);
            Insert(40);
            Insert(70);
            Insert(60);
            Insert(80);

            Console.WriteLine("Preorder traversal of the given tree");
            PreOrder();
            Console.WriteLine();

            Console.WriteLine("Inorder traversal of the given tree");
            InOrder();
            Console.WriteLine();

            Console.WriteLine("PostOrder traversal of the given tree");
            PostOrder();
            Console.WriteLine();

            Console.WriteLine("Delete 20");
            Delete(20);
            Console.WriteLine("Inorder traversal of the modified tree");
            InOrder();

            Console.WriteLine("\nDelete 30");
            Delete(30);
            Console.WriteLine("Inorder traversal of the modified tree");
            InOrder();

            Console.WriteLine("\nDelete 50");
            Delete(50);
            Console.WriteLine("Inorder traversal of the modified tree");
            InOrder();
        }

        /// <summary>
        /// Giving a key, it will add it to the Tree
        /// </summary>
        /// <param name="key"></param>
        public static void Insert(int key)
        {
            Root = InsertRecursive(Root, key);
        }

        /// <summary>
        /// Giving a key, it will add the key in the correct position.
        /// If key < node.key, goes to left node, else if key > node.key, goes to the right node.
        /// </summary>
        /// <param name="node">Current Node</param>
        /// <param name="key">Key to be added to new node</param>
        /// <returns></returns>
        public static TreeNode InsertRecursive(TreeNode node, int key)
        {
            // If the node is empty, creates node
            if (node == null)
            {
                node = new TreeNode(key);
                return node;
            }

            // If key < node.key, must add a new node on the left side
            if (key < node.Key)
            {
                node.Left = InsertRecursive(node.Left, key);
            }
            // Else if key > node.key, must add a new node on the right side
            else if (key > node.Key)
            {
                node.Right = InsertRecursive(node.Right, key);
            }

            // Return node
            return node;
        }

        /// <summary>
        /// Delete the node holding the giving key.
        /// </summary>
        /// <param name="key">Key of the node that must be deleted.</param>
        public static void Delete(int key)
        {
            Root = DeleteRecursive(Root, key);
        }

        /// <summary>
        /// Delete the node holding the giving key.
        /// </summary>
        /// <param name="node">Current Node.</param>
        /// <param name="key">Key of the node that must be deleted.</param>
        /// <returns></returns>
        public static TreeNode DeleteRecursive(TreeNode node, int key)
        {
            // If there's no node, return.
            if (node == null)
                return node;

            // If the key < node.key, must keep looking on the left side of the node.
            if (key < node.Key)
                node.Left = DeleteRecursive(node.Left, key);
            // Else if the key > node.key, must keep looking on the right side of the node.
            else if (key > node.Key)
                node.Right = DeleteRecursive(node.Right, key);
            // Else, the key is equal to node.key, then must to be deleted
            else
            {  
                /* By returning a Left or Right node, you'll be skiping the current node on the tree. */
                
                // If there's nothing on the left node, return the right node
                if (node.Left == null)
                    return node.Right;
                // Else if there's nothing on the right node, return the left node
                else if (node.Right == null)
                    return node.Left;
                // Else
                
                // Node with two children, get the inorder successor(smallest in the right subtree)
                node.Key = MinValue(node.Right);

                // Delete the indorder sucessor
                node.Right = DeleteRecursive(node.Right, node.Key);
            }

            return node;
        }

        /// <summary>
        /// Return the smalles value of the giving node tree.
        /// </summary>
        /// <param name="node">Current Node</param>
        /// <returns></returns>
        public static int MinValue(TreeNode node)
        {
            int minv = node.Key;

            // While there's a left node, navigates through it.
            while(node.Left != null)
            {
                minv = node.Left.Key;
                node = node.Left;
            }

            // return the smallest key
            return minv;
        }

        /// <summary>
        /// Pre order log
        /// </summary>
        public static void PreOrder()
        {
            PreOrderRecursive(Root);
        }

        /// <summary>
        /// Will print the pre order tree
        /// </summary>
        /// <param name="node"></param>
        public static void PreOrderRecursive(TreeNode node)
        {
            if (node != null)
            {
                Console.WriteLine($"{node.Key} ");
                PreOrderRecursive(node.Left);
                PreOrderRecursive(node.Right);
            }
        }

        /// <summary>
        /// In order log
        /// </summary>
        public static void InOrder()
        {
            InOrderRecursive(Root);
        }

        /// <summary>
        /// Will print the in order tree
        /// </summary>
        /// <param name="node"></param>
        public static void InOrderRecursive(TreeNode node)
        {
            if (node != null)
            {
                InOrderRecursive(node.Left);
                Console.WriteLine($"{node.Key} ");
                InOrderRecursive(node.Right);
            }
        }

        /// <summary>
        /// Post order tree
        /// </summary>
        public static void PostOrder()
        {
            PostOrderRecursive(Root);
        }

        /// <summary>
        /// Will print the post order tree
        /// </summary>
        /// <param name="node"></param>
        public static void PostOrderRecursive(TreeNode node)
        {
            if (node != null)
            {
                PostOrderRecursive(node.Left);
                PostOrderRecursive(node.Right);
                Console.WriteLine($"{node.Key} ");
            }
        }
    }
}