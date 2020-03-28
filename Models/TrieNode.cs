namespace DataStructure
{
    public class TrieNode
    {
        public static readonly int ALPHABET_SIZE = 26;
        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];
        public bool isEndOfWord;
    }
}