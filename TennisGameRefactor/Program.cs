using TennisGameRefactor.API;

namespace TennisGameRefactor
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var tennisGame = new TennisGame("player1", "player2");

            string[] pointsOrder = {"player1", "player2", "player2", "player2", "player1", "player1"};

            foreach (var playerName in pointsOrder)
            {
                tennisGame.IncreasePlayerScore(playerName);
                tennisGame.PrintScore();
            }
        }
    }
}