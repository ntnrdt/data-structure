/*
    A LinkedList is a linear data structure which stores element in the non-contiguous location.
    The elements in a liked list are linked with each other using pointers.
    Or in other words, LinkedList consists of nodes where each node contains a data field and a reference(link)
    to the next node in the list.
*/

using System;
using System.Collections.Generic;

namespace DataStructure
{
    public static class LinkedListExample
    {
        public static void Run()
        {
            // Creating a linkedlist
            // Using Linkedlist class
            LinkedList<string> mylist = new LinkedList<string>();

            mylist.AddLast("Zoya");
            mylist.AddLast("Shilpa");
            mylist.AddLast("Rohit");
            mylist.AddLast("Rohan");
            mylist.AddLast("Juhi");
            mylist.AddLast("Zoya");

            Console.WriteLine("Best students of XYZ univesity");

            foreach (string str in mylist)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Best students of XYZ university in 2000:");

            mylist.Remove(mylist.First);

            foreach (string str in mylist)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Best students of XYZ university in 2001:");

            mylist.Remove("Rohit");

            foreach (string str in mylist)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Best students of XYZ university in 2002:");

            mylist.RemoveFirst();

            foreach (string str in mylist)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Best students of XYZ university in 2003:");

            mylist.RemoveLast();

            foreach (string str in mylist)
            {
                Console.WriteLine(str);
            }

            mylist.Clear();

            Console.WriteLine($"Number of students: {mylist.Count}");
        }
    }
}