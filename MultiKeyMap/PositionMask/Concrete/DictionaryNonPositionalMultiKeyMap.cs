﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GitHub.Protobufel.MultiKeyMap.PositionMask.Simple;

namespace GitHub.Protobufel.MultiKeyMap.PositionMask.Concrete
{
    internal class DictionaryNonPositionalMultiKeyMap<T, K, V> : NonPositionalBaseMultiKeyMap<T, K, V> where K : IEnumerable<T>
    {
        public DictionaryNonPositionalMultiKeyMap(IEqualityComparer<T> subKeyComparer = null, IEqualityComparer<K> fullKeyComparer = null)
            : base(subKeyComparer, fullKeyComparer)
        {
        }

        protected override IDictionary<TKey, TValue> CreateDictionary<TKey, TValue>(IEqualityComparer<TKey> comparer)
        {
            return new Dictionary<TKey, TValue>(comparer ?? throw new ArgumentNullException("comparer"));
        }

        [OnDeserialized]
        protected virtual void OnDeserialized(StreamingContext context)
        {
            base.OnDeserializedHelper(context);
        }
    }
}