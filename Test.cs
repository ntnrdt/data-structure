using System;

namespace DataStructure
{
    public static class Test
    {
        public static TestNode Root;

        public static void Run()
        {
            var numbers = new[] { 5, 687, 1, 8, 7, 5, 87, 9, 3, 877, 2, 478, 6, 756, 654, 5168, 735, 4681 };
            //Array.Sort(numbers);

            foreach (var item in numbers)
                Insert(item);

            PrintInOrderTraversal();
        }

        public static bool Insert(int key)
        {
            TestNode before = null;
            TestNode after = Root;

            while (after != null)
            {
                before = after;

                if (key < after.Key)
                    after = after.Left;
                else if (key > after.Key)
                    after = after.Right;
                else
                    return false;
            }

            var newNode = new TestNode(key);

            if (Root == null)
                Root = newNode;
            else
            {
                if (key < before.Key)
                    before.Left = newNode;
                else
                    before.Right = newNode;
            }

            return true;
        }

        public static void PrintInOrderTraversal()
        {
            PrintInOrderTraversal(Root);
        }

        public static void PrintInOrderTraversal(TestNode node)
        {
            if (node == null) return;

            PrintInOrderTraversal(node.Left);
            Console.WriteLine(node.Key);
            PrintInOrderTraversal(node.Right);
        }
    }


    public class TestNode
    {
        public int Key;
        public TestNode Left;
        public TestNode Right;

        public TestNode(int key)
        {
            Key = key;
        }
    }
}