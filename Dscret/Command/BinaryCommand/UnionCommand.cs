using Dscret.Command.Base;

namespace Dscret.Command.BinaryCommand
{
    public class UnionCommand : BinaryOperationCommand
    {
        public UnionCommand(CommandContext context) : base(context) { }
        protected override string GetOperationSymbol() => "+";
        protected override string GetOperationName() => "Union";

        protected override SortedSet<char> Operate(SortedSet<char> setA, SortedSet<char> setB)
        {
            SortedSet<char> result = new SortedSet<char>(setA);
            result.UnionWith(setB);
            return result;
        }

        public override string GetHelp() => "A+B - Union A and B";
    }
}
