using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GameLogic
    {
        public List<Player> player = new List<Player>();
        Board board = new Board();
        int turns;

        public void Initialize()
        {
            int playerinit = 0;
            while (playerinit < 2 || playerinit > 4)
            {
                Console.WriteLine("How many players (2-4)?");
                playerinit = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < playerinit; i++)
            {
                Console.WriteLine("Player " + (i + 1));
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Player playername = new Player(name);
                player.Add(playername);
            }
            Console.WriteLine("\nPlayers:");
            for (int i = 0; i < playerinit; i++)
            {
                Console.WriteLine("\n" + player[i].playerInfo());
            }
            Console.WriteLine("Press any key on your keyboard to continue!!!");
            Console.ReadKey(true);
        }

        public bool Win()
        {
            int compt2 = 0;
            Player playerwin = new Player();
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].money != 0) 
                { 
                    playerwin = player[i]; 
                    compt2++; 
                }
            }
            if (compt2 == 1) 
            { 
                winner = playerwin; 
                return true; 
            }
            int j = 0;
            foreach (Player p in players)
            {
                if (p.loser == false) { winner = p; j++; }
            }
            if (j == 1) 
            { 
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
