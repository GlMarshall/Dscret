using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.UnaryCommand
{
    public class SeeCommand : Command<CommandContext>
    {
        public SeeCommand(CommandContext context) : base(context) { }
        public override void Execute(CommandContext context, string[] args)
        {
            if (args.Length == 1)
            {
                context.Repository.PrintAllSets();
            }
            else if (args.Length >= 2)
            {
                char setName = args[1][0];
                if (!context.Repository.TryGetSet(setName, out Set set))
                {
                    Console.WriteLine($"Error: Set {setName} is not Exist");
                    return;
                }
                Console.WriteLine(set.ToString());
            }
            else
            {
                Console.WriteLine("Error: wrong format. Example: see or see A");
            }
        }

        public override string GetHelp()
        {
            return "see [A] - See Set A Or All Sets";
        }
    }
}
