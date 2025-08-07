using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class CustomStack<T>
    {
        private T[] array;   // This holds the actual stack items
        private int top;     // Index of the topmost item in the stack

        // Constructor - sets up the starting size of the stack
        public CustomStack()
        {
            array = new T[5];  // Start with room for 5 items
            top = -1;          // Stack is empty initially
        }

        // Push adds a new item on top of the stack
        public void Push(T item)
        {
            top++;  // Move up the top index

            if (top < array.Length)
            {
                array[top] = item;  // Put the item at the new top position
            }
            else
            {
                top--;     // Move back since we need to resize first
                Resize();  // Make the array bigger
                Push(item); // Try adding again
            }
        }

        // Pop removes and returns the top item from the stack
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            else
            {
                T item = array[top]; // Get the top item
                top--;               // Move the top index down
                return item;         // Return the removed item
            }

        }

        // Peek lets you see the top item without removing it
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return array[top];
        }

        // Check if the stack is empty
        public bool IsEmpty()
        {
            return top == -1;
        }

        // Returns the number of items in the stack
        public int Count
        {
            get { return top + 1; }
        }

        // Doubles the array size when the stack is full
        private void Resize()
        {
            T[] newArray = new T[array.Length * 2];  // New bigger array

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];              // Copy old items into the new one
            }

            array = newArray;  // Replace the old array
        }

        // Optional: Get the current stack as an array (top to bottom)
        public T[] GetStack()
        {
            T[] temp = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                temp[i] = array[i];
            }
            return temp;
        }
    }
}