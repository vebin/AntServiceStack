﻿

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#if NETFX_CORE
namespace AntServiceStack.Text.WinRT
#else
namespace AntServiceStack.Text.WP
#endif
{
    ///<summary>
    /// A hashset implementation that uses an IDictionary
    ///</summary>
    public class HashSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        private readonly Dictionary<T, short> _dict;

        public HashSet()
        {
            _dict = new Dictionary<T, short>();
        }

        public HashSet(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            _dict =  new Dictionary<T, short>(collection.Count());
            foreach (T item in collection)
                Add(item);
        }

        public void Add(T item)
        {
            _dict.Add(item, 0);
        }

        public void Clear()
        {
            _dict.Clear();
        }

        public bool Contains(T item)
        {
            return _dict.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _dict.Keys.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _dict.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dict.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dict.Keys.GetEnumerator();
        }

        public int Count
        {
            get { return _dict.Keys.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
    }
}
