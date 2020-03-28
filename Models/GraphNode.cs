using System.Collections.Generic;

namespace DataStructure{
    public class GraphNode
    {
        public char Value;
        public List<char> Edges = new List<char>();

        public GraphNode(char value)
        {
            this.Value = value;
        }
    }
}