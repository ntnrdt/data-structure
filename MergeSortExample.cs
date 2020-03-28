using System;

namespace DataStructure
{
    public static class MergeSortExample
    {
        public static void Run()
        {
            var array = new int[] { 10, 5, 2, 7, 4, 9, 12, 1, 8, 6, 11, 3 };

            MergeSort(array, 0, array.Length - 1);

            for (var i = 0; i < array.Length; i++)
                Console.Write($"{array[i]}{(i != array.Length - 1 ? ", " : "")}");
        }

        public static void MergeSort(int[] array, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            var middle = (leftStart + rightEnd) / 2;
            MergeSort(array, leftStart, middle);
            MergeSort(array, middle + 1, rightEnd);
            MergeHalves(array, leftStart, rightEnd);
        }

        public static void MergeHalves(int[] array, int leftStart, int rightEnd)
        {
            var leftEnd = (rightEnd + leftStart) / 2;
            var rightStart = leftEnd + 1;
            var size = rightEnd - leftStart + 1;
            var tempArray = new int[array.Length];

            var left = leftStart;
            var right = rightStart;
            var index = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (array[left] <= array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            Array.Copy(array, left, tempArray, index, leftEnd - left + 1);
            Array.Copy(array, right, tempArray, index, rightEnd - right + 1);
            Array.Copy(tempArray, leftStart, array, leftStart, size);
        }
    }
}