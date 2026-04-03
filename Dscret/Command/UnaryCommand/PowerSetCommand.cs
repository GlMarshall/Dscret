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
                List<char> subset = new List<char>();
                int number = i;
                int position = 0;

                while (number > 0 && position < n)
                {
                    if (number % 2 == 1)
                    {
                        subset.Add(elements[position]);
                    }
                    number = number / 2;
                    position++;
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
