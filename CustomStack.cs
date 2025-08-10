using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    //==============================//
    //       CUSTOM STACK ADT       //
    //==============================//
    // Our own Stack for storing Undo operations.
    // Follows Last-In-First-Out (LIFO) behavior.
    public class CustomStack<T>
    {
        private T[] stack; // array to store stack elements
        private int top;   // index of the top element

        public CustomStack()
        {
            stack = new T[50];
            top = -1; // empty stack
        }

        // Push = put new item on top of stack
        public void Push(T item)
        {
            top++;
            stack[top] = item;
        }

        // Pop = remove and return top item
        public T Pop()
        {
            if (top == -1) return default(T); // if empty
            T item = stack[top];
            top--;
            return item;
        }

        // Check if stack is empty
        public bool IsEmpty()
        {
            return top == -1;
        }
    }
}
