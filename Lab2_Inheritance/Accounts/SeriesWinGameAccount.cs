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
                for (int i = AccountGameHistory.Count - 1; i >= 0; i--)
                {
                    if (AccountGameHistory.ElementAt(i).Winner.Equals(this))
                    {
                        coefficient += 0.1;
                    }
                    else
                    {
                        break;
                    }
                }

                return coefficient;
            }
        }

        public SeriesWinGameAccount(string name, int startRating) 
            : base(name, startRating)
        {
            TypeAccount = TypesAccount.SeriesWin;
        }

        public override void WinGame(BaseGame game)
        {
            game.RatingOperationWinner = (int)(game.RatingOperationWinner * CoefficientSeriesWin);
            AccountGameHistory.Add(game);
        }
        
        public override void LoseGame(BaseGame game)
        {
            game.RatingOperationLoser = CheckRatingOperation(game.RatingOperationLoser);
            AccountGameHistory.Add(game);
        }
    }
}