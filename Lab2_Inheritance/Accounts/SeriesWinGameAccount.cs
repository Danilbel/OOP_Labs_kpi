using System.Linq;
using Lab2_Inheritance.Games;

namespace Lab2_Inheritance.Accounts
{
    public class SeriesWinGameAccount : BaseGameAccount
    {
        private double CoefficientSeriesWin
        {
            get
            {
                double coefficient = 1;
                AccountGameHistory.Reverse();
                foreach (var item in AccountGameHistory)
                {
                    if (!item.IsGameRating) continue;
                    if (item.Result == Accounts.AccountGameHistory.ResultGame.Lose) break;

                    coefficient += 0.1;
                }

                AccountGameHistory.Reverse();
                return coefficient;
            }
        }

        public SeriesWinGameAccount(string name, int startRating)
            : base(name, startRating, TypesAccount.SeriesWin)
        {
        }

        public override void WinGame(BaseGame game)
        {
            AccountGameHistory.Add(new AccountGameHistory(
                game.Id,
                game.Type,
                CurrentRating,
                Accounts.AccountGameHistory.ResultGame.Win,
                game.Loser,
                game.IsRatingForPlayer(this),
                game.Rating,
                (int)(game.Rating * CoefficientSeriesWin)
            ));
        }
        
    }
}