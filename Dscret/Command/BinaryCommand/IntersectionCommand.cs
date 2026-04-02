using Dscret.Command.Base;

namespace Dscret.Command.BinaryCommand
{
    public class IntersectionCommand : BinaryOperationCommand
    {
        public IntersectionCommand(CommandContext context) : base(context)
        {
        }
        protected override string GetOperationSymbol() => "&";
        protected override string GetOperationName() => "INtersection";

        protected override SortedSet<char> Operate(SortedSet<char> setA, SortedSet<char> setB)
        {
            SortedSet<char> result = new SortedSet<char>(setA);
            result.IntersectWith(setB);
            return result;
        }

        public override string GetHelp() => "A&B  - INtersection Sets A и B";
    }
}
