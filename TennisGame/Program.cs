using TennisGame.API;

namespace TennisGame
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var tennisGame = new API.TennisGame("player1", "player2");

            string[] pointsOrder = {"player1", "player1", "player2", "player2", "player1", "player1"};

            foreach (var playerName in pointsOrder)
            {
                tennisGame.AddOnePointToPlayer(playerName);
                tennisGame.PrintScore();
            }
        }
    }
}