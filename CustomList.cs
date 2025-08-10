using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    //==============================//
    //        CUSTOM LIST ADT       //
    //==============================//
    // This is our own version of a list (array) that can store any type of data.
    // It works like List<T> in C#, but we made it ourselves for learning purposes.

    public class CustomList<T>
    {
        private T[] array; // array to store elements
        private int index; // how many items are currently stored

        public CustomList()
        {
            array = new T[50]; // fixed capacity of 50 for simplicity
            index = -1;
        }

        // Adds a new item to the list
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
                Resize(); // resize the array if it is full
                Add(item); // add the item again after resizing
            }


        }

        private void Resize()
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        // Removes an item from a specific position
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.index - 1; i++)
            {
                array[i] = array[i + 1];
            }
            this.index--;
        }

        // Gets an item from the list
        public T Get(int index) { return array[index]; }

        // Returns the number of items
        public int Count()
        {
            return index + 1;
        }

    }
}

