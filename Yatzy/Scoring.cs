using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yatzy
{
    public static class Scoring
    {
        public static int CheckNumberOfPoints(List<Tuple<int, string>> rolledDice, int diceNumber)
        {
            int score = 0;
            foreach (var dice in rolledDice)
            {
                if (dice.Item1 == diceNumber)
                {
                    score += dice.Item1;
                }
            }
            return score;
        }

        public static int CheckFullHouse(List<Tuple<int, string>> rolledDice)
        {
            var dices = rolledDice.Select(x => x.Item1).ToList();
            var sorted = dices.GroupBy(x => x).Where(c => c.Count() > 1).Select(y => new { Dice = y.Key, Counter = y.Count() }).ToList();
            if (sorted[0].Counter == 2 && sorted[1].Counter == 3 || sorted[0].Counter == 3 && sorted[1].Counter == 2)
            {
                return sorted[0].Counter * sorted[0].Dice + sorted[1].Counter * sorted[1].Dice;
            }
            return 0;
        }

        public static int CheckOnePair(List<Tuple<int, string>> rolledDice)
        {
            var dices = rolledDice.Select(x => x.Item1).ToList();
            var sorted = dices.GroupBy(x => x).Where(c => c.Count() > 1).Select(y => new { Dice = y.Key, Counter = y.Count() }).ToList();
            if(sorted[0].Counter == 2)
            {
                return sorted[0].Dice * 2;
            }
            return 0;
        }

        public static int CheckTwoPair(List<Tuple<int, string>> rolledDice)
        {
            var dices = rolledDice.Select(x => x.Item1).ToList();
            var sorted = dices.GroupBy(x => x).Where(c => c.Count() > 1).Select(y => new { Dice = y.Key, Counter = y.Count() }).ToList();
            if (sorted[0].Counter == 2 && sorted[1].Counter == 2)
            {
                return sorted[0].Dice * 2 + sorted[1].Dice * 2;
            }
            return 0;
        }

        public static int CheckThreeOfAKind(List<Tuple<int, string>> rolledDice)
        {
            var dices = rolledDice.Select(x => x.Item1).ToList();
            var sorted = dices.GroupBy(x => x).Where(c => c.Count() > 1).Select(y => new { Dice = y.Key, Counter = y.Count() }).ToList();
            if (sorted[0].Counter == 3)
            {
                return sorted[0].Dice * 3;
            }
            return 0;
        }

        public static int CheckFourOfAKind(List<Tuple<int, string>> rolledDice)
        {
            var dices = rolledDice.Select(x => x.Item1).ToList();
            var sorted = dices.GroupBy(x => x).Where(c => c.Count() > 1).Select(y => new { Dice = y.Key, Counter = y.Count() }).ToList();
            if (sorted[0].Counter == 4)
            {
                return sorted[0].Dice * 4;
            }
            return 0;
        }

        public static int CheckSmallStright(List<Tuple<int, string>> rolledDice)
        {
            for (int i = 1; i < 6; i++)
            {
                if (!rolledDice.Select(x => x.Item1).Contains(i))
                {
                    return 0; ;
                }
            }
            return 15;
        }

        public static int CheckLargeStright(List<Tuple<int, string>> rolledDice)
        {
            for (int i = 2; i < 7; i++)
            {
                if (!rolledDice.Select(x => x.Item1).Contains(i))
                {
                    return 0; ;
                }
            }
            return 20;
        }

        public static int CheckChance(List<Tuple<int, string>> rolledDice)
        {
            int score = 0;
            foreach (var dice in rolledDice)
            {
                score += dice.Item1;
            }
            return score;
        }
        public static int CheckYatzy(List<Tuple<int, string>> rolledDice)
        {
            var dices = rolledDice.Select(x => x.Item1).ToList();
            var sorted = dices.GroupBy(x => x).Where(c => c.Count() > 1).Select(y => new { Dice = y.Key, Counter = y.Count() }).ToList();
            if (sorted[0].Counter == 5)
            {
                return sorted[0].Dice * 5;
            }
            return 0;
        }
    }
}
