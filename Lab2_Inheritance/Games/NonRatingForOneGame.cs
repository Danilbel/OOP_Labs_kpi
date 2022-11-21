using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public sealed class NonRatingForOneGame : BaseGame
    {
        public NonRatingForOneGame(BaseGameAccount firstPlayerNonRating, BaseGameAccount secondPlayer, int rating) 
            : base(rating)
        {
            TypeGame = TypesGame.NonRatingForOne;
            PlayGame(firstPlayerNonRating, secondPlayer);
        }

        protected override void PlayGame(BaseGameAccount firstPlayerNonRating, BaseGameAccount secondPlayer)
        {
            if (Random.Next(0, 2) == 0)
            {
                Winner = firstPlayerNonRating;
                Loser = secondPlayer;
                RatingOperationWinner = 0;
                RatingOperationLoser = -RatingGame;
            }
            else
            {
                Winner = secondPlayer;
                Loser = firstPlayerNonRating;
                RatingOperationWinner = RatingGame;
                RatingOperationLoser = 0;
            }
            
            Winner.WinGame(this);
            Loser.LoseGame(this);
        }
    }
}