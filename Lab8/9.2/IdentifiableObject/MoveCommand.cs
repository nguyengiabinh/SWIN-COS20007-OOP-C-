using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }
        public override string Execute(Player p, string[] text)
        {
            if (text[0] != "move" && text[0] != "go" && text[0] != "head" && text[0] != "leave")
            {
                return "Error in the first word input: \nFirst word allow: move, go, head, leave";
            }

            string _destination;

            switch (text.Length)
            {
                case 1:
                    return "Specify the destination!!!";

                case 2:
                    _destination = text[1].ToLower();
                    break;

                case 3:
                    _destination = text[2].ToLower();
                    break;
                default:
                    return "Only allow 3 words move input";
            }

            Path direction = p.Location.locatePath(_destination);
            if (direction != null)
            {
                p.Move(direction);
                return $"You are now in {direction.Target.Name}";
            }
            else
            {
                return "Something wrong with the direction!!!";
            }
        }
    }
}
