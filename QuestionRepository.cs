using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaTrekk
{
    public class QuestionRepository
    {
        List<Questions> questions = new List<Questions>();
        Random random = new Random();

        public QuestionRepository(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length < 8) continue;

                questions.Add(new Questions
                {
                    ID = parts[0],
                    Text = parts[1],
                    Answers = new string[] { parts[2], parts[3], parts[4], parts[5] },
                    CorrectAnswer = int.Parse(parts[6]),
                    Crux = int.Parse(parts[7])
                });
            }

            public Questions GetRandomQuestionByDifficulty(int difficulty)
            {
                var filtered = questions.Where(q => q.Crux == difficulty).ToList();

                if (filtered.Count == 0)
                {
                    // fallback: ако няма въпроси от тази трудност, взимаме от всички
                    filtered = questions;
                }

                if (filtered.Count == 0)
                {
                    throw new InvalidOperationException("Няма останали въпроси.");
                }

                // Избираме случаен въпрос от филтрирания списък
                int index = random.Next(filtered.Count);
                Questions selected = filtered[index];

                // Премахваме го от оригиналния списък, за да не се повтаря
                questions.Remove(selected);

                return selected;
            }
        }
    }
