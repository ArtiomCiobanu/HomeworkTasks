using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisGameRefactor.API
{
    public class TennisGame
    {
        private Dictionary<string, Player> Players { get; }

        private ScoreCounter _scoreCounter;

        private ScoreCounter ScoreCounter
        {
            get
            {
                if (_scoreCounter == null)
                {
                    _scoreCounter = new ScoreCounter(Players);
                }

                return _scoreCounter;
            }
        }


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

        public void IncreasePlayerScore(string name)
        {
            ScoreCounter.IncreasePlayerScore(name);
        }

        public void PrintScore()
        {
            int leadingPlayerScore = Players.First().Value.Score;

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

                if (leadingPlayerScore < player.Score)
                {
                    leadingPlayerScore = player.Score;
                }
            }

            var leadingPlayers =
                Players.Where(p => p.Value.Score == leadingPlayerScore).Select(pair => pair.Value).ToArray();
            var lastLeadingPlayer = leadingPlayers.Last();

            if (leadingPlayers.Count() > 1)
            {
                Console.Write("The following playes equally are the best: ");
                foreach (var player in leadingPlayers)
                {
                    Console.Write($"{player.Name}");
                    if (player != lastLeadingPlayer)
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine($"{leadingPlayers.First().Name} has advantage!");
            }
        }
    }
}