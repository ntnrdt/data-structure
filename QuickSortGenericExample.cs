using System;

namespace DataStructure
{
    public static class QuickSortGenericExample
    {
        public static void Run()
        {
            var numbers = new[] { 1, 2, 5, 0, 34, 3, 9 };
            var letters = new[] { 'f','w','x','n','t','v','c','z','y','d','m','u','a','o','l','q','b','j','i','e','r','g','h','p','k','s' };
            var names = new[] { "Peter", "Alex", "John", "Fred" };

            Console.WriteLine("Pre Order Numbers: ");
            foreach (var item in numbers)
                Console.Write($"{item} ");

            Console.WriteLine();
            SortArray(numbers);

            Console.WriteLine("Post Order Numbers: ");
            foreach (var item in numbers)
                Console.Write($"{item} ");

            Console.WriteLine();

            /*---------------------------------------*/

            Console.WriteLine("Pre Order Letters: ");
            foreach (var item in letters)
                Console.Write($"{item} ");

            Console.WriteLine();
            SortArray(letters);

            Console.WriteLine("Post Order Letters: ");
            foreach (var item in letters)
                Console.Write($"{item} ");

            Console.WriteLine();

            /*---------------------------------------*/

            Console.WriteLine("Pre Order Names: ");
            foreach (var item in names)
                Console.Write($"{item} ");

            Console.WriteLine();
            SortArray(names);

            Console.WriteLine("Post Order Names: ");
            foreach (var item in names)
                Console.Write($"{item} ");
        }

        public static void SortArray<T>(T[] array)
        where T : IComparable<T>
        {
            SortArray(array, 0, array.Length - 1);
        }

        public static void SortArray<T>(T[] array, int left, int right)
         where T : IComparable<T>
        {
            var i = left;
            var j = right;
            var mid = (left + right) / 2;
            var pivot = array[mid];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                    i++;

                while (array[j].CompareTo(pivot) > 0)
                    j--;

                if (i <= j)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }

            }

            if (left < j)
                SortArray(array, left, j);

            if (i < right)
                SortArray(array, i, right);

        }
    }
}