namespace DataStructure
{
    public class TrieNode
    {
        public static readonly int ALPHABET_SIZE = 26;
        public TrieNode[] children = new TrieNode[26];
        public bool isEndOfWord;

        public TrieNode()
        {
            isEndOfWord = false;

            for (var i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    }
}