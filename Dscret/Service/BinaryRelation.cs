namespace Dscret.Service
{
    public class BinaryRelation
    {
        public List<char> Elements { get; set; }
        public bool[,] Matrix { get; set; }
        public string RelationName { get; set; }
        public BinaryRelation(string filename)
        {
            LoadFromFile(filename);
        }
        public BinaryRelation()
        {
            Elements = new List<char>();
            Matrix = new bool[0, 0];
        }
        public BinaryRelation(List<char> elements)
        {
            Elements = new List<char>(elements);
            Matrix = new bool[elements.Count, elements.Count];
        }
        private void LoadFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            string[] elementsStr = lines[0].Trim().Split(' ');
            Elements = new List<char>();
            foreach (string line in elementsStr)
            {
                if (line.Length > 0)
                {
                    Elements.Add(line[0]);
                }
            }

            int n = Elements.Count;
            Matrix = new bool[n, n];

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                string[] pair = lines[i].Trim().Split(' ');
                if (pair.Length >= 2)
                {
                    char a = pair[0][0];
                    char b = pair[1][0];
                    int indexA = Elements.IndexOf(a);
                    int indexB = Elements.IndexOf(b);
                    if (indexA >= 0 && indexB >= 0)
                    {
                        Matrix[indexA, indexB] = true;
                    }
                }
            }
        }
        public void PrintMatrix()
        {
            Console.WriteLine("Matrix Relation");
            Console.Write(" ");
            foreach (char c in Elements) Console.Write($"{c} ");
            Console.WriteLine();

            for (int i = 0; i < Elements.Count; i++)
            {
                Console.Write($"{Elements[i]} | ");
                for (int j = 0; j < Elements.Count; j++)
                {
                    Console.Write(Matrix[i, j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
        }
        public BinaryRelation Union(BinaryRelation other)
        {
            if (Elements.Count != other.Elements.Count)
            {
                throw new Exception("Sets must be Equal");
            }
            BinaryRelation result = new BinaryRelation(Elements);

            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    result.Matrix[i, j] = this.Matrix[i, j] | other.Matrix[i, j];
                }
            }

            return result;
        }
        public BinaryRelation Intersection(BinaryRelation other)
        {
            if (Elements.Count != other.Elements.Count)
            {
                throw new Exception("Sets must be Equal");
            }
            BinaryRelation result = new BinaryRelation(Elements);

            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    result.Matrix[i, j] = this.Matrix[i, j] && other.Matrix[i, j];
                }
            }

            return result;
        }
        public BinaryRelation Compose(BinaryRelation other)
        {
            if (Elements.Count != other.Elements.Count)
            {
                throw new Exception("Sets Must be Equal");
            }
            BinaryRelation result = new BinaryRelation(Elements);
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    for (int k = 0; k < Elements.Count; k++)
                    {
                        if (this.Matrix[i, k] && other.Matrix[k, j])
                            result.Matrix[i, j] = true;
                    }
                }
            }
            return result;
        }

        public BinaryRelation Inverse()
        {
            BinaryRelation result = new BinaryRelation(Elements);

            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    result.Matrix[i, j] = this.Matrix[j, i];
                }
            }
            return result;
        }

        public bool IsSubsetOf(BinaryRelation other)
        {
            if (Elements.Count != other.Elements.Count)
                return false;
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (Matrix[i, j] && !other.Matrix[i, j])
                        return false;
                }
            }
            return true;
        }
        public bool Equals(BinaryRelation other)
        {
            if (other == null) return false;
            if (Elements.Count != other.Elements.Count)
                return false;
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (Matrix[i, j] != other.Matrix[i, j])
                        return false;
                }
            }
            return true;
        }

        public void PritnMatrix()
        {
            Console.WriteLine("\nRelation Matrix");
            Console.Write(" ");
            foreach (char c in Elements)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();

            for (int i = 0; i < Elements.Count; i++)
            {
                Console.Write(Elements[i] + " | ");
                for (int j = 0; j < Elements.Count; j++)
                {
                    Console.Write(Matrix[i, j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
        }

        public bool IsReflective()
        {
            for (int i = 0; i < Elements.Count; ++i)
            {
                if (!Matrix[i, i])
                    return false;
            }
            return true;
        }
        public bool IsAntiReflective()
        {
            for (int i = 0; i < Elements.Count; ++i)
            {
                if (Matrix[i, i])
                    return false;
            }
            return true;
        }
        public bool IsSymmetric()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (Matrix[i, j] != Matrix[j, i])
                        return false;
                }
            }
            return true;
        }

        public bool IsAntiSymmetric()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (i != j && Matrix[i, j] && Matrix[j, i])
                        return false;
                }
            }
            return true;
        }

        public bool IsTransitive()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (Matrix[i, j])
                    {
                        for (int k = 0; k < Elements.Count; k++)
                        {
                            if (Matrix[j, k] && !Matrix[i, k])
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool IsEquivalence() =>
            IsReflective() && IsSymmetric() && IsTransitive();
        public bool IsPartianOrder() =>
            IsReflective() && IsAntiSymmetric() && IsTransitive();

        public bool IsTotalOrder()
        {
            if (!IsPartianOrder()) return false;
            for (int i = 0; i < Elements.Count; i++)
            {
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (i != j && !Matrix[i, j] && !Matrix[j, i])
                        return false;
                }
            }
            return true;
        }
        public void PrintProperties()
        {
            Console.WriteLine("\n--- Relation Properties ---");
            Console.WriteLine($"1. Reflectivity: {(IsReflective() ? "+" : "-")}");
            Console.WriteLine($"2. Antireflectivity: {(IsAntiReflective() ? "+" : "-")}");
            Console.WriteLine($"3. Symmetry: {(IsSymmetric() ? "+" : "-")}");
            Console.WriteLine($"4. Antisymmetry: {(IsAntiSymmetric() ? "+" : "-")}");
            Console.WriteLine($"5. Transitivity: {(IsTransitive() ? "+" : "-")}");
            Console.WriteLine($"6. Equivalense Relation: {(IsEquivalence() ? "+" : "-")}");
            Console.WriteLine($"7. Partial Order Relation: {(IsPartianOrder() ? "+" : "-")}");
            Console.WriteLine($"8. Total Order Relation: {(IsTotalOrder() ? "+" : "-")}");
        }
        public List<List<char>> GetEquivalenceClasses()
        {
            if (!IsEquivalence())
            {
                return null;
            }
            List<List<char>> classes = new List<List<char>>();
            bool[] visited = new bool[Elements.Count];

            for (int i = 0; i < Elements.Count; i++)
            {
                if (!visited[i])
                {
                    List<char> equivalenceClass = new List<char>();
                    for (int j = 0; j < Elements.Count; j++)
                    {
                        if (Matrix[i, j])
                        {
                            equivalenceClass.Add(Elements[j]);
                            visited[j] = true;
                        }
                    }
                    classes.Add(equivalenceClass);
                }
            }
            return classes;
        }

        public void PrintEquivalenceClasses()
        {
            var classes = GetEquivalenceClasses();
            if (classes == null)
            {
                Console.WriteLine("Reflection is not Equivalence");
                return;
            }
            Console.WriteLine("\n--- Equivalence Classes ---");
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"Class {i + 1}: {{{string.Join(", ", classes[i])}}}");
            }
            Console.WriteLine($"Partition Index: {classes.Count}");
        }
        public List<char> GetMinimalElements()
        {
            if (IsPartianOrder()) return null;
            List<char> minimal = new List<char>();
            for (int i = 0; i < Elements.Count; i++)
            {
                bool isMinimal = true;
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (i != j && Matrix[j, i])
                    {
                        isMinimal = false;
                        break;
                    }
                }
                if (isMinimal)
                {
                    minimal.Add(Elements[i]);
                }
            }
            return minimal;
        }
        public List<char> GetMaximalElements()
        {
            if (!IsPartianOrder()) return null;
            List<char> maximal = new List<char>();
            for (int i = 0; i < Elements.Count; i++)
            {
                bool isMaximal = true;
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (i != j && Matrix[j, i])
                    {
                        isMaximal = false;
                        break;
                    }
                }
                if (isMaximal)
                {
                    maximal.Add(Elements[i]);
                }
            }
            return maximal;
        }
        public char? GetSmallesElement()
        {
            if (!IsPartianOrder()) return null;
            for (int i = 0; i < Elements.Count; i++)
            {
                bool isSmallest = true;
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (i != j && !Matrix[i, j])
                    {
                        isSmallest = false;
                        break;
                    }
                }
                if (isSmallest)
                {
                    return Elements[i];
                }
            }
            return null;
        }
        public char? GetGreatestElement()
        {
            if (!IsPartianOrder()) return null;
            for (int i = 0; i < Elements.Count; i++)
            {
                bool isGreatest = true;
                for (int j = 0; j < Elements.Count; j++)
                {
                    if (i != j && !Matrix[j, i])
                    {
                        isGreatest = false;
                        break;
                    }
                }
                if (isGreatest)
                {
                    return Elements[i];
                }
            }
            return null;
        }
        public void PrintOrderElements()
        {
            if (!IsPartianOrder())
            {
                Console.WriteLine("Relation is not Order");
                return;
            }

            var minimal = GetMinimalElements();
            var maximal = GetMaximalElements();
            var smallest = GetSmallesElement();
            var greatest = GetGreatestElement();

            Console.WriteLine("\n--- Elements Partitial Order Set ---");
            Console.WriteLine($"Minimal Elements: {(minimal.Count > 0 ? "{" + string.Join(", ", minimal) + "}" : "no")}");
            Console.WriteLine($"Minimal Elements: {(maximal.Count > 0 ? "{" + string.Join(", ", maximal) + "}" : "no")}");

            if (smallest.HasValue)
            {
                Console.WriteLine($"Smallest Element: {smallest}");
            }
            else
            {
                Console.WriteLine("Smallest Element: absent");
            }

            if (greatest.HasValue)
            {
                Console.WriteLine($"Greaterst Element: {greatest}");
            }
            else
            {
                Console.WriteLine("Greaterst Element: absent");
            }
        }
    }
}
