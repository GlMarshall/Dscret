using Dscret.Repository.Base;

namespace Dscret.Repository
{
    public class SetRepository : Repository<char, Set>
    {
        public override void Add(char key, Set value)
        {
            if (!char.IsLetter(key) || !char.IsUpper(key))
            {
                throw new ArgumentException("Set Name must be A-Z");
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Set connot be null");
            }
            base.Add(key, value);
        }

        public Set? GetSetOrDefault(char key)
        {
            // Check Later With Method Get
            return Contains(key) ? Get(key) : null;
        }
        public void PrintAllSets()
        {
            // Check Access Ability of _items
            if (_items.Count == 0)
            {
                Console.WriteLine("No Sets");
                return;
            }

            Console.WriteLine("Set List");
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
        public bool TryGetSet(char key, out Set set)
        {
            set = GetSetOrDefault(key);
            return set != null;
        }
    }

}
