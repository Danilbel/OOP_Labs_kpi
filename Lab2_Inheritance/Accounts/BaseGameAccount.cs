using System.Collections.Generic;
using System.Text;
using Lab2_Inheritance.Games;

namespace Lab2_Inheritance.Accounts
{
    public class BaseGameAccount
    {
        public string UserName { get; }
        private int StartRating { get; }
        public enum TypesAccount
        {
            Base,
            HalfSave,
            SeriesWin
        }
        private TypesAccount TypeAccount { get; }
        protected readonly List<AccountGameHistory> AccountGameHistory = new List<AccountGameHistory>();
        private int GamesCount => AccountGameHistory.Count;
        protected int CurrentRating
        {
            get
            {
                int rating = StartRating;
                foreach (var item in AccountGameHistory)
                {
                    if (!item.IsGameRating) continue;
                    
                    rating += item.RatingOperation;
                }

                return rating;
            }
        }

        public BaseGameAccount(string name, int startRating, TypesAccount typeAccount = TypesAccount.Base)
        {
            UserName = name;
            StartRating = startRating;
            TypeAccount = typeAccount;
        }

        public virtual void WinGame(BaseGame game)
        {
            AccountGameHistory.Add(new AccountGameHistory(
                game.Id,
                game.Type,
                CurrentRating,
                Accounts.AccountGameHistory.ResultGame.Win,
                game.Loser,
                game.IsRatingForPlayer(this),
                game.Rating,
                game.Rating
            ));
        }

        public virtual void LoseGame(BaseGame game)
        {
            AccountGameHistory.Add(new AccountGameHistory(
                game.Id,
                game.Type,
                CurrentRating,
                Accounts.AccountGameHistory.ResultGame.Lose,
                game.Winner,
                game.IsRatingForPlayer(this),
                game.Rating,
                -game.Rating
            ));
        }

        public string GetStats()
        {
            StringBuilder str = new StringBuilder(
                    $"{UserName}'s stats:\nType Account: {TypeAccount}\nTotal games played: {GamesCount} | Player rating: {CurrentRating}");
            str.Append("\nIdGame\tTypeGame\t OpponentName\tRatingGame\tResultGame\tRatingOperation\n");
            foreach (var item in AccountGameHistory)
            {
                str.Append(item);
            }
            return str.ToString();
        }
    }
}