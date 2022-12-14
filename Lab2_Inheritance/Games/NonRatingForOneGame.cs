using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public sealed class NonRatingForOneGame : BaseGame
    {
        private bool IsRatingForWinner { get; set; }
        private bool IsRatingForLoser { get; set; }
        
        public NonRatingForOneGame(BaseGameAccount firstPlayerNonRating, BaseGameAccount secondPlayer, int rating) 
            : base(rating, TypeGame.NonRatingForOne)
        {
            PlayGame(firstPlayerNonRating, secondPlayer);
        }

        protected override void PlayGame(BaseGameAccount firstPlayerNonRating, BaseGameAccount secondPlayer)
        {
            if (Random.Next(0, 2) == 0)
            {
                Winner = firstPlayerNonRating;
                Loser = secondPlayer;
                
                IsRatingForWinner = false;
                IsRatingForLoser = true;
            }
            else
            {
                Winner = secondPlayer;
                Loser = firstPlayerNonRating;

                IsRatingForWinner = true;
                IsRatingForLoser = false;
            }
            
            SetResultGame();
        }

        public override bool IsRatingForPlayer(BaseGameAccount gameAccount)
        {
            if ((Winner == gameAccount && IsRatingForWinner) || (Loser == gameAccount && IsRatingForLoser))
            {
                return true;
            }

            return false;
        }
    }
}