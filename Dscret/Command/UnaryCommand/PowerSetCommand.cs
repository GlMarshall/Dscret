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

            set.PrintPowerSet();
        }

        public override string GetHelp()
        {
            return "pow A - Calculate Boolean of Set A";
        }
    }
}
