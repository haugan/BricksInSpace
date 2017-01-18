using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BricksInSpace
{
    class ScoreLogger
    {
        public int Score { get; set; }
        public string Name { get; set; }

        private List<ScoreLogger> scoresUnsorted;
        private List<ScoreLogger> scoresSorted;

        private int tmpScore;
        private string tmpName;
        private ScoreLogger tmpEntry;

        public ScoreLogger()
        {
            scoresUnsorted = new List<ScoreLogger>();
        }

        public void IncreaseScoreBy(int points)
        {
            Score += points;
        }

        public void DoWork()
        {
            // Gets current name from user input.
            Name = NameInput.staticName;

            // Method calls begin a chain of calls to write scores to file, 
            // read from that file, sort the scores using LINQ - and write them to a new file.
            WriteToUnsorted();
        }

        private void WriteToUnsorted()
        {
            using (StreamWriter file = new StreamWriter(@"scoresUnsorted.txt", true))
            {
                file.WriteLine($"{Score}:{Name}");
            }

            ReadSplitWriteToSorted();
        }

        private void ReadSplitWriteToSorted()
        {
            string[] tmpArray = File.ReadAllLines(@"scoresUnsorted.txt");
            foreach (string line in tmpArray)
            {
                tmpArray = line.Split(':');
                tmpScore = Int32.Parse(tmpArray[0]);
                tmpName = tmpArray[1];

                AddToSorting(tmpScore, tmpName);
            }

            SortAndWrite();
        }

        private void AddToSorting(int s, string n)
        {
            tmpEntry = new ScoreLogger() { Score = s, Name = n };
            scoresUnsorted.Add(tmpEntry);
        }

        private void SortAndWrite()
        {
            scoresSorted = scoresUnsorted.OrderByDescending(s => s.Score).ToList();
            foreach (var score in scoresSorted)
            {
                using (StreamWriter file = new StreamWriter(@"scoresSorted.txt", true))
                {
                    file.WriteLine($"{score.Score}:{score.Name.ToUpper()}");
                }
            }
        }

    }
}
