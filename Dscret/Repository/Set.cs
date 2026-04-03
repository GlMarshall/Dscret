namespace Dscret.Repository
{
    public class Set
    {
        public char Name { get; set; }
        public List<char> Elements { get; set; }
        public int Count => Elements.Count;
        public bool IsEmpty => Elements.Count == 0;

        public Set(char name)
        {
            Name = name;
            Elements = new List<char>();
        }


        public Set(char name, List<char> elements) : this(name)
        {
            Elements = new List<char>(elements);
            Sort();
        }

        private void Sort()
        {
            for (int i = 0; i < Elements.Count - 1; i++)
            {
                for (int j = 0; j < Elements.Count - i - 1; j++)
                {
                    if (Elements[j] > Elements[j + 1])
                    {
                        char temp = Elements[j];
                        Elements[j] = Elements[j + 1];
                        Elements[j + 1] = temp;
                    }
                }
            }
        }

        public void AddElement(char element)
        {
            if (ContainsElement(element))
                return;

            int index = 0;
            while (index < Elements.Count && Elements[index] < element)
            {
                index++;
            }
            Elements.Insert(index, element);
        }

        public void RemoveElement(char element)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] == element)
                {
                    Elements.RemoveAt(i);
                    break;
                }
            }
        }

        public bool ContainsElement(char element)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] == element)
                    return true;
                if (Elements[i] > element)
                    break;
            }
            return false;
        }

        public override string ToString()
        {
            if (Elements.Count == 0)
                return $"{Name}: {{пустое множество}}";
            return $"{Name}: {{{string.Join(", ", Elements)}}}";
        }

        public Set Union(Set other)
        {
            Set result = new Set('\0');
            int i = 0, j = 0;

            while (i < this.Elements.Count && j < other.Elements.Count)
            {
                if (this.Elements[i] < other.Elements[j])
                {
                    result.Elements.Add(this.Elements[i]);
                    i++;
                }
                else if (this.Elements[i] > other.Elements[j])
                {
                    result.Elements.Add(other.Elements[j]);
                    j++;
                }
                else
                {
                    result.Elements.Add(this.Elements[i]);
                    i++;
                    j++;
                }
            }

            while (i < this.Elements.Count)
            {
                result.Elements.Add(this.Elements[i]);
                i++;
            }

            while (j < other.Elements.Count)
            {
                result.Elements.Add(other.Elements[j]);
                j++;
            }

            return result;
        }

        public Set Intersection(Set other)
        {
            Set result = new Set('\0');
            int i = 0, j = 0;

            while (i < this.Elements.Count && j < other.Elements.Count)
            {
                if (this.Elements[i] < other.Elements[j])
                {
                    i++;
                }
                else if (this.Elements[i] > other.Elements[j])
                {
                    j++;
                }
                else
                {
                    result.Elements.Add(this.Elements[i]);
                    i++;
                    j++;
                }
            }

            return result;
        }

        public Set Difference(Set other)
        {
            Set result = new Set('\0');
            int i = 0, j = 0;


            while (i < this.Elements.Count && j < other.Elements.Count)
            {
                if (this.Elements[i] < other.Elements[j])
                {
                    result.Elements.Add(this.Elements[i]);
                    i++;
                }
                else if (this.Elements[i] > other.Elements[j])
                {
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }

            while (i < this.Elements.Count)
            {
                result.Elements.Add(this.Elements[i]);
                i++;
            }

            return result;
        }

        public bool IsSubsetOf(Set other)
        {
            foreach (char c in this.Elements)
            {
                if (!other.ContainsElement(c))
                    return false;
            }
            return true;
        }

        public bool IsProperSubsetOf(Set other)
        {
            return IsSubsetOf(other) && this.Elements.Count < other.Elements.Count;
        }

        public bool Equals(Set other)
        {
            if (other == null) return false;
            if (this.Elements.Count != other.Elements.Count) return false;

            for (int i = 0; i < this.Elements.Count; i++)
            {
                if (this.Elements[i] != other.Elements[i])
                    return false;
            }
            return true;
        }

        public List<Set> GetPowerSet()
        {
            List<Set> powerSet = new List<Set>();

            powerSet.Add(new Set('\0'));

            for (int i = 0; i < Elements.Count; i++)
            {
                char currentElement = Elements[i];
                int currentSize = powerSet.Count;

                for (int j = 0; j < currentSize; j++)
                {
                    Set newSubset = new Set('\0');
                    foreach (char c in powerSet[j].Elements)
                    {
                        newSubset.AddElement(c);
                    }
                    newSubset.AddElement(currentElement);
                    powerSet.Add(newSubset);
                }
            }

            return powerSet;
        }

        public void PrintPowerSet()
        {
            var powerSet = GetPowerSet();
            Console.WriteLine($"Boolean P({Name}) Contains {powerSet.Count} Elements:");
            Console.Write("{ ");

            for (int i = 0; i < powerSet.Count; i++)
            {
                if (powerSet[i].Elements.Count == 0)
                    Console.Write("Empty Set");
                else
                    Console.Write($"{{{string.Join(", ", powerSet[i].Elements)}}}");

                if (i < powerSet.Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine(" }");
        }
    }
}

