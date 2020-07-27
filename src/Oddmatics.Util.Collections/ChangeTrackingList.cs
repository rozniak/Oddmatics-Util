/**
 * ChangeTrackingList.cs - Generic Change Tracking List
 * 
 * This source-code is part of the Oddmatics utility classes:
 * <<https://www.oddmatics.uk>>
 * 
 * Author(s): Rory Fewell <rory.fewell@oddmatics.uk>
 */

using Oddmatics.Util.System;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Oddmatics.Util.Collections
{
    /// <summary>
    /// Represents a change tracked collection of items.
    /// </summary>
    public class ChangeTrackingList<T> : ChangeTrackingEx,
                                         IList<T>
    {
        /// <inheritdoc />
        public int Count
        {
            get { return InternalList.Count; }
        }

        /// <inheritdoc />
        public bool IsReadOnly
        {
            get { return false; }
        }


        /// <summary>
        /// The internal <see cref="List{T}"/> that is wrapped by this class.
        /// </summary>
        protected List<T> InternalList { get; set; }


        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChangeTrackingList{T}"/> class.
        /// </summary>
        public ChangeTrackingList()
        {
            InternalList = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChangeTrackingList{T}"/> class that contains elements copied
        /// from the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements are copied to the new list.
        /// </param>
        public ChangeTrackingList(
            IEnumerable<T> collection
        )
        {
            InternalList = new List<T>(collection);
        }


        /// <inheritdoc />
        public T this[int index]
        {
            get { return InternalList[index]; }
            set
            {
                InternalList[index] = value;
                IsChanged           = true;
            }
        }


        /// <inheritdoc />
        public override void AcceptChanges()
        {
            IsChanged = false;
        }

        /// <inheritdoc />
        public void Add(
            T item
        )
        {
            InternalList.Add(item);
            IsChanged = true;
        }

        /// <inheritdoc />
        public void Clear()
        {
            if (InternalList.Count == 0)
            {
                return;
            }

            InternalList.Clear();
            IsChanged = true;
        }

        /// <inheritdoc />
        public bool Contains(
            T item
        )
        {
            return InternalList.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(
            T[] array,
            int arrayIndex
        )
        {
            Array.Copy(
                InternalList.ToArray(),
                0,
                array,
                arrayIndex,
                InternalList.Count
            );
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }

        /// <inheritdoc />
        public int IndexOf(
            T item
        )
        {
            return InternalList.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(
            int index,
            T item
        )
        {
            InternalList.Insert(index, item);
            IsChanged = true;
        }

        /// <inheritdoc />
        public bool Remove(
            T item
        )
        {
            bool res = InternalList.Remove(item);

            if (res)
            {
                IsChanged = true;
            }

            return res;
        }

        /// <inheritdoc />
        public void RemoveAt(
            int index
        )
        {
            InternalList.RemoveAt(index);
            IsChanged = true;
        }
    }
}
