namespace Dscret.Interfaces
{
    public interface IRepository<TKey, TValue>
    {
        public bool Contains(TKey key);
        TValue Get(TKey key);
        public void Add(TKey key, TValue value);
        public void Remove(TKey key);
        public Dictionary<TKey, TValue> GetAll();
        public void Clear();
    }
}
