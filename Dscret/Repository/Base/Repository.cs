using Dscret.Interfaces;

namespace Dscret.Repository.Base
{
    public class Repository<TKey, TValue> : IRepository<TKey, TValue>
    {
        public Dictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();
        public virtual void Add(TKey key, TValue value)
        {
            if (!_items.ContainsKey(key))
            {
                _items[key] = value;
            }
        }

        public virtual void Clear()
        {
            _items.Clear();
        }

        public virtual bool Contains(TKey key)
        {
            return _items.ContainsKey(key);
        }

        public virtual TValue? Get(TKey key)
        {
            return _items.ContainsKey(key) ? _items[key] : default(TValue);
        }

        public virtual Dictionary<TKey, TValue> GetAll()
        {
            return _items;
        }

        public virtual void Remove(TKey key)
        {
            if (_items.ContainsKey(key))
            {
                _items.Remove(key);
            }
        }
    }
}
