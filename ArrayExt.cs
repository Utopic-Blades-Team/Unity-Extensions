using System;

namespace UBTExtensions
{
    /*This class was made from ground up thinking on how *would* work the List class if it was just an group of functions.
     * As such, i did NOT look at the List class at any time prior to finishing this one, only parts that i
     * commented clearly stating were copied from the List class.
     * Also you can modify this as much as needed...
     * If you got any suggestion that could help, that is very much appreciated as i use this code myself*/
    public static class ArrayExt
    {
        #region Thread Unsafe
        public static void Add<T>(this T[] array, T item)
        {
            array ??= new T[0];

            if (array.Length == 0)
            {
                array = new T[1];
                array[0] = item;
            }
            else
            {
                T[] _ = array;

                array = new T[_.Length + 1];

                _.CopyTo(array, 0);

                array[^1] = item;
            }

            return;
        }

        public static void Remove<T>(this T[] array, int index)
        {
            if (array.Length <= index)
            {
                throw new IndexOutOfRangeException("Remove event index can NOT be greater or equal to the lenght of the target array");
            }

            T[] _ = array;

            int j = 0;

            foreach (int i in ..array.Length)
            {
                if (i == index)
                {
                    continue;
                }

                _[j] = array[i];
                j++;
            }

            return;
        }

        public static T Pop<T>(this T[] array, int index = 0)
        {
            if (array.Length <= index)
            {
                throw new IndexOutOfRangeException("Pop event index can NOT be greater or equal to the lenght of the target array");
            }

            T returnValue = default;

            T[] _ = array;

            int j = 0;

            foreach (int i in ..array.Length)
            {
                if (i == index)
                {
                    returnValue = array[i];
                    continue;
                }

                _[j] = array[i];
                j++;
            }

            return returnValue;
        }
        #endregion

        #region Thread Safe //will be added later!

        #endregion

        #region OBSOLETE
        //REALLY old ADD extension, replace with the new add, as it uses direct reference, making it cleaner!
        [Obsolete("Use .Add(item) instead as in \"target_array.Add(item)\" ")]
        public static T[] Add<T>(T item, ref T[] array)
        {
            T[] _array = array;

            array = new T[_array.Length + 1];

            _array.CopyTo(array, 0);

            array[^1] = item;

            return array;
        }

        //REALLY old Remove extension, replace with the new Remove or the Pop, as they use direct reference and may have return types, making it cleaner!
        [Obsolete("Use either .Remove(int index) as in \"target_array.Remove(index)\" OR .Pop(int index) instead")]
        public static T[] Remove<T>(int index, ref T[] array)
        {
            T[] _array = new T[array.Length - 1];

            int j = 0;

            foreach (int i in ..array.Length)
            {
                if (i == index)
                {
                    continue;
                }

                _array[j] = array[i];
                j++;
            }

            return array;
        }
        #endregion
    }
}