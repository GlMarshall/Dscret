using Dscret.Command.Base;
using Dscret.Repository;

namespace Dscret.Command.BinaryCommand
{
    public class IntersectionCommand : BinaryOperationCommand
    {
        public IntersectionCommand(CommandContext context) : base(context)
        {
        }
        protected override string GetOperationSymbol() => "&";
        protected override string GetOperationName() => "INtersection";

        protected override Set Operate(Set setA, Set setB)
        {
            Set result = setA.Intersection(setB);
            return result;
        }

        public override string GetHelp() => "A&B  - INtersection Sets A и B";
    }
}
