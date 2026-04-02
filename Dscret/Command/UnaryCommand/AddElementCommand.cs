using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.UnaryCommand
{
    public class AddElementCommand : Command<CommandContext>
    {
        public AddElementCommand(CommandContext context) : base(context) { }

        public override void Execute(CommandContext context, string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Error: Provoide Set and Element. Example: add A x");
                return;
            }
            char setName = args[1][0];
            char element = args[2][0];

            if (!context.Repository.TryGetSet(setName, out Set set))
            {
                Console.WriteLine($"Error: Set {setName} is not Exists");
                return;
            }

            if (set.ContainsElement(element))
            {
                Console.WriteLine($"Element {element} is Already Exist {setName}");
                return;
            }

            set.AddElement(element);
            Console.WriteLine($"Element {element} Added in Set {setName}");
        }


        public override string GetHelp()
        {
            return "add A x - add elemetn into set";
        }
    }
}
