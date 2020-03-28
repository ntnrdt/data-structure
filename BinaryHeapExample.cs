using System;

namespace DataStructure
{
    public static class BinaryHeapExample
    {
        public static HeapNode Root;
        public static HeapNode Pointer;
        public static int Count;

        public static void Run()
        {
            var nodes = new HeapNode[7];

            for (var i = 0; i < nodes.Length; i++)
                nodes[i] = new HeapNode(new Random().Next(100));

            for (var i = 0; i < nodes.Length; i++)
                Add(nodes[i]);

            Print();

        }

        public static void Add(HeapNode node)
        {
            if (Root == null)
            {
                Root = node;
                Count++;
            }
            else
            {
                Pointer = Root;

                // Converts an integer into Its Binary Form
                var bitCount = Convert.ToString(Count + 1, 2);

                for (var i = 1; i < bitCount.Length; i++)
                {
                    if (bitCount[i] == '0')
                    {
                        if (Pointer.Left == null)
                        {
                            // Creates an empty node filled with the node going through
                            Pointer.Left = new HeapNode(Pointer);
                        }

                        Pointer = Pointer.Left;
                    }
                    else
                    {
                        if (Pointer.Right == null)
                        {
                            Pointer.Right = new HeapNode(Pointer);
                        }

                        Pointer = Pointer.Right;
                    }
                }

                Pointer.Key = node.Key;

                while (true)
                {
                    if (Pointer == Root)
                    {
                        break;
                    }

                    if (Pointer.Key < Pointer.Parent.Key)
                    {
                        // Switch data
                        int tempData = Pointer.Key;
                        Pointer.Key = Pointer.Parent.Key;
                        Pointer.Parent.Key = tempData;
                        Pointer = Pointer.Parent;
                    }
                    else
                    {
                        break;
                    }
                }

                Count++;
            }
        }

        public static int Remove()
        {
            var bitCount = Convert.ToString(Count, 2);
            var output = Root.Key;
            Pointer = Root;

            for (var i = 1; i < bitCount.Length; i++)
            {
                if (bitCount[i] == '0')
                {
                    Pointer = Pointer.Left;
                }
                else
                {
                    Pointer = Pointer.Right;
                }
            }

            // Set Root equal to last filled space in heap
            Root.Key = Pointer.Key;

            try
            {
                // Delete last filled space in heap
                if (Pointer.Parent.Left == Pointer)
                {
                    Pointer.Parent.Left = null;
                }
                else
                {
                    Pointer.Parent.Right = null;
                }

                Count--;

                // Percolate down new root
                Heapify();
            }
            catch
            {
                Root = null;
            }

            return Count;
        }

        public static void Heapify()
        {
            HeapNode compare;
            Pointer = Root;

            while (true)
            {
                // Check for null, indicatin the pointer has reached bottom of heap
                if (Pointer.Left == null)
                {
                    break;
                }

                if (Pointer.Right == null)
                {
                    compare = Pointer.Left;
                }
                else
                {
                    if (Pointer.Left.Key <= Pointer.Right.Key)
                    {
                        compare = Pointer.Left;
                    }
                    else
                    {
                        compare = Pointer.Right;
                    }
                }

                if (Pointer.Key > compare.Key)
                {
                    var tempData = Pointer.Key;
                    Pointer.Key = compare.Key;
                    compare.Key = tempData;
                    Pointer = compare;
                }
                else
                {
                    break;
                }
            }
        }

        public static void Print()
        {
            PrintRecursive(Root);
        }

        public static void PrintRecursive(HeapNode node)
        {
            if (node != null)
            {
                Console.WriteLine($"{node.Key}");
                PrintRecursive(node.Left);
                
                PrintRecursive(node.Right);
            }
        }
    }
}