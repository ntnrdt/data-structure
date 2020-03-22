using System;

namespace binary_tree
{
    public static class BinarySearch
    {
        /// <summary>
        /// Run Binary Search
        /// </summary>
        public static void Run()
        {
            var numbers = new int[] { 321, 53, 2342, 2, 52, 34, 36, 45, 61, 723, 57, 4, 72, 45, 7, 42, 24, 76, 97 };

            Array.Sort(numbers);
            Console.WriteLine();
            Console.WriteLine($"Numbers: {string.Join(',', numbers)}");

            var myIndex = BinarySearchRecursiveMethod(numbers, 61);
            Console.WriteLine();
            Console.WriteLine($"My index numbers is: {myIndex}");
        }

        /// <summary>
        /// Giving an (ordered or not) array, it will search from start to end where the giving key is a match.
        /// 
        /// </summary>
        /// <param name="array">Number array</param>
        /// <param name="key">Key to be found</param>
        /// <returns></returns>
        private static int LinearSearch(int[] array, int key)
        {
            var left = 0;
            var right = array.Length;

            // It will run from start to end looking for a match of the key
            for (var i = 0; i < array.Length; i++)
            {
                // get the average (a + b) / 2
                var middle = (left + right) / 2;

                if (array[middle] == key)
                    return middle;

                if (key < array[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }

        /// <summary>
        /// Giving an (ordered or not) array, it will use the average of the searching area 
        /// to get close to the giving key in the array.
        /// </summary>
        /// <param name="array">Number array.</param>
        /// <param name="key">Key to be found.</param>
        /// <returns></returns>
        private static int BinarySearchMethod(int[] array, int key)
        {
            var left = 0;
            var right = array.Length;

            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (array[middle] == key)
                    return middle;

                if (key < array[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }

        /// <summary>
        /// Recursively it will search for the giving key on the number array.
        /// </summary>
        /// <param name="array">Number array.</param>
        /// <param name="item">Key to be found.</param>
        /// <returns></returns>
        private static int BinarySearchRecursiveMethod(int[] array, int item)
        {
            return BinarySearchRecursiveMethod(array, item, 0, array.Length);
        }

        /// <summary>
        /// Recursively it will search for the giving key on the number array.
        /// </summary>
        /// <param name="array">Number array.</param>
        /// <param name="key">Key to be found.</param>
        /// <param name="left">Let node key.</param>
        /// <param name="right">Right node key.</param>
        /// <returns></returns>
        private static int BinarySearchRecursiveMethod(int[] array, int key, int left, int right)
        {
            // If the right key is bigger or equal to the left key (i.e: R: 5 and L: 3)
            if (right >= left)
            {
                // get the average (i.e.: (R: 5 + L:3) / 2 = 4).
                var middle = (left + right) / 2;

                // i.e: If the array[4] == key return the value on the array[4]
                if (array[middle] == key)
                    return middle;

                // if key < array[middle], keep searching on the left side of the array
                if (key < array[middle])
                    return BinarySearchRecursiveMethod(array, key, left, middle - 1);

                // else keep searching on the right side of the array
                return BinarySearchRecursiveMethod(array, key, middle + 1, right);
            }

            return -1;
        }
    }
}