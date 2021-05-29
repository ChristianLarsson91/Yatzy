using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Yatzy.YatzyGame;

namespace Yatzy
{
    public class YatzyGame : IUserInput
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
            while(Players[0].combinations.Count != 0)
            {
                foreach (var currentPlayer in Players)
                {
                    Console.WriteLine("Player {0}", currentPlayer.Name);
                    Console.WriteLine("Current score : {0}",currentPlayer.TotalScore);
                    Console.WriteLine("------------------------------------");
                    foreach (var combination in currentPlayer.combinations)
                    {
                        Console.WriteLine(combination.Value);
                    }
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

                    int score = Score(rolledDices,currentPlayer);
                    Console.WriteLine("\nScore {0}",score);
                    currentPlayer.TotalScore += score; 
                    GetInput();
                }
            }
            var winner = Players.OrderByDescending(i => i.TotalScore).First();
            Console.WriteLine("Winner is {0} with a score of {1}", winner.Name, winner.TotalScore);

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

        public void SaveDice(Player currentPlayer, List<Tuple<int, string>> rolledDices)
        {
            var key = GetInput();
            currentPlayer.ClearSavedDices();
            while (key.Key != ConsoleKey.Enter)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[0].Item2 != "Selected" && currentPlayer.combinations.ContainsKey(1))
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
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[1].Item2 != "Selected" && currentPlayer.combinations.ContainsKey(2))
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
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[2].Item2 != "Selected" && currentPlayer.combinations.ContainsKey(3))
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
                        if (rolledDices.Count > Char.GetNumericValue(key.KeyChar) && rolledDices[3].Item2 != "Selected" && currentPlayer.combinations.ContainsKey(4))
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
                        if (rolledDices.Count >= Char.GetNumericValue(key.KeyChar) && rolledDices[4].Item2 != "Selected" && currentPlayer.combinations.ContainsKey(5))
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
                Display.DisplayDices(rolledDices);
                key = GetInput();
            }
        }               

        public int Score(List<Tuple<int, string>> rolledDice, Player currentPlayer)
        {
            int score = 0;
            Boolean validChoose = false;
            while (!validChoose)
            {
                Console.WriteLine("Select combination");
                foreach (var combination in currentPlayer.combinations)
                {
                    Console.WriteLine(combination.Value);
                }
                var key = GetInput();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        validChoose = true;
                        score = Scoring.CheckNumberOfPoints(rolledDice,1);
                        currentPlayer.combinations.Remove(1);
                        break;
                    case ConsoleKey.D2:
                        validChoose = true;
                        score = Scoring.CheckNumberOfPoints(rolledDice, 2);
                        currentPlayer.combinations.Remove(2);
                        break;
                    case ConsoleKey.D3:
                        validChoose = true;
                        score = Scoring.CheckNumberOfPoints(rolledDice, 3);
                        currentPlayer.combinations.Remove(3);
                        break;
                    case ConsoleKey.D4:
                        validChoose = true;
                        score = Scoring.CheckNumberOfPoints(rolledDice, 4);
                        currentPlayer.combinations.Remove(4);
                        break;
                    case ConsoleKey.D5:
                        validChoose = true;
                        score = Scoring.CheckNumberOfPoints(rolledDice, 5);
                        currentPlayer.combinations.Remove(5);
                        break;
                    case ConsoleKey.D6:
                        validChoose = true;
                        score = Scoring.CheckNumberOfPoints(rolledDice, 6);
                        currentPlayer.combinations.Remove(6);
                        break;
                    case ConsoleKey.D7:
                        validChoose = true;
                        score = Scoring.CheckFullHouse(rolledDice);
                        currentPlayer.combinations.Remove(7);
                        break;
                    default:
                        Console.WriteLine("Invalid Choose");
                        break;
                }
            }
            return score;
        }
        

        public ConsoleKeyInfo GetInput()
        {
            return Console.ReadKey();
        }
    }

    public interface IUserInput
    {
        ConsoleKeyInfo GetInput();
    }
}
