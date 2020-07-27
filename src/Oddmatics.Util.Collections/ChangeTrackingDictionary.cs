/**
 * ChangeTrackingDictionary.cs - Generic Change Tracking Dictionary
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
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Oddmatics.Util.Collections
{
    /// <summary>
    /// Represents a change tracked collection of keys and values.
    /// </summary>
    public class ChangeTrackingDictionary<TKey, TValue> : ChangeTrackingEx,
                                                          IDictionary<TKey, TValue>
    {
        /// <inheritdoc />
        public int Count
        {
            get { return InternalDictionary.Count; }
        }

        /// <inheritdoc />
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <inheritdoc />
        public ICollection<TKey> Keys
        {
            get { return InternalDictionary.Keys; }
        }

        /// <inheritdoc />
        public ICollection<TValue> Values
        {
            get { return InternalDictionary.Values; }
        }


        /// <summary>
        /// The internal <see cref="Dictionary{TKey, TValue}"/> that is wrapped by this
        /// class.
        /// </summary>
        protected Dictionary<TKey, TValue> InternalDictionary { get; set; }


        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChangeTrackingDictionary{TKey, TValue}"/> class.
        /// </summary>
        public ChangeTrackingDictionary()
        {
            InternalDictionary = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Initializes a new insance of the
        /// <see cref="ChangeTrackingDictionary{TKey, TValue}"/> class that contains
        /// elements copied from the specified <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="dictionary">
        /// The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to
        /// the new <see cref="ChangeTrackingDictionary{TKey, TValue}"/>.
        /// </param>
        public ChangeTrackingDictionary(
            IDictionary<TKey, TValue> dictionary
        )
        {
            InternalDictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChangeTrackingDictionary{TKey, TValue}"/> class that contains
        /// elements copied from the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection"></param>
        public ChangeTrackingDictionary(
            IEnumerable<KeyValuePair<TKey, TValue>> collection
        )
        {
            InternalDictionary = new Dictionary<TKey, TValue>(collection);
        }


        /// <inheritdoc />
        public TValue this[TKey key]
        {
            get { return InternalDictionary[key]; }
            set
            {
                InternalDictionary[key] = value;
                IsChanged               = true;
            }
        }


        /// <inheritdoc />
        public override void AcceptChanges()
        {
            IsChanged = false;
        }

        /// <inheritdoc />
        public void Add(
            TKey key,
            TValue value
        )
        {
            InternalDictionary.Add(key, value);
            IsChanged = true;
        }

        /// <inheritdoc />
        public void Add(
            KeyValuePair<TKey, TValue> item
        )
        {
            InternalDictionary.Add(item.Key, item.Value);
            IsChanged = true;
        }

        /// <inheritdoc />
        public void Clear()
        {
            if (InternalDictionary.Count == 0)
            {
                return;
            }

            InternalDictionary.Clear();
            IsChanged = true;
        }

        /// <inheritdoc />
        public bool Contains(
            KeyValuePair<TKey, TValue> item
        )
        {
            return InternalDictionary.Contains(item);
        }

        /// <inheritdoc />
        public bool ContainsKey(
            TKey key
        )
        {
            return InternalDictionary.ContainsKey(key);
        }

        /// <inheritdoc />
        public void CopyTo(
            KeyValuePair<TKey, TValue>[] array,
            int                          arrayIndex
        )
        {
            Array.Copy(
                InternalDictionary.ToArray(),
                0,
                array,
                arrayIndex,
                InternalDictionary.Count
            );
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }

        /// <inheritdoc />
        public bool Remove(
            TKey key
        )
        {
            bool res = InternalDictionary.Remove(key);

            if (res)
            {
                IsChanged = true;
            }

            return res;
        }

        /// <inheritdoc />
        public bool Remove(
            KeyValuePair<TKey, TValue> item
        )
        {
            bool res = InternalDictionary.Remove(item.Key);
            
            if (res)
            {
                IsChanged = true;
            }

            return res;
        }

        /// <inheritdoc />
        public bool TryGetValue(
            TKey       key,
            [MaybeNullWhen(false)]
            out TValue value
        )
        {
            return InternalDictionary.TryGetValue(key, out value);
        }
    }
}
