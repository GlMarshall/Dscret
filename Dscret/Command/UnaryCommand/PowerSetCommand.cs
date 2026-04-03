using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.UnaryCommand
{
    public class PowerSetCommand : Command<CommandContext>
    {
        public PowerSetCommand(CommandContext context) : base(context) { }
        public override void Execute(CommandContext context, string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: Provide Set Name. Example: pow A");
                return;
            }

            char setName = args[1][0];

            if (!context.Repository.TryGetSet(setName, out Set set))
            {
                Console.WriteLine($"Error: Set {setName} is not Exists");
                return;
            }

            var elements = set.Elements.ToList();
            int n = elements.Count;
            int powerSetSize = (int)Math.Pow(2, n);

            Console.WriteLine($"Boolean P({setName}) Contains {powerSetSize} Elements:");
            Console.Write("{ ");

            for (int i = 0; i < powerSetSize; i++)
            {
                IList<char> subset = new List<char>();
                int temp = i;

                for (int j = 0; j < n; j++)
                {
                    int divisor = 1;
                    for (int k = 0; k < j; k++)
                    {
                        divisor *= 2;
                    }

                    if ((temp / divisor) % 2 == 1)
                    {
                        subset.Add(elements[j]);
                    }
                }

                if (subset.Count == 0)
                    Console.Write("Empty Set");
                else
                    Console.Write($"{{{string.Join(", ", subset)}}}");

                if (i < powerSetSize - 1)
                    Console.Write(", ");
            }

            Console.WriteLine(" }");
        }

        public override string GetHelp()
        {
            return "pow A - Calculate Boolean of Set A";
        }
    }
}
