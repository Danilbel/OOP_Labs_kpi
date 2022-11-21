using Lab2_Inheritance.Games;

namespace Lab2_Inheritance.Accounts
{
    public class HalfSaveGameAccount : BaseGameAccount
    {
        public HalfSaveGameAccount(string name, int startRating) 
            : base(name, startRating)
        {
            TypeAccount = TypesAccount.HalfSave;
        }

        public override void WinGame(BaseGame game)
        {
            AccountGameHistory.Add(game);
        }

        public override void LoseGame(BaseGame game)
        {
            game.RatingOperationLoser = CheckRatingOperation(game.RatingOperationLoser / 2);
            AccountGameHistory.Add(game);
        }
    }
}