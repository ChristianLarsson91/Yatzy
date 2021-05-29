using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yatzy
{
    public class YatzyGame
    {
        List<Player> Players = new List<Player>();
        
        public YatzyGame(int NumberOfPlayers)
        {
            for (int i = 1; i <= NumberOfPlayers; i++)
            {
                Console.WriteLine("Enter name for player {0}", i.ToString());
                string Name = Console.ReadLine();
                Players.Add(new Player(Name));
            }

            foreach (var currentPlayer in Players)
            {
                Console.WriteLine("Player {0}", currentPlayer.Name);
                Console.WriteLine("------------------------------------");
                List<Tuple<int, string>> rolledDices = new List<Tuple<int, string>>();
                for (int i = 0; i < 3; i++)
                {
                    rolledDices = RollDices(5 - currentPlayer.SavedDice.Count);
                    rolledDices.AddRange(currentPlayer.SavedDice);
                    Console.WriteLine("You Rolled");
                    Display.DisplayDices(rolledDices);
                    if(i < 2)
                    {
                        Console.WriteLine("Which dice do you want to save?");
                        Console.WriteLine("Use the number keys to select. To finish press Enter");
                        SaveDice(currentPlayer,rolledDices);
                    }
                }

                int score = Score(rolledDices);
                Console.WriteLine("Score");
            }
        }        

        public static List<Tuple<int, string>> RollDices(int NumberOfDice)
        {
            var rand = new Random();
            List<Tuple<int, string>> Rolls = new List<Tuple<int, string>>();

            for (int i = 0; i < NumberOfDice; i++)
            {
                Rolls.Add(Tuple.Create(rand.Next(1, 7),"Not Selected"));
            }
            return Rolls;
        }

        public static void SaveDice(Player currentPlayer, List<Tuple<int, string>> rolledDices)
        {
            var key = Console.ReadKey();
            currentPlayer.ClearSavedDices();
            while (key.Key != ConsoleKey.Enter)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[0].Item2 != "Selected")
                        {
                            currentPlayer.SavedDice.Add(rolledDices[0]);
                            rolledDices[0] = Tuple.Create(rolledDices[0].Item1, "Selected");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choose, Try again or press Enter to finish");
                        }
                        break;
                    case ConsoleKey.D2:
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[1].Item2 != "Selected")
                        {
                            currentPlayer.SavedDice.Add(rolledDices[1]);
                            rolledDices[1] = Tuple.Create(rolledDices[1].Item1, "Selected");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choose, Try again or press Enter to finish");
                        }
                        break;
                    case ConsoleKey.D3:
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[2].Item2 != "Selected")
                        {
                            currentPlayer.SavedDice.Add(rolledDices[2]);
                            rolledDices[2] = Tuple.Create(rolledDices[2].Item1, "Selected");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choose, Try again or press Enter to finish");
                        }
                        break;
                    case ConsoleKey.D4:
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[3].Item2 != "Selected")
                        {
                            currentPlayer.SavedDice.Add(rolledDices[3]);
                            rolledDices[3] = Tuple.Create(rolledDices[3].Item1, "Selected");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choose, Try again or press Enter to finish");
                        }
                        break;
                    case ConsoleKey.D5:
                        if (rolledDices.Count >= Char.GetNumericValue(key.KeyChar) && rolledDices[4].Item2 != "Selected")
                        {
                            currentPlayer.SavedDice.Add(rolledDices[4]);
                            rolledDices[4] = Tuple.Create(rolledDices[4].Item1, "Selected");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choose, Try again or press Enter to finish");
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("--------------------------------------");
                Display.DisplayDices(rolledDices);
                key = Console.ReadKey();
            }
        }               

        public static int Score(List<Tuple<int, string>> rolledDice)
        {
            int score = 0;
            Boolean validChoose = false;
            while (!validChoose)
            {
                Console.WriteLine("Select combination");
                Console.WriteLine("1:Ones");
                Console.WriteLine("2:Twos");
                Console.WriteLine("3:Threes");
                Console.WriteLine("4:Fours");
                Console.WriteLine("5:Fives");
                Console.WriteLine("6:Six");
                Console.WriteLine("7:FullHouse");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        validChoose = true;
                        CheckNumberOfPoints(rolledDice,1);
                        break;
                    case ConsoleKey.D2:
                        validChoose = true;
                        CheckNumberOfPoints(rolledDice, 2);
                        break;
                    case ConsoleKey.D3:
                        validChoose = true;
                        CheckNumberOfPoints(rolledDice, 3);
                        break;
                    case ConsoleKey.D4:
                        validChoose = true;
                        CheckNumberOfPoints(rolledDice, 4);
                        break;
                    case ConsoleKey.D5:
                        validChoose = true;
                        CheckNumberOfPoints(rolledDice, 5);
                        break;
                    case ConsoleKey.D6:
                        validChoose = true;
                        CheckNumberOfPoints(rolledDice, 6);
                        break;
                    case ConsoleKey.D7:
                        validChoose = true;
                        rolledDice = new List<Tuple<int, string>>()
                        {
                            {Tuple.Create(1,"") },
                            {Tuple.Create(1,"") },
                            {Tuple.Create(1,"") },
                            {Tuple.Create(2,"") },
                            {Tuple.Create(2,"") },
                        };
                        CheckFullHouse(rolledDice);
                        break;
                    default:
                        Console.WriteLine("Invalid Choose");
                        break;
                }
            }
            return score;
        }

        public static int CheckNumberOfPoints(List<Tuple<int, string>> rolledDice,int diceNumber)
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
    }
}
