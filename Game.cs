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


                // Подбор на въпрос по трудност
                Questions q = repo.GetRandomQuestionByDifficulty(difficulty);
                Console.WriteLine($"Въпрос (Трудност: {q.Crux}): {q.Text}");

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"{i + 1}. {q.Answers[i]}");
                }

                Console.Write("Вашият отговор (1–4): ");
                int answer;
                while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 4)
                {
                    Console.WriteLine("Невалиден отговор. Опитайте пак (1–4): ");
                }

                if ((answer - 1) == q.CorrectAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Верен отговор! Движите се напред.");
                    Console.ResetColor();
                    currentPlayer.Position += roll;

                }

                // Показваме текущите позиции
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n📍 Позиции:");

                foreach (Player p in players)
                {
                    string line = $"{p.Position,2} " + new string('-', p.Position) + $" {p.Name}";

                    Console.WriteLine(line);
                }

                Console.ResetColor();

                // Проверка за победа
                if (currentPlayer.Position >= 50)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n {currentPlayer.Name} печели играта!");
                    Console.ResetColor();
                    break;
                }

                // Играчът продължава хода си
                continue;

            }

           
        }

    }



    
}
