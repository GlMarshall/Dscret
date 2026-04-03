using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.BinaryCommand
{
    public class DifferenceCommand : BinaryOperationCommand
    {
        public DifferenceCommand(CommandContext context) : base(context)
        {
        }
        protected override string GetOperationSymbol() => "-";
        protected override string GetOperationName() => "Difference";

        protected override Set Operate(Set setA, Set setB)
        {
            Set result = setA.Difference(setB);
            return result;
        }

        public override string GetHelp() => "A-B - Differnece Sets A and B";
    }
}
