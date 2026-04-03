using Dscret.Repository;

namespace Dscret.Command.Base
{
    public abstract class BinaryOperationCommand : Command<CommandContext>
    {
        protected BinaryOperationCommand(CommandContext context) : base(context) { }
        protected abstract string GetOperationSymbol();
        protected abstract Set Operate(Set setA, Set setB);
        protected abstract string GetOperationName();

        public override void Execute(CommandContext context, string[] args)
        {
            string operation = args[0];
            var parts = operation.Split(GetOperationSymbol());

            if (parts.Length != 2 || parts[0].Length != 1 || parts[1].Length != 1)
            {
                Console.WriteLine($"Error: Invalid Format. Example: A{GetOperationSymbol()}B");
                return;
            }

            char setNameA = parts[0][0];
            char setNameB = parts[1][0];

            if (!context.Repository.TryGetSet(setNameA, out Set setA))
            {
                Console.WriteLine($"Error: Set {setNameA} Not Exists");
                return;
            }

            if (!context.Repository.TryGetSet(setNameB, out Set setB))
            {
                Console.WriteLine($"Error: Set {setNameB} Is Not Exists");
                return;
            }

            Set result = Operate(setA, setB);
            Console.WriteLine($"{GetOperationName()} {setNameA} {GetOperationSymbol()} {setNameB} ={string.Join(", ", result)}");
        }
    }
}
