using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaTrekk
{
    public class Game
    {
        QuestionRepository repo;
        Player[] players;
        int currentPlayerIndex;
        Random random = new Random();
        int Finish = 50;

        public Game(QuestionRepository repository, Player p1, Player p2)
        {
            repo = repository;
            players = new Player[] { p1, p2 };
            currentPlayerIndex = 0;
        }


        public void PlayInteractive()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Добре дошли в TriviaTrek! ===");
            Console.ResetColor();

            while (true)
            {
                Player currentPlayer = players[currentPlayerIndex];
                Console.WriteLine($"\nРед е на {currentPlayer.Name} (позиция: {currentPlayer.Position})");
                Console.WriteLine("Натиснете клавиш за да хвърлите зар.");
                Console.ReadKey(true);

                int roll = random.Next(1, 7); // хвърляне на зар 1–6
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{currentPlayer.Name} хвърли {roll}.");
                Console.ResetColor();

                int difficulty = 1;
                if (roll == 1 || roll == 2) difficulty = 1;
                else if (roll == 3 || roll == 4) difficulty = 2;
                else if (roll >= 5 || roll <= 6) difficulty = 3;


            }

        }

    }
}
