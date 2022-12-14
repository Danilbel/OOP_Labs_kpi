using Lab2_Inheritance.Games;

namespace Lab2_Inheritance.Accounts
{
    public class HalfSaveGameAccount : BaseGameAccount
    {
        public HalfSaveGameAccount(string name, int startRating) 
            : base(name, startRating, TypesAccount.HalfSave)
        {
        }

        public override void LoseGame(BaseGame game)
        {
            AccountGameHistory.Add(new AccountGameHistory(
                game.Id,
                game.Type,
                CurrentRating,
                Accounts.AccountGameHistory.ResultGame.Lose,
                game.Winner,
                game.IsRatingForPlayer(this),
                game.Rating,
                -game.Rating / 2
            ));
        }
    }
}