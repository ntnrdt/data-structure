using System;

namespace binary_tree
{
    public static class BinarySearch
    {
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

        private static int LinearSearch(int[] array, int item)
        {
            var left = 0;
            var right = array.Length;

            for (var i = 0; i < array.Length; i++)
            {
                var middle = (left + right) / 2;

                if (array[middle] == item)
                    return middle;

                if (item < array[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }

        private static int BinarySearchMethod(int[] array, int item)
        {
            var left = 0;
            var right = array.Length;

            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (array[middle] == item)
                    return middle;

                if (item < array[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }

        private static int BinarySearchRecursiveMethod(int[] array, int item)
        {
            return BinarySearchRecursiveMethod(array, item, 0, array.Length);
        }

        private static int BinarySearchRecursiveMethod(int[] array, int item, int left, int right)
        {
            if (right >= left)
            {
                var middle = (left + right) / 2;

                if (array[middle] == item)
                    return middle;

                if (item < array[middle])
                    return BinarySearchRecursiveMethod(array, item, left, middle - 1);

                return BinarySearchRecursiveMethod(array, item, middle + 1, right);
            }

            return -1;
        }
    }
}