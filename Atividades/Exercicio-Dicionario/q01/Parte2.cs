using System;

public class HashTableLinearProbing<TKey, TValue>
{
    private class HashNode
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public bool IsDeleted { get; set; }
    }

    private readonly int _size;
    private readonly HashNode[] _buckets;
    private int _count;

    public int Count => _count;

    public HashTableLinearProbing(int size = 32)
    {
        _size = size;
        _buckets = new HashNode[_size];
        _count = 0;
    }

    private int GetBucketIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        return Math.Abs(hashCode % _size);
    }

    public void Insert(TKey key, TValue value)
    {
        if (_count >= _size)
        {
            throw new InvalidOperationException("Hash table is full.");
        }

        int index = GetBucketIndex(key);

        for (int i = 0; i < _size; i++)
        {
            int probeIndex = (index + i) % _size;
            var bucket = _buckets[probeIndex];

            if (bucket == null || bucket.IsDeleted)
            {
                _buckets[probeIndex] = new HashNode { Key = key, Value = value, IsDeleted = false };
                _count++;
                return;
            }

            if (bucket.Key.Equals(key))
            {
                bucket.Value = value;
                return;
            }
        }
    }

    public TValue Find(TKey key)
    {
        int index = GetBucketIndex(key);

        for (int i = 0; i < _size; i++)
        {
            int probeIndex = (index + i) % _size;
            var bucket = _buckets[probeIndex];
            
            if (bucket == null)
            {
                return default(TValue);
            }

            if (!bucket.IsDeleted && bucket.Key.Equals(key))
            {
                return bucket.Value;
            }
        }
        return default(TValue);
    }

    public void Remove(TKey key)
    {
        int index = GetBucketIndex(key);
        
        for (int i = 0; i < _size; i++)
        {
            int probeIndex = (index + i) % _size;
            var bucket = _buckets[probeIndex];

            if (bucket == null)
            {
                return;
            }

            if (!bucket.IsDeleted && bucket.Key.Equals(key))
            {
                bucket.IsDeleted = true;
                _count--;
                return;
            }
        }
    }
}