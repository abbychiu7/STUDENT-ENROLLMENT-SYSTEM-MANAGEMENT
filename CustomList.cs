using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class CustomList<T>
    {
        private T[] array;
        private int index;

        public CustomList()
        {
            array = new T[10];
            index = -1;
        }

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

        public void RemoveAt()
        {
            if (index > -1 && index <= this.index)
            {
                for (int i = index; i < this.index; i++)
                {
                    {
                        array[i] = array[i + 1];
                    }
                }
                this.index--;
            }
        }
        
        private void Resize()
        {
            T[] newArr = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArr[i] = array[i];
            }
            array = newArr;
        }

        public void PrintList()
        {
            Console.WriteLine("List contents:");
            for (int i = 0; i <= index; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        // Optional: return current count of items
        public int Count()
        {
            return index + 1;
        }

        // Optional: check if empty
        public bool IsEmpty()
        {
            return index == -1;
        }

        // Optional: access by index
        public T Get(int position)
        {
            if (position < 0 || position > index)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            return array[position];
        }
    }
}
