using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public sealed class TrainingGame : BaseGame
    {
        public TrainingGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer) 
            : base(0, TypeGame.Training)
        {
            PlayGame(firstPlayer, secondPlayer);
        }

        public override bool IsRatingForPlayer(BaseGameAccount gameAccount)
        {
            return false;
        }
    }
}