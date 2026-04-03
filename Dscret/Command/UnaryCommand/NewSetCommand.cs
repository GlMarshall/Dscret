using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.UnaryCommand
{
    public class NewSetCommand : Command<CommandContext>
    {
        public NewSetCommand(CommandContext? context) : base(context) { }

        public override void Execute(CommandContext context, string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: provide name for set. Example: new A");
                return;
            }

            char setName = args[1][0];

            if (!char.IsLetter(setName) || !char.IsUpper(setName))
            {
                Console.WriteLine("Error: Name Must be Letter A - Z");
                return;
            }
            if (context.Repository.Contains(setName))
            {
                Console.WriteLine("Set is Already Exists");
                return;
            }
            context.Repository.Add(setName, new Set(setName));
            Console.WriteLine($"Set {setName} created");

        }

        public override string GetHelp()
        {
            return "new A - Create New Set A";
        }
    }
}
