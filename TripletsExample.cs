using System;
using System.Collections.Generic;

namespace DataStructure
{
    public static class TripletesExample
    {
        public static void Run()
        {
            var numbers = new[] { -2 - 3 - 7, 0, 2, 3, 7, 8, 9, -8 };
            var tripletes = FindTriplets(numbers, numbers.Length);

            foreach(var triplete in tripletes)
            {
                Console.WriteLine($"{triplete[0]}, {triplete[1]}, {triplete[2]}");
            }
        }

        public static int[][] FindTriplets(int[] array, int n)
        {
            var founds = new List<int[]>();

            for (var i = 0; i < n - 2; i++)
            {
                for (var j = i + 1; j < n - 1; j++)
                {
                    for (var k = j + 1; k < n; k++)
                    {
                        if (array[i] + array[j] + array[k] == 0)
                        {
                            founds.Add(new int[] { array[i], array[j], array[k] });
                        }
                    }
                }
            }

            return founds.ToArray();
        }
    }
}