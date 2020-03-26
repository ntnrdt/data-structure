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
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            // mark last node as leaf
            pCrawl.isEndOfWord = true;
        }

        /// <summary>
        /// Returns true if key presents in trie, else false.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Search(string key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl != null && pCrawl.isEndOfWord);
        }
    }
}