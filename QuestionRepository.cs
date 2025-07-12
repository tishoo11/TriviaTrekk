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
        }
    }
