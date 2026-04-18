using Dscret.Command.Base;
using Dscret.Service;

namespace Dscret.Command.RelationCommands
{
    public class RelationUnionCommand : Command<CommandContext>
    {
        public RelationUnionCommand(CommandContext? context) : base(context)
        {
        }

        public override void Execute(CommandContext context, string[] args)
        {
            if (context.CurrentRelation == null)
            {
                Console.WriteLine("Relation is not loaded. Use load Command");
                return;
            }
            if (args.Length < 2)
            {
                Console.WriteLine("Error: specify file name with difference relation");
                return;
            }

            string filename = args[1];
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Error: file {filename} not found");
                return;
            }

            try
            {
                BinaryRelation other = new BinaryRelation(filename);
                BinaryRelation result = context.CurrentRelation.Union(other);
                Console.WriteLine("Union Relation:");
                result.PrintMatrix();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public override string GetHelp()
        {
            return "union <filename> - logical union with relation from file";
        }
    }
}
