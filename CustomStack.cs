using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class CustomStack<T>
    {
        private T[] array;  // Stack storage
        private int top;    // Points to the topmost item

        public CustomStack()
        {
            array = new T[10];
            top = -1;  // Stack is empty
        }

        // Push item to the top of the stack
        public void Push(T item)
        {
            if (top < array.Length - 1)
            {
                top++;
                array[top] = item;
            }
            else
            {
                Resize();
                Push(item);  // Retry after resizing
            }
        }

        // Pop (remove and return) the top item
        public T Pop()
        {
            if (!IsEmpty())
            {
                T item = array[top];
                top--;
                return item;
            }

            throw new InvalidOperationException("Stack is empty.");
        }

        // Peek (return but don't remove) the top item
        public T Peek()
        {
            if (!IsEmpty())
            {
                return array[top];
            }

            throw new InvalidOperationException("Stack is empty.");
        }

        // Check if the stack is empty
        public bool IsEmpty()
        {
            return top == -1;
        }

        // Resize the array when full
        private void Resize()
        {
            T[] newArray = new T[array.Length * 2];

            for (int i = 0; i <= top; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        // Optional: print stack contents (top to bottom)
        public void PrintStack()
        {
            Console.WriteLine("Stack contents (top to bottom):");

            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }

        // Optional: get the number of items
        public int Count()
        {
            return top + 1;
        }
    }
}
