using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public sealed class StandardGame : BaseGame
    {
        public StandardGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int rating)
             : base(rating, TypeGame.Standard)
        {
            PlayGame(firstPlayer, secondPlayer);
        }

        public override bool IsRatingForPlayer(BaseGameAccount gameAccount)
        {
            return true;
        }
    }
}