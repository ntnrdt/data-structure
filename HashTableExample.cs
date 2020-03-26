/*
    A Hashtable is a collection of key/value pairs that are arranged based on the hash code of the key.
    Or in other words, a Hashtable is used to create a collection which uses a hash table for storage.
*/

using System;
using System.Collections;

namespace DataStructure
{
    public static class HashTableExample
    {

        public static void Run()
        {
            var hashTable = new Hashtable();
            hashTable.Add("A1", "Welcome");
            hashTable.Add("A2", "to");
            hashTable.Add("A3", "Geeks for Geeks");

            Console.WriteLine("Key and Value pairs from hashTable:");

            foreach(DictionaryEntry item in hashTable)
            {
                Console.WriteLine($"{item.Key} and {item.Value}");
            }

            hashTable.Clear();

            Console.WriteLine("Key and Value pairs from hashTable after clear:");

            foreach(DictionaryEntry item in hashTable)
            {
                Console.WriteLine($"{item.Key} and {item.Value}");
            }

            Console.WriteLine();

            hashTable = new Hashtable()
            {
                {1, "hello"},
                {2, 234},
                {3, 230.45},
                {4, null}
            };

            Console.WriteLine("Key and Value pairs from hashTable after inline initialization:");

            foreach(DictionaryEntry item in hashTable)
            {
                Console.WriteLine($"{item.Key} and {item.Value}");
            }

            Console.WriteLine($"Has key 1? {hashTable.ContainsKey(1)}");
            Console.WriteLine($"Has value hello? {hashTable.ContainsValue("hello")}");
            Console.WriteLine($"Has any 23? {hashTable.Contains(23)}");
        }
    }
}