using Dscret.Command.Base;
using Dscret.Command.BinaryCommand;
using Dscret.Command.UnaryCommand;
using Dscret.Interfaces;

namespace Dscret.Command
{
    public class CommandFactory
    {
        private Dictionary<string, ICommand<CommandContext>> _commands;
        private List<ICommand<CommandContext>> _operationCommands;
        private CommandContext _context;

        public CommandFactory(CommandContext context)
        {
            _context = context;
            _commands = new Dictionary<string, ICommand<CommandContext>>();
            _operationCommands = new List<ICommand<CommandContext>>();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            _commands["new"] = new NewSetCommand(_context);
            _commands["del"] = new DeleteSetCommand(_context);
            _commands["add"] = new AddElementCommand(_context);
            _commands["rem"] = new RemoveElementCommand(_context);
            _commands["pow"] = new PowerSetCommand(_context);
            _commands["see"] = new SeeCommand(_context);

            _operationCommands.Add(new UnionCommand(_context));
            _operationCommands.Add(new IntersectionCommand(_context));
            _operationCommands.Add(new DifferenceCommand(_context));
            _operationCommands.Add(new SubsetCommand(_context));
            _operationCommands.Add(new EqualityCommand(_context));

            _commands["help"] = new HelpCommand(_context, _commands);
        }

        public (ICommand<CommandContext>, string[]) GetCommand(string input)
        {
            string[] args = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (args.Length == 0)
                return (null, null);

            string commandKey = args[0].ToLower();

            if (_commands.ContainsKey(commandKey))
            {
                return (_commands[commandKey], args);
            }

            if (input.Contains('+'))
                return (new UnionCommand(_context), new string[] { input });
            if (input.Contains('&'))
                return (new IntersectionCommand(_context), new string[] { input });
            if (input.Contains('-'))
                return (new DifferenceCommand(_context), new string[] { input });
            if (input.Contains('<'))
                return (new SubsetCommand(_context), new string[] { input });
            if (input.Contains('='))
                return (new EqualityCommand(_context), new string[] { input });

            return (null, null);
        }

    }
}
