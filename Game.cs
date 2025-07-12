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
    }

}
