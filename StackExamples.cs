/*
    A Stack is used to represent a last-in, first out collection of objects.
    It's used when you need last-in, first-out (LIFO) acces to items.

    To add elements: Push()
    To remove all elements: Clear()
    To return and remove the first element (last-in): Pop()
    To return and not remove the first element (last-in): Peek();
*/

using System;
using System.Collections;

namespace DataStructure
{
    public static class StackExamples
    {
        public static void Run()
        {
            var myStack = new Stack();


            myStack.Push("Geeks");
            myStack.Push("geeksforgeeks");
            myStack.Push('G');
            myStack.Push(null);
            myStack.Push(12345);
            myStack.Push(490.98);


            foreach(var item in myStack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine($"Has geeksforgeeks? {myStack.Contains("geeksforgeeks")}");

            Console.WriteLine();

            Console.WriteLine($"Total elements present in myStack: {myStack.Count}");

            myStack.Pop();

            Console.WriteLine($"Total elements present in myStack: {myStack.Count}");

            myStack.Clear();

            Console.WriteLine($"Total elements present in myStack: {myStack.Count}");

        }
    }
}