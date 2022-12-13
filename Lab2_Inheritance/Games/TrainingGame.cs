using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public sealed class TrainingGame : BaseGame
    {
        public TrainingGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer) 
            : base(0)
        {
            TypeGame_ = TypeGame.Training;
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

            RatingOperationWinner = 0;
            RatingOperationLoser = 0;
            
            Winner.WinGame(this);
            Loser.LoseGame(this);
        }

        public override bool IsRatingForPlayer(BaseGameAccount gameAccount)
        {
            return false;
        }
    }
}