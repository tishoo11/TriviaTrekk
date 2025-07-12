using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaTrekk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions.csv");
            QuestionRepository repo = new QuestionRepository(filePath);

            Console.Write("Име на играч 1: ");
            string name1 = Console.ReadLine();
            Console.Write("Име на играч 2: ");
            string name2 = Console.ReadLine();

            Player p1 = new Player(name1);
            Player p2 = new Player(name2);

            Game game = new Game(repo, p1, p2);
            game.PlayInteractive();

            Console.WriteLine("Играта приключи. Натиснете клавиш за изход.");
            Console.ReadKey();
        }
    }
}
