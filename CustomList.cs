using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] array;
        private int index;

        public CustomList()
        {
            array = new T[5];
            index = -1;
        }

        // Add an item to the list
        public void Add(T item)
        {
            index++;

            if (index < array.Length)
            {
                array[index] = item;
            }
            else
            {
                index--;
                Resize();
                Add(item);
            }
        }

        // Get number of items in the list
        public int Count => index + 1;

        // Get item at specific index
        public T GetAt(int i)
        {
            if (i >= 0 && i <= index)
                return array[i];
            else
                throw new IndexOutOfRangeException("Index is out of bounds.");
        }

        // Resize internal array when full
        private void Resize()
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        // Return a shallow copy array of current items
        public T[] GetArray()
        {
            T[] tempArr = new T[index + 1];
            for (int i = 0; i <= index; i++)
            {
                tempArr[i] = array[i];
            }
            return tempArr;
        }

        // Find an item that matches a given condition
        public T Find(Predicate<T> match)
        {
            for (int i = 0; i <= index; i++)
            {
                if (match(array[i]))
                    return array[i];
            }
            return default(T); // null for classes, zero/default for value types
        }

        // Remove the first occurrence of an item
        public bool Remove(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i <= index; i++)
            {
                if (comparer.Equals(array[i], item))
                {
                    // Shift everything left
                    for (int j = i; j < index; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    array[index] = default(T);
                    index--;
                    return true;
                }
            }

            return false;
        }

        // Make it usable in foreach loops
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= index; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

