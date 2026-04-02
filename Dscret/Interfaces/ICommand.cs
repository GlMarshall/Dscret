namespace Dscret.Interfaces
{
    public interface ICommand<TContext>
    {
        string GetHelp();
        void Execute(TContext context, string[] args);
    }
}
