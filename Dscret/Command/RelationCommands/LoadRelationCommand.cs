using Dscret.Command.Base;
using Dscret.Service;

namespace Dscret.Command.RelationCommands
{
    public class LoadRelationCommand : Command<CommandContext>
    {
        public LoadRelationCommand(CommandContext context) : base(context) { }
        public override void Execute(CommandContext context, string[] args)
        {
            if (args.Length > 2)
            {
                Console.WriteLine("Error: Incorrect Filename");
                return;
            }

            string filename = args[1];
            if (!File.Exists(filename))
            {
                Console.WriteLine("Error: Filename does not exists");
            }

            try
            {
                BinaryRelation relation = new BinaryRelation(filename);
                context.CurrentRelation = relation;
                Console.WriteLine($"Relation Loads From file {filename}");
                relation.PrintMatrix();
                relation.PrintProperties();

                if (relation.IsEquivalence())
                {
                    relation.PrintEquivalenceClasses();
                }

                if (relation.IsPartianOrder())
                {
                    relation.PrintOrderElements();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Load Error: {ex.Message}");
            }
        }

        public override string GetHelp()
        {
            return "load <filename> - load relation from file";
        }
    }
}
