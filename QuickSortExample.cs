using System;

namespace DataStructure
{
    public static class QuickSortExample
    {
        public static void Run()
        {
            var numbers = new[] { 1, 2, 5, 0, 34, 3, 9 };

            Console.WriteLine("Pre Order: ");
            foreach (var item in numbers)
                Console.Write(item);

            Console.WriteLine();
            SortArray(numbers);

            Console.WriteLine("Post Order: ");
            foreach (var item in numbers)
                Console.Write(item);
        }

        public static void SortArray(int[] numbers)
        {
            SortArray(numbers, 0, numbers.Length -1);
        }

        public static void SortArray(int[] numbers, int left, int right)
        {
            var i = left;
            var j = right;

            // get the mid of the array
            var mid = (left + right) / 2;
            // get the value in the middle of the array
            var pivot = numbers[mid];

            // left less or equal than right
            while (i <= j)
            {
                /* 
                    while the value of the array in the position[i] is less than the pivot, it's in the right place
                    if not, i have reached the pivot or its bigger than pivot and must be moved, so it goes to the next step that is to check the right side of the array.
                */
                while (numbers[i] < pivot)
                    i++;

                /*
                    while the value of the array in the position[j] is bigger than the pivot, it's in the right place
                    if not, j have reached the pivot or its less than pivot must be moved, so it goes to the next step that is the swap
                */
                while (numbers[j] > pivot)
                    j--;

                /*
                    if the left side is less than the right side, it should be.
                    swap values the left side with the right side
                */
                if (i <= j)
                {
                    /*
                        temp has value of 1
                        1 has value of 2
                        2 has value of 1 (temp)
                    */
                    var tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;

                    // move insideo of the array
                    i++;
                    j--;
                }
            }

            // if the left side is smaller than j, go sort the subsection of the array from left to j
            if (left < j)
                SortArray(numbers, left, j);

            // if the i is smaller than the right side, go sort the subsection of the array from i to right
            if (i < right)
                SortArray(numbers, i, right);
        }
    }
}