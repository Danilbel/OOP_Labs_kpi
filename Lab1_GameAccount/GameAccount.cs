using System.Collections.Generic;
using System.Text;

namespace Lab1_GameAccount
{
    public class GameAccount
    {
        private readonly List<AccountGameHistory> _accountGameHistory = new List<AccountGameHistory>();
        public string UserName { get; }
        private int StartRating { get; }

        public int CurrentRating
        {
            get
            {
                int rating = StartRating;
                foreach (var item in _accountGameHistory)
                {
                    rating += item.RatingOperation;
                }

                return rating;
            }
        }

        public int GamesCount => _accountGameHistory.Count;

        public GameAccount(string name, int startRating)
        {
            UserName = name;
            StartRating = startRating;
        }

        public void WinGame(Game game)
        {
            _accountGameHistory.Add(new AccountGameHistory(game, AccountGameHistory.ResultGame.Win, game.RatingGame));
        }

        public void LoseGame(Game game)
        {
            _accountGameHistory.Add(new AccountGameHistory(game, AccountGameHistory.ResultGame.Lose,
                CurrentRating - game.RatingGame < 1 ? 1 - CurrentRating : -game.RatingGame));
        }

        public string GetStats()
        {
            StringBuilder str =
                new StringBuilder(
                    $"{UserName}'s stats:\nTotal games played: {GamesCount} | Player rating: {CurrentRating}");
            str.Append("\nIdGame\tOpponentName\tRatingGame\tResultGame\tRatingOperation\n");
            foreach (var item in _accountGameHistory)
            {
                string opponentName = item.Result == AccountGameHistory.ResultGame.Win
                    ? item.Game.Loser.UserName
                    : item.Game.Winner.UserName;
                string ratingOperation =
                    item.RatingOperation > 0 ? "+" + item.RatingOperation : "" + item.RatingOperation;
                str.Append(
                    $"{item.Game.IdGame}\t{opponentName}\t\t{item.Game.RatingGame}\t\t{item.Result}\t\t{ratingOperation}\n");
            }

            return str.ToString();
        }
    }
}