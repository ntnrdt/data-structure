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

        public TreeNode(int key, TreeNode left, TreeNode right)
        {
            Key = key;
            Left = left;
            Right = right;
        }
    }
}