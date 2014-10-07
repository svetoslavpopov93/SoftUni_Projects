using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListOfT
{
    class GenericList<T> where T : IComparable<T>
    {
        private T[] list;
        private int currentElement = 0;

        public GenericList()
        {
            this.list = new T[16];
        }

        public GenericList(int length)
        {
            this.list = new T[length];
        }

        public void Add(T element)
        {
            if (currentElement == list.Length)
            {
                T[] newList = new T[list.Length * 2];

                for (int i = 0; i < list.Length; i++)
                {
                    newList[i] = list[i];
                }

                list = newList;
            }

            list[currentElement] = element;
            currentElement++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Length)
                {
                    throw new IndexOutOfRangeException("Index must be in range.");
                }
                else
                {
                    return this.list[index];
                }
            }
            set
            {
            }
        }

        public void Remove(int index)
        {
            if (index > currentElement)
            {
                throw new IndexOutOfRangeException("Index must be in the range of the current elements count.");
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index must be greater than ZERO.");
            }
            if (index > list.Length)
            {
                throw new IndexOutOfRangeException("Index must be in the range of the array's length.");
            }

            T[] arr = new T[this.list.Length];

            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (i != index)
                {
                    arr[j] = this.list[i];
                    j++;
                }
            }

            currentElement--;
            this.list = arr;
        }

        public void Instert(int index, T value)
        {
            if (index < 0 || index >= this.list.Length)
            {
                throw new IndexOutOfRangeException("Index value must be greater or equal to zero and lesser than the arrays length.");
            }

            this.list[index] = value;
        }

        public void Clear()
        {
            this.list = new T[this.list.Length];
            this.currentElement = 0;
        }

        public bool Contains(T value)
        {
            List<T> lst = new List<T>();
            lst = list.ToList();

            if (lst.IndexOf(value) != -1)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string output = "";
            int index = 0;

            foreach (var el in list)
            {
                if (el != null)
                {
                    output += index + "- " + el + "\r\n";
                }
                else
                {
                    output += index + "- null\r\n";
                }
                index++;
            }

            return output;
        }
    }
}
