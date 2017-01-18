using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BricksInSpace
{
    class ScoreLog
    {
        private string timeStamp;
        private string[] tmpArrayOfScores;
        private string[] topFiveScores = new string[4];

        private List<String> listOfScores;

        public string PlayerName { get; set; }
        public int Score { get; set; }

        public ScoreLog()
        {
            listOfScores = new List<String>();
        }

        public void IncreaseScoreBy(int points)
        {
            Score += points;

            // Debug:
            timeStamp = DateTime.Now.ToLongTimeString();
            Console.WriteLine("{0}: Increased score by {1}.", timeStamp, points.ToString());
        }

        public void WriteScoresToFile()
        {
            using (StreamWriter file = new StreamWriter("scores.txt", true))
            {
                file.WriteLine("Score: {0} Name: {1}", Score, PlayerName);
            }
        }

        public void ReadAndSortScores()
        {
            tmpArrayOfScores = File.ReadAllLines("scores.txt");

            // TODO: 
            // - Split string array and parse to int ?
            // - Sort the scores (somehow)

            foreach (var item in tmpArrayOfScores)
            {
                Console.WriteLine(item);
            }
        }

    }
}
