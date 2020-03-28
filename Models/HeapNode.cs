namespace DataStructure
{
    public class HeapNode
    {
        public HeapNode Parent { get; set; }
        public HeapNode Left { get; set; }
        public HeapNode Right { get; set; }
        public int Key { get; set; }

        public HeapNode()
        {
        }

        public HeapNode(int key)
        {
            Key = key;
        }

        public HeapNode(HeapNode parent)
        {
            Parent = parent;
        }

        public HeapNode(int key, HeapNode parent)
        {
            Key = key;
            Parent = parent;
        }
    }
}