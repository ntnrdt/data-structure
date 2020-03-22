/*
 * Tree Traversals (PreOrder, InOrder, postOrder)
 * Traversal is a process to visit all the nodes of a tree. In this example, I
 * implemented three method which we use to traverse a tree.

    PreOder Traversal:
        * Visit the root
        * Traverse the left subtree
        * Traverse the right subtree

    InOrder Traversal:
        * Traverse the left subtree
        * Visit the root
        * Traverse the right subtree

    PostOrder Traversal:
        * Traverse the left subtree
        * Traverse the right subtree
        * Visit the root
 */

using System;

namespace binary_tree
{
    public class BinarySearchTree
    {
        public Node Root { get; set; }

        public BinarySearchTree()
        {
            Run();
        }

        public void Run()
        {
            this.Add(15);
            this.Add(2);
            this.Add(7);
            this.Add(3);
            this.Add(10);
            this.Add(5);
            this.Add(8);

            Node node = this.Find(5);
            int depth = this.GetTreeDepth();

            Console.WriteLine("PreOrder Traversal:");
            this.TraversePreOrder(this.Root);
            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:");
            this.TraverseInOrder(this.Root);
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:");
            this.TransversePostOrder(this.Root);
            Console.WriteLine();

            this.Remove(7);
            this.Remove(8);

            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            this.TraversePreOrder(this.Root);
            Console.WriteLine();

            Console.ReadLine();
        }

        /// <summary>
        /// Reciving a value, set the root or the children nodes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(int value)
        {
            // Before starts with the Root Node and later will be the PARENT Node.
            Node before = null;

            // Initially is the Root and then navigates until the correct Node.
            Node after = this.Root;

            // Navigates through the Nodes until sets the variable after with the correct New Node (null Node)
            while (after != null)
            {
                // Before any changes, set the variable before with the parent Node.
                before = after;

                if (value < after.Data) // If value is less than the parent node value, it's a left node
                    after = after.LeftNode;
                else if (value > after.Data) // If the value is bigger than the parent node value, it's a right node
                    after = after.RightNode;
                else // Else is the same value
                    return false;
            }

            // New node to be set in the Root (IF IT'S THE FIRST CALL) or it will be set in the Left or Right node from parent.
            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null) // If tree is empty (it will be when the function is called for the first time)
                this.Root = newNode;
            else
            {
                // If the input value is less thant the parent node value, set the new node to the left node on the parent node.
                if (value < before.Data)
                    before.LeftNode = newNode;
                else // Else set to the right node
                    before.RightNode = newNode;
            }

            return true;
        }

        /// <summary>
        /// Find Node based on its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }

        /// <summary>
        /// Remove Node based on its value
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            // Starting from the root, it will navigate throu the nodes until find and delete the node with the value provided.
            Remove(this.Root, value);
        }

        /// <summary>
        /// Giving a Parent and Key(value), it will remove the Node with the respective value.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data)
                parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);
            else // if value is same as parent's value, then this is the node to be deleted
            {

                // Node with only one child or no child
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        /// <summary>
        /// Navigate through the nodes until find the first available LeftNode and return its value.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int MinValue(Node node)
        {
            var minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        /// <summary>
        /// Recusively search for the node with the provided <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data)
                    return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                if (value > parent.Data)
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        /// <summary>
        /// Navigate through the Tree and return its length
        /// </summary>
        /// <returns></returns>
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        /// <summary>
        /// Recursively will return the length of the tree
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public int GetTreeDepth(Node parent)
        {
            /* 
                The function GetTreeDepth will be called giving the Left and Right node, 
                with this, if one side of the tree has more children nodes than the other side, 
                it will keep being calle until there's no more children to be checked and then return
                the bigger side (left or right)
            */
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        /// <summary>
        /// Root -> Left Node -> Right Node
        /// </summary>
        /// <param name="parent"></param>
        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.WriteLine($"{parent.Data} ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        /// <summary>
        /// Left Node -> Root -> Right Node
        /// </summary>
        /// <param name="parent"></param>
        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.WriteLine($"{parent.Data} ");
                TraverseInOrder(parent.RightNode);
            }
        }

        /// <summary>
        /// Left Node -> Right Node -> Root
        /// </summary>
        /// <param name="parent"></param>
        public void TransversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TransversePostOrder(parent.LeftNode);
                TransversePostOrder(parent.RightNode);
                Console.WriteLine($"{parent.Data} ");
            }
        }
    }

    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }
}