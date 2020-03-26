using System;

namespace DataStructure
{
    public static class TriExample
    {
        public static TrieNode root;

        public static void Run()
        {
            var keys = new string[]
            {
                "the",
                "a",
                "there",
                "answer",
                "any",
                "by",
                "bye",
                "their"
            };

            var output = new string[]
            {
                "Not present in trie",
                "Present in trie"
            };

            root = new TrieNode();

            // Construct trie
            int i;
            for (i = 0; i < keys.Length; i++)
            {
                Insert(keys[i]);
            }

            // Search for different keys
            if (Search("the"))
                Console.WriteLine($"the --- {output[1]}");
            else
                Console.WriteLine($"the --- {output[0]}");

            if (Search("these"))
                Console.WriteLine($"these --- {output[1]}");
            else
                Console.WriteLine($"these --- {output[0]}");

            if (Search("thaw"))
                Console.WriteLine($"thaw --- {output[1]}");
            else
                Console.WriteLine($"thaw --- {output[0]}");
        }

        /// <summary>
        /// If not present, inserts key into trie
        /// If the key is prefix of trie node, just marks leaf node.
        /// </summary>
        /// <param name="key"></param>
        public static void Insert(string key)
        {
            var node = root;

            for (var level = 0; level < key.Length; level++)
            {
                var index = key[level] - 'a';

                if (node.children[index] == null)
                    node.children[index] = new TrieNode();

                node = node.children[index];
            }

            // mark last node as leaf
            node.isEndOfWord = true;
        }

        /// <summary>
        /// Returns true if key presents in trie, else false.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Search(string key)
        {
            var node = root;

            for (var level = 0; level < key.Length; level++)
            {
                var index = key[level] - 'a';

                if (node.children[index] == null)
                    return false;

                node = node.children[index];
            }

            return (node != null && node.isEndOfWord);
        }
    }
}