﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;

namespace GitHub.Protobufel.MultiKeyMap
{
    internal static partial class EnumerableExtensions
    {
        internal static IList<T> ToListWrapper<T>(this IEnumerable<T> source)
        {
            switch (source)
            {
                case null:
                    throw new ArgumentNullException("source");
                case IList<T> list:
                    return list;
                default:
                    return new VirtualList<T>(source);
            }
        }

        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            return new ReadOnlyCollection<T>(source.ToListWrapper());
        }

        public static ReadOnlyCollection<TResult> ToReadOnlyCollection<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            return new ReadOnlyCollection<TResult>(source.Select(selector).ToListWrapper());
        }

        public static ReadOnlyCollection<TResult> ToReadOnlyCollection<T, TResult>(this IEnumerable<T> source, Func<T, int, TResult> selector)
        {
            return new ReadOnlyCollection<TResult>(source.Select(selector).ToListWrapper());
        }
    }

    [Serializable]
    internal class VirtualList<T> : IList<T>
    {
        protected IEnumerable<T> source;

        public VirtualList(IEnumerable<T> source)
        {
            this.source = source;
        }

        public virtual T this[int index] { get => source.ElementAt(index); set => throw new NotImplementedException(); }

        public virtual int Count => source.Count();

        public virtual bool IsReadOnly => true;

        public virtual void Add(T item)
        {
            throw new NotImplementedException();
        }

        public virtual bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public virtual bool Contains(T item)
        {
            return source.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in source)
            {
                array[arrayIndex++] = item;
            }
        }

        public virtual int IndexOf(T item)
        {
            return source.Count(x => EqualityComparer<T>.Default.Equals(x, item));
        }

        public virtual void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in source)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}