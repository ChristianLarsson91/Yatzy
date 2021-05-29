using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public static class Display
    {
        private static Dictionary<int, string> DiceGraphic = new Dictionary<int, string>()
        {
            { 1,"-----\n|   |\n| o |\n|   |\n-----\n"},
            { 2,"-----\n|o  |\n|   |\n|  o|\n-----\n"},
            { 3,"-----\n|o  |\n| o |\n|  o|\n-----\n"},
            { 4,"-----\n|o o|\n|   |\n|o o|\n-----\n"},
            { 5,"-----\n|o o|\n| o |\n|o o|\n-----\n"},
            { 6,"-----\n|o o|\n|o o|\n|o o|\n-----\n"}
        };
        private static Dictionary<int, string> DiceGraphicSelected = new Dictionary<int, string>()
        {
            { 1,"-----\n|   |\n| o | <---\n|   |\n-----\n"},
            { 2,"-----\n|o  |\n|   | <---\n|  o|\n-----\n"},
            { 3,"-----\n|o  |\n| o | <---\n|  o|\n-----\n"},
            { 4,"-----\n|o o|\n|   | <---\n|o o|\n-----\n"},
            { 5,"-----\n|o o|\n| o | <---\n|o o|\n-----\n"},
            { 6,"-----\n|o o|\n|o o| <---\n|o o|\n-----\n"}
        };

        public static void DisplayDices(List<Tuple<int, string>> Dices)
        {
            Console.WriteLine("\n--------------------------------------");
            foreach (var dice in Dices)
            {
                if (dice.Item2 == "Selected")
                {
                    Console.WriteLine(DiceGraphicSelected[dice.Item1]);
                }
                else
                {
                    Console.WriteLine(DiceGraphic[dice.Item1]);
                }
            }
        }
    }
}
