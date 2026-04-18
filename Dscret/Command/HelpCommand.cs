using Dscret.Command.Base;
using Dscret.Interfaces;

namespace Dscret.Command
{
    public class HelpCommand : Command<CommandContext>
    {
        private Dictionary<string, ICommand<CommandContext>> _commands;
        public HelpCommand(CommandContext context, Dictionary<string, ICommand<CommandContext>> commands) : base(context)
        {
            _commands = commands;
        }
        public override void Execute(CommandContext context, string[] args)
        {
            Console.WriteLine("\n--- Commands ---");
            foreach (var cmd in _commands)
            {
                Console.WriteLine("  " + cmd.Value.GetHelp());
            }
            //Console.WriteLine("  help - show commands");
            Console.WriteLine("  exit - Exit");
            Console.WriteLine();
        }

        public override string GetHelp()
        {
            return "help  - Show Commands";
        }
    }
}
