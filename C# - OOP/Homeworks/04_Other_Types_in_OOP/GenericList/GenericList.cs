
namespace GenericList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Version(1, 0)]
    public class GenericList<T>
        where T : IComparable<T>
    {
        // define fields
        private const uint DEFAULT_SIZE = 16;

        private T[] elements;
        private uint count = 0;

        // define a constructor 
        public GenericList(uint capacity = DEFAULT_SIZE)
        {
            if (capacity == 0)
            {
                throw new ArgumentOutOfRangeException("GenericList can not have a zero capacity!");
            }

            this.elements = new T[capacity];
        }

        // define indexer property for accessing ellement by index
        public T this[uint index]
        {
            get
            {
                // check if the index is within the boundaries of our current list
                if (index >= this.count)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid Index: {0}", index));
                }

                T value = elements[index];
                return value;
            }
        }

        // define a method for adding elements to the GenericList
        public void AddElement(T element)
        {
            if (this.count >= this.elements.Length)
            {
                this.ResizeArray();
            }

            this.elements[this.count] = element;
            this.count++;
        }

        // define a method for removing an element by index
        public void RemoveAtIndex(uint position)
        {
            if (position >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid Index: {0}", position));
            }

            // remove the element at the posiotion by moving all elements after it with one position back
            for (uint i = position; i < this.count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            // reduce the counter so that our new list have a proper lenngth and reset the value of the last element
            this.count--;
            this.elements[count] = default(T);
        }

        // define a method for inserting an element at given position
        public void InsertAtIndex(uint position, T insert)
        {
            if (position >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid Index: {0}", position));
            }

            // resize the array if it's already full 
            if (this.count == this.elements.Length)
            {
                this.ResizeArray();
            }

            //  move all elements in the array one postiont forth, ncrease the counter,
            // and set the requested index with the requested value
            for (uint i = count; i > position; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.count++;
            this.elements[position] = insert;
        }

        // define a method for clearing the list
        public void ClearList()
        {
            this.elements = new T[this.elements.Length];
            this.count = 0;
        }

        // define a method to find element index by given value
        public int IndexOf(T value)
        {
            int indexOf = -1;
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].Equals(value))
                {
                    indexOf = i;
                    break;
                }
            }

            return indexOf;
        }

        // define a method to check if the list contains an element with certain value;
        public bool Contains(T value)
        {
            return this.IndexOf(value) == -1 ? false : true;
        }

        // override the ToString() method to print the list at the console
        public override string ToString()
        {
            if (this.count == 0)
            {
                return "The GenreicList is empty";
            }

            StringBuilder list = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                list.AppendLine(String.Format("Item {0}: {1}", i, this.elements[i]));
            }

            return list.ToString();
        }

        // define a generic method for finding the minimal element in the GenericList
        public T Max()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The GenericList is empty");
            }

            T maxValue = this.elements[0];
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(maxValue) > 0)
                {
                    maxValue = this.elements[i];
                }
            }

            return maxValue;
        }

        // define a generic method for finding the maximal element in the GenericList
        public T Min()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The GenericList is empty");
            }

            T minValue = this.elements[0];
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(minValue) < 0)
                {
                    minValue = this.elements[i];
                }
            }

            return minValue;
        }

        // a private method for resizing the list when the internal array is full;
        private void ResizeArray()
        {
            T[] resizedArrray = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                resizedArrray[i] = this.elements[i];
            }

            this.elements = resizedArrray;
        }
    }
}

