using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.BinaryCommand
{
    public class UnionCommand : BinaryOperationCommand
    {
        public UnionCommand(CommandContext context) : base(context) { }
        protected override string GetOperationSymbol() => "+";
        protected override string GetOperationName() => "Union";

        protected override Set Operate(Set setA, Set setB)
        {
            Set result = setA.Union(setB);
            return result;
        }

        public override string GetHelp() => "A+B - Union A and B";
    }
}
