using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisGame.API
{
    public class TennisGame
    {
        private Dictionary<string, Player> Players { get; }

        public TennisGame(Player player1, Player player2)
        {
            Players = new Dictionary<string, Player>()
            {
                {player1.Name, player1},
                {player2.Name, player2}
            };
        }

        public TennisGame(string firstPlayerName, string secondPlayerName)
        {
            Players = new Dictionary<string, Player>()
            {
                {firstPlayerName, new Player(firstPlayerName)},
                {secondPlayerName, new Player(secondPlayerName)}
            };
        }

        public void AddOnePointToPlayer(string name)
        {
            if (Players.ContainsKey(name))
            {
                Players[name].AddOnePoint();
            }
        }

        public void PrintScore()
        {
            Player leadingPlayer = Players.First().Value;
            var lastPlayerName = Players.Last().Key;
            foreach (var (playerName, player) in Players)
            {
                Console.Write(player.Score);
                if (playerName != lastPlayerName)
                {
                    Console.Write(" : ");
                }
                else
                {
                    Console.WriteLine();
                }

                if (leadingPlayer.Score < player.Score)
                {
                    leadingPlayer = player;
                }
            }

            Console.WriteLine($"{leadingPlayer.Name} has advantage!");
        }
    }
}