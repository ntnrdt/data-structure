/*
    A Queue is used to represent a first-in, first out (FIFO) collection of objects.
    It is used when you need first-in, first-out access of items.

    To add elements: Enqueue()
    To remove all elements: Clear()
    To return and remove the first element (first-in): Dequeue()
    To return and not remove the first element (first-in): Peek();

    PS: A List is also a FIFO.
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public static class QueueExample
    {
        public static void Run()
        {
            var myQueue = new Queue();

            myQueue.Enqueue("GFG");
            myQueue.Enqueue(1);
            myQueue.Enqueue(100);
            myQueue.Enqueue(null);
            myQueue.Enqueue(2.4);
            myQueue.Enqueue("Geeks123");

            foreach(var item in myQueue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine($"Has Geeks123? {myQueue.Contains("Geeks123")}");

            Console.WriteLine();

            Console.WriteLine($"Total elements present in myQueue: {myQueue.Count}");

            Console.WriteLine($"Topmost element of my queue: {myQueue.Dequeue()}");

            Console.WriteLine($"Total elements present in myQueue: {myQueue.Count}");

            Console.WriteLine($"Topmost element of myQueue: {myQueue.Peek()}");

            Console.WriteLine($"Total elements present in myQueue: {myQueue.Count}");


        }
    }
}