using Dscret.Command.Base;

namespace Dscret.Command.BinaryCommand
{
    public class DifferenceCommand : BinaryOperationCommand
    {
        public DifferenceCommand(CommandContext context) : base(context)
        {
        }
        protected override string GetOperationSymbol() => "-";
        protected override string GetOperationName() => "Difference";

        protected override SortedSet<char> Operate(SortedSet<char> setA, SortedSet<char> setB)
        {
            SortedSet<char> result = new SortedSet<char>(setA);
            result.ExceptWith(setB);
            return result;
        }

        public override string GetHelp() => "A-B - Differnece Sets A and B";
    }
}
