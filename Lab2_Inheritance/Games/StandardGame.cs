using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public sealed class StandardGame : BaseGame
    {
        public StandardGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int rating)
             : base(rating)
        {
            TypeGame_ = TypeGame.Standard;
            PlayGame(firstPlayer, secondPlayer);
        }

        protected override void PlayGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer)
        {
            if (Random.Next(0, 2) == 0)
            {
                Winner = firstPlayer;
                Loser = secondPlayer;
            }
            else
            {
                Winner = secondPlayer;
                Loser = firstPlayer;
            }

            RatingOperationWinner = RatingGame;
            RatingOperationLoser = -RatingGame;
            
            Winner.WinGame(this);
            Loser.LoseGame(this);
        }

        public override bool IsRatingForPlayer(BaseGameAccount gameAccount)
        {
            return true;
        }
    }
}