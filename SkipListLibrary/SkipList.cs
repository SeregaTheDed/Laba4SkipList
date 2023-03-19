using System;

namespace SkipListLibrary
{

    public class SkipList<TKey, TValue> 
        where TKey : IComparable<TKey>
    {
        private class Node
        {
            public TKey Key { get; }
            public TValue Value { get; }
            public Node[] Next { get; }

            public Node(TKey key, TValue value, int levels)
            {
                Key = key;
                Value = value;
                Next = new Node[levels];
            }
            public override string ToString()
            {
                return $"{Key}";
            }
        }
        private const int _levels = 32;
        private readonly Node _head;
        private readonly Random _random;
        public int Count { get; private set; }

        public SkipList()
        {
            _head = new Node(default(TKey), default(TValue), _levels);
            _random = new Random();
        }
        private int GetNewLevel()
        {
            int newLevel = 1;
            while (_random.NextDouble() < 0.5)
            {
                newLevel++;
            }
            if (newLevel > _levels)
                newLevel = _levels;
            return newLevel;
        }

        public void Add(TKey key, TValue value)
        {
            Node[] update = new Node[_levels];
            Node current = GetNodeOrNull(key, update);
            if (current != null)
                return;

            int newLevels = GetNewLevel();
            Node newNode = new Node(key, value, _levels);//newLevels -> _levels
            for (int i = 0; i < newLevels; i++)
            {
                newNode.Next[i] = update[i].Next[i];
                update[i].Next[i] = newNode;
            }
            Count++;
        }

        public TValue GetValue(TKey key)
        {
            var returnNode = GetNodeOrNull(key);
            if (returnNode == null)
                throw new InvalidOperationException();
            return returnNode.Value;
        }

        public TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue))
        {
            var returnNode = GetNodeOrNull(key);
            if (returnNode == null)
                return defaultValue;
            return returnNode.Value;
        }

        private Node GetNodeOrNull(TKey key, Node[] update = null)
        {
            Node current = _head;
            for (int i = _levels - 1; i >= 0; i--)
            {
                while (current.Next[i] != null && current.Next[i].Key.CompareTo(key) < 0)
                {
                    current = current.Next[i];
                }
                if (update != null)
                    update[i] = current;
            }
            current = current.Next[0];
            if (current == null || current.Key.CompareTo(key) != 0)
                return null;
            return current;
        }

        public bool Contains(TKey key)
        {
            Node current = GetNodeOrNull(key);
            return current != null;
        }

        public bool Remove(TKey key)
        {
            Node[] update = new Node[_levels];
            Node current = GetNodeOrNull(key, update);

            if (current == null)
                return false;
            for (int i = 0; i < _levels; i++)
            {
                if (update[i].Next[i] != current)
                {
                    break;
                }
                update[i].Next[i] = current.Next[i];
            }
            Count--;
            return true;
        }
    }
}
