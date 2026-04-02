using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.UnaryCommand
{
    public class RemoveElementCommand : Command<CommandContext>
    {
        public RemoveElementCommand(CommandContext context) : base(context)
        {
        }
        public override void Execute(CommandContext context, string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Error: Provide Set And Element. Example: rem A x");
                return;
            }

            char setName = args[1][0];
            char element = args[2][0];

            if (!context.Repository.TryGetSet(setName, out Set set))
            {
                Console.WriteLine($"Error: Set {setName} is not Exist");
                return;
            }

            if (!set.ContainsElement(element))
            {
                Console.WriteLine($"Element {element} Not Found In Set {setName}");
                return;
            }

            set.RemoveElement(element);
            Console.WriteLine($"Element '{element}' Was Removed in Set {setName}");
        }

        public override string GetHelp()
        {
            return "rem A x - Remove Element x From A";
        }
    }
}
