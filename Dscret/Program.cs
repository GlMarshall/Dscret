using Dscret.Command;
using Dscret.Command.Base;
using Dscret.Interfaces;

namespace Dscret
{
    public class Program
    {
        static void Main(string[] args)
        {
            CommandContext context = new CommandContext();
            CommandFactory factory = new CommandFactory(context);

            Console.WriteLine("--- Program fro working with Sets ---");
            Console.WriteLine("Enter Command 'help', for view all Commands");
            Console.WriteLine();
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                input = input.Trim();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine($"Bye");
                }

                ICommand<CommandContext> command = factory.GetCommand(input);

                if (command != null)
                {
                    try
                    {
                        command.Execute(context, new string[] { input });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Command Execution Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Uknoun Command: Enter help for command List");
                }
            }
        }
    }
}
