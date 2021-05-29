using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class Player
    {
        public List<Tuple<int, string>> SavedDice = new List<Tuple<int, string>>();
        public string Name;
        public Player(string name)
        {
            Name = name;
        }

        public void ClearSavedDices()
        {
            SavedDice = new List<Tuple<int, string>>();
        }
    }
}
