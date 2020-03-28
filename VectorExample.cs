using System;
using System.Collections.Generic;

namespace DataStructure
{
    public static class VectorExample
    {
        public static void Run()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            for(var i = 0; i < list.Count; i ++)
            {
                Console.WriteLine($"List Item: {list[i]}");
            }

            Console.WriteLine($"Item: {list.Find(x=> x == 3)}");    
        }
    }
}