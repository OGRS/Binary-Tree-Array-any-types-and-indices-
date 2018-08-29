using System;
using System.Collections;

namespace Hrab_2.Classes
{
    /// <summary>
    /// Represents a store of any data in the form of an array with any initial index.
    /// </summary>
    public class One_DimensionalArray<T> : IEnumerable
    {
        private T[] values;                        //Stores data of any type
        public int initial_index { get; private set; }  //Initial index of One_DimensionalArray
        public int end_index { get; private set; }      //End index of One_DimensionalArray

        /// <summary>
        /// Shows the length of One_DimensionalArray
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="One_DimensionalArray"/> class
        /// with initial index and length
        /// </summary>
        /// <param name="startIndex"></param>
        public One_DimensionalArray(int initial_index, int Length)
        {
            this.initial_index = initial_index;
            this.Length = Length;
            end_index = initial_index + Length - 1;

            values = new T[Length];
        }

        private bool isIndexValid(int i) 
            => i >= initial_index && i <= end_index;

        public T this[int i]
        {
            get
            {
                if (isIndexValid(i))
                    return values[i - initial_index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (isIndexValid(i))
                    values[i - initial_index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var el in values)
            {
                if (el != null)
                    yield return el;
            }   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
