namespace Dscret.Interfaces
{
    public interface ISet
    {
        public char Name { get; set; }
        public SortedSet<char> Elements { get; set; }
        public void AddElement(char element);
        public void RemoveElement(char element);
        public bool ContainsElement(char element);
        public ISet Union(ISet other);
        public ISet Intersect(ISet other);
        public ISet Difference(ISet other);
        public bool IsSubSetOf(ISet other);
        public bool IsProperSubsetOf(ISet other);
        public bool IsSuperSetOf(ISet other);
        public bool Equals(ISet other);
    }
}
