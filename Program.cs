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
        }
    }
}
