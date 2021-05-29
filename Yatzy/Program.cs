using System;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How Many Players Are There");
            int NumberOfPlayers = Int32.Parse(Console.ReadLine());
            new YatzyGame(NumberOfPlayers);
        }
    }
}
