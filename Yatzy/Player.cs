using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class Player
    {
        public List<Tuple<int, string>> SavedDice = new List<Tuple<int, string>>();
        public Dictionary<int, string> combinations = new Dictionary<int,string>()
        {
            {1, "1:Ones" },
            {2, "2:Twos"},
            {3, "3:Threes"},
            {4, "4:Fours"},
            {5, "5:Fives"},
            {6, "6:Six"},
            {7, "7:FullHouse"}
        };
        public string Name;
        public int TotalScore;
        public Player(string name)
        {
            Name = name;
            TotalScore = 0;
        }

        public void ClearSavedDices()
        {
            SavedDice = new List<Tuple<int, string>>();
        }
    }
}
