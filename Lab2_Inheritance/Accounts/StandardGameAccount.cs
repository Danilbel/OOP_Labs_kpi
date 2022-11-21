using System;
using Lab2_Inheritance.Games;

namespace Lab2_Inheritance.Accounts
{
    public class StandardGameAccount : BaseGameAccount
    {
        public StandardGameAccount(string name, int startRating)
            : base(name, startRating)
        {
            TypeAccount = TypesAccount.Standard;
        }

        public override void WinGame(BaseGame game)
        {
            AccountGameHistory.Add(game);
        }

        public override void LoseGame(BaseGame game)
        {
            game.RatingOperationLoser = CheckRatingOperation(game.RatingOperationLoser);
            AccountGameHistory.Add(game);
        }
    }
}