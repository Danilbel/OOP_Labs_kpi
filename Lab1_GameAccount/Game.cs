using System;

namespace Lab1_GameAccount
{
    public class Game
    {
        private static int _gameIndexSeed = 2345;
        public int RatingGame { get; }
        public int IdGame { get; }
        public GameAccount Winner { get; }
        public GameAccount Loser { get; }

        public Game(GameAccount winner, GameAccount loser, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating played must be positive");
            }

            Winner = winner;
            Loser = loser;
            RatingGame = rating;
            IdGame = _gameIndexSeed++;
        }

        public static void PlayGame(GameAccount firstPlayer, GameAccount secondPlayer, Random random)
        {
            var rating = random.Next(10, 70);
            Game game = random.Next(0, 2) == 0
                ? new Game(firstPlayer, secondPlayer, rating)
                : new Game(secondPlayer, firstPlayer, rating);
            game.Winner.WinGame(game);
            game.Loser.LoseGame(game);
        }
    }
}