using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IdentifiableObject
{
    public class CommandProcessor : Command
    {
        List<Command> commands;
        public CommandProcessor() : base(new string[] { "a command" })
        {
            commands = new List<Command>();
            commands.Add(new LookCommand());
            commands.Add(new MoveCommand());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command command in commands)
            {
                if (command.AreYou(text[0].ToLower()))
                {
                    return command.Execute(p, text);
                }
            }
            return "Error: Something wrong with the command - Command processor.";
        }
    }
}
