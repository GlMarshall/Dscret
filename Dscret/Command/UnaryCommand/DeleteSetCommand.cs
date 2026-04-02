using Dscret.Command.Base;

namespace Dscret.Command.UnaryCommand
{
    public class DeleteSetCommand : Command<CommandContext>
    {
        public DeleteSetCommand(CommandContext context) : base(context) { }

        public override void Execute(CommandContext context, string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: Provide Set Name. Example: del A");
                return;
            }

            char setName = args[1][0];

            if (!context.Repository.Contains(setName))
            {
                Console.WriteLine($"Error: Set {setName} is not Exists");
                return;
            }

            context.Repository.Remove(setName);
            Console.WriteLine($"Set {setName} Deleted");
        }

        public override string GetHelp()
        {
            return "del A - Delete Set A";
        }
    }
}
