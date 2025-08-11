using System;
using System.Collections.Generic;

public class HashTableChaining<TKey, TValue>
{
    private class HashNode
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    private readonly int _size;
    private readonly LinkedList<HashNode>[] _buckets;
    private int _count;

    public int Count => _count;

    public HashTableChaining(int size = 32)
    {
        _size = size;
        _buckets = new LinkedList<HashNode>[_size];
        for (int i = 0; i < _size; i++)
        {
            _buckets[i] = new LinkedList<HashNode>();
        }
        _count = 0;
    }

    private int GetBucketIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        return Math.Abs(hashCode % _size);
    }

    public TValue Find(TKey key)
    {
        int index = GetBucketIndex(key);
        var bucket = _buckets[index];

        foreach (var node in bucket)
        {
            if (node.Key.Equals(key))
            {
                return node.Value;
            }
        }
        return default(TValue);
    }

    public void Insert(TKey key, TValue value)
    {
        int index = GetBucketIndex(key);
        var bucket = _buckets[index];

        foreach (var node in bucket)
        {
            if (node.Key.Equals(key))
            {
                node.Value = value; 
                return;
            }
        }

        var newNode = new HashNode { Key = key, Value = value };
        bucket.AddLast(newNode);
        _count++;
    }

    public void Remove(TKey key)
    {
        int index = GetBucketIndex(key);
        var bucket = _buckets[index];
        var nodeToRemove = default(HashNode);

        foreach (var node in bucket)
        {
            if (node.Key.Equals(key))
            {
                nodeToRemove = node;
                break;
            }
        }

        if (nodeToRemove != null)
        {
            bucket.Remove(nodeToRemove);
            _count--;
        }
    }
}