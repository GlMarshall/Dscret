using Dscret.Interfaces;

namespace Dscret.Repository
{
    public class Set : ISet
    {
        public char Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SortedSet<char> Elements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Count { get { return Elements.Count; } }
        public bool IsEmpty { get { return Elements.Count == 0; } }

        public Set(char name)
        {
            Name = name;
            Elements = new SortedSet<char>();
        }

        public Set(char name, SortedSet<char> elements) : this(name)
        {
            Elements = new SortedSet<char>(elements);
        }

        public void AddElement(char element)
        {
            Elements.Add(element);
        }

        public bool ContainsElement(char element)
        {
            return Elements.Contains(element);
        }

        public void RemoveElement(char element)
        {
            Elements.Remove(element);
        }

        public ISet Union(ISet other)
        {
            SortedSet<char> result = new SortedSet<char>(Elements);
            result.UnionWith(other.Elements);
            return new Set('\0', result);
        }

        public ISet Intersect(ISet other)
        {
            SortedSet<char> result = new SortedSet<char>(Elements);
            result.IntersectWith(other.Elements);
            return new Set('\0', result);
        }

        public ISet Difference(ISet other)
        {
            SortedSet<char> result = new SortedSet<char>(Elements);
            result.ExceptWith(other.Elements);
            return new Set('\0', result);
        }

        public bool IsSubSetOf(ISet other)
        {
            return Elements.IsSubsetOf(other.Elements);
        }

        public bool IsProperSubsetOf(ISet other)
        {
            return Elements.IsProperSubsetOf(other.Elements);
        }

        public bool IsSuperSetOf(ISet other)
        {
            return Elements.IsSupersetOf(other.Elements);
        }

        public bool Equals(ISet other)
        {
            if (other == null) return false;
            return Elements.SetEquals(other.Elements);
        }
    }
}
