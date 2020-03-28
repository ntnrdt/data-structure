using System;

namespace DataStructure
{
    public static class GraphExample
    {
        public static GraphNode[] Nodes;
        public static int Count;

        public static void Run()
        {
            Nodes = new GraphNode[7];
            Count = 0;

            AddNode('A');
            AddNode('B');
            AddNode('C');
            AddNode('D');
            AddNode('E');
            AddNode('F');
            AddNode('G');

            AddEdge('D', 'A');
            AddEdge('D', 'B');
            AddEdge('D', 'C');
            AddEdge('D', 'D');
            AddEdge('D', 'E');
            AddEdge('D', 'F');
            AddEdge('D', 'G');

            AddEdge('A', 'B');
            AddEdge('A', 'C');

            AddEdge('G', 'F');
            AddEdge('G', 'E');
            Print();
            Console.WriteLine("----------------------------------------");

            Swap('D', 'G');
            Print();

            Console.WriteLine($"Max: {FindMax()}");
            Console.WriteLine("----------------------------------------");

            Delete('D');
            Print();
            Console.WriteLine("----------------------------------------");

            AddNewNode('K');
            Print();

            Console.ReadKey();
        }

        public static void AddNode(char value)
        {
            Nodes[Count] = new GraphNode(value);
            Count++;
        }

        public static void AddEdge(char a, char b)
        {
            var aIndex = FindNode(a);
            var bIndex = FindNode(b);

            if (aIndex == -1 || bIndex == -1)
                Nodes[aIndex].Edges.Add(b);

            Nodes[bIndex].Edges.Add(a);
        }

        public static void Swap(char a, char b)
        {
            var aIndex = FindNode(a);
            var bIndex = FindNode(b);

            var temp = Nodes[aIndex];

            Nodes[aIndex] = Nodes[bIndex];
            Nodes[bIndex] = temp;
        }

        public static int FindNode(char c)
        {
            for (var i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i].Value == c)
                    return i;
            }

            return -1;
        }

        public static char FindMax()
        {
            var max = Nodes[0].Value;

            for (var i = 0; i <Nodes.Length; i++)
            {
                if (Nodes[i].Value > max)
                max = Nodes[i].Value;
            }

            return max;
        }

        public static void Delete(char a)
        {
            var charpos = FindNode(a);
            var temp = new GraphNode[Nodes.Length -1];

            for (var i = 0; i < Nodes.Length; i++)
            {
                if(i < charpos)
                temp[i] = Nodes[i];

                if (i > charpos)
                {
                    temp[i - 1] = Nodes[i];
                }
            }

            DeleteEdge(a);
            Nodes = temp;
            Count --;
        }

        public static void DeleteEdge(char c)
        {
            for (var i = 0; i < Nodes.Length; i++)
            {
                for(var j = 0; j < Nodes[i].Edges.Count; j++)
                {
                    if (Nodes[i].Edges[j] == c)
                    Nodes[i].Edges.Remove(c);
                }
            }
        }

        public static void AddNewNode(char c)
        {
            var temp = new GraphNode[Nodes.Length +1];

            for (var i=0; i < Nodes.Length; i++)
            {
                temp[i] = Nodes[i];
            }

            temp[Nodes.Length] = new GraphNode(c);
            Count ++;
            Nodes = temp;
        }

        public static void Print()
        {
            for (var i= 0; i < Nodes.Length; i++)
            {
                Console.Write($"({Nodes[i].Value})-");

                for(var j=0; j < Nodes[i].Edges.Count; j++)
                    Console.Write($"{Nodes[i].Edges[j]}");

                Console.WriteLine();
            }
        }
    }
}