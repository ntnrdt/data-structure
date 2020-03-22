public class Node
{
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Key { get; set; }

    public Node(int key)
    {
        Key = key;
        Left = Right = null;
    }
}