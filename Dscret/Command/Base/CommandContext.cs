using Dscret.Repository;

namespace Dscret.Command.Base
{
    public class CommandContext
    {
        public SetRepository? Repository { get; set; }
        public CommandContext()
        {
            Repository = new SetRepository();
        }
    }
}
