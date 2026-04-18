using Dscret.Command.Base;

namespace Dscret.Command.RelationCommands
{
    public class ShowRelationCommand : Command<CommandContext>
    {
        public ShowRelationCommand(CommandContext? context) : base(context)
        {
        }

        public override void Execute(CommandContext context, string[] args)
        {
            if (context.CurrentRelation == null)
            {
                Console.WriteLine("Relation is noot loaded. Use command load");
                return;
            }

            context.CurrentRelation.PrintMatrix();
            context.CurrentRelation.PrintProperties();
            if (context.CurrentRelation.IsEquivalence())
                context.CurrentRelation.PrintEquivalenceClasses();

            if (context.CurrentRelation.IsPartianOrder())
                context.CurrentRelation.PrintOrderElements();

        }

        public override string GetHelp()
        {
            return "show - show current relation";
        }
    }
}
