using System;

namespace binary_tree
{
    public class BinarySearchTree_02
    {
        Node Root;

        public BinarySearchTree_02()
        {
            Run();
        }

        public void Run()
        {

            /* Let us create following BST  
                   50  
                 /    \  
                30     70  
                / \   / \  
               20 40 60 80 
            */

            this.Insert(50);
            this.Insert(30);
            this.Insert(20);
            this.Insert(40);
            this.Insert(70);
            this.Insert(60);
            this.Insert(80);

            Console.WriteLine("Preorder traversal of the given tree");
            this.PreOrder();
            Console.WriteLine();

            Console.WriteLine("Inorder traversal of the given tree");
            this.InOrder();
            Console.WriteLine();

            Console.WriteLine("PostOrder traversal of the given tree");
            this.PostOrder();
            Console.WriteLine();

            Console.WriteLine("Delete 20");
            this.Delete(20);
            Console.WriteLine("Inorder traversal of the modified tree");
            this.InOrder();

            Console.WriteLine("\nDelete 30");
            this.Delete(30);
            Console.WriteLine("Inorder traversal of the modified tree");
            this.InOrder();

            Console.WriteLine("\nDelete 50");
            this.Delete(50);
            Console.WriteLine("Inorder traversal of the modified tree");
            this.InOrder();
        }

        /// <summary>
        /// Giving a key, it will add it to the Tree
        /// </summary>
        /// <param name="key"></param>
        public void Insert(int key)
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
        public Node InsertRecursive(Node node, int key)
        {
            // If the node is empty, creates node
            if (node == null)
            {
                node = new Node(key);
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
        public void Delete(int key)
        {
            Root = DeleteRecursive(Root, key);
        }

        /// <summary>
        /// Delete the node holding the giving key.
        /// </summary>
        /// <param name="node">Current Node.</param>
        /// <param name="key">Key of the node that must be deleted.</param>
        /// <returns></returns>
        public Node DeleteRecursive(Node node, int key)
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
        public int MinValue(Node node)
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
        public void PreOrder()
        {
            PreOrderRecursive(Root);
        }

        /// <summary>
        /// Will print the pre order tree
        /// </summary>
        /// <param name="node"></param>
        public void PreOrderRecursive(Node node)
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
        public void InOrder()
        {
            InOrderRecursive(Root);
        }

        /// <summary>
        /// Will print the in order tree
        /// </summary>
        /// <param name="node"></param>
        public void InOrderRecursive(Node node)
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
        public void PostOrder()
        {
            PostOrderRecursive(Root);
        }

        /// <summary>
        /// Will print the post order tree
        /// </summary>
        /// <param name="node"></param>
        public void PostOrderRecursive(Node node)
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