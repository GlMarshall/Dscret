using Dscret.Repository;
using Dscret.Service;

namespace Dscret.Command.Base
{
    public class CommandContext
    {
        public SetRepository? Repository { get; set; }
        public BinaryRelation? CurrentRelation { get; set; }
        public CommandContext()
        {
            Repository = new SetRepository();
            CurrentRelation = null;
        }
    }
}
