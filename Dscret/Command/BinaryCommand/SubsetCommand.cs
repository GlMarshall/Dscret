using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.BinaryCommand
{
    public class SubsetCommand : Command<CommandContext>
    {
        public SubsetCommand(CommandContext context) : base(context)
        {
        }
        public override void Execute(CommandContext context, string[] args)
        {
            string operation = args[0];
            var parts = operation.Split('<');

            if (parts.Length != 2 || parts[0].Length != 1 || parts[1].Length != 1)
            {
                Console.WriteLine("Error: Invalid Format. Example: A<B");
                return;
            }

            char setNameA = parts[0][0];
            char setNameB = parts[1][0];

            if (!context.Repository.TryGetSet(setNameA, out Set setA))
            {
                Console.WriteLine($"Error: Set {setNameA} is not Exists");
                return;
            }

            if (!context.Repository.TryGetSet(setNameB, out Set setB))
            {
                Console.WriteLine($"Error: Set {setNameB} Is not Exists");
                return;
            }

            bool isSubset = setA.IsSubSetOf(setB);

            if (isSubset)
            {
                bool isProper = setA.IsProperSubsetOf(setB);
                if (isProper)
                    Console.WriteLine($"{setNameA} and {setNameB} Subset");
                else
                    Console.WriteLine($"{setNameA} and {setNameB} Sets is Equal");
            }
            else
            {
                Console.WriteLine($"{setNameA} is Not Subset {setNameB}");
            }
        }

        public override string GetHelp()
        {
            return "A<B - A is Subset B";
        }
    }
}
