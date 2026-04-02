using Dscret.Interfaces;

namespace Dscret.Command.Base
{
    public abstract class Command<TContext> : ICommand<TContext>
    {
        protected TContext? _context;
        public Command(TContext? context)
        {
            _context = context;
        }

        public abstract void Execute(TContext context, string[] args);

        public abstract string GetHelp();
    }
}
