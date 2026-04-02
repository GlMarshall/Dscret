using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.BinaryCommand
{
    public class EqualityCommand : Command<CommandContext>
    {
        public EqualityCommand(CommandContext context) : base(context) { }
        public override void Execute(CommandContext context, string[] args)
        {
            string operation = args[0];
            var parts = operation.Split('=');

            if (parts.Length != 2 || parts[0].Length != 1 || parts[1].Length != 1)
            {
                Console.WriteLine("Error: invalid format. Example: A=B");
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
                Console.WriteLine($"Error: Set {setNameB} is not Exists");
                return;
            }

            bool areEqual = setA.Equals(setB);

            if (areEqual)
                Console.WriteLine($"{setNameA} and {setNameB} Sets is Equal");
            else
                Console.WriteLine($"{setNameA} and {setNameB} Sets is not Equal");
        }

        public override string GetHelp()
        {
            return "A=B - A and B is Equal?";
        }
    }
}
