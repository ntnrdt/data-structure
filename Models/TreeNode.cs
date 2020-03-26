namespace DataStructure
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Key { get; set; }

        public TreeNode(int key)
        {
            Key = key;
            Left = Right = null;
        }
    }
}