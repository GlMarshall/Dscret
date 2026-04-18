using Dscret.Command.Base;
using Dscret.Service;

namespace Dscret.Command.RelationCommands
{
    public class RelationIntersesctionCommand : Command<CommandContext>
    {
        public RelationIntersesctionCommand(CommandContext? context) : base(context)
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
                BinaryRelation result = context.CurrentRelation.Intersection(other);
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
            return "intersect <filename> - logical intersection with relation from file";
        }
    }
}
