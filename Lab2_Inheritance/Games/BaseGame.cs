using System;
using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public abstract class BaseGame
    {
        public enum TypeGame
        {
            Standard,
            NonRatingForOne,
            Training
        }
        
        protected static readonly Random Random = new Random();
        private static int _gameIndexSeed = 2345;
        public int IdGame { get; }
        public int RatingGame { get; }
        public BaseGameAccount Winner { get; protected set; }
        public BaseGameAccount Loser { get; protected set; }
        public int RatingOperationWinner { get; set; }
        public int RatingOperationLoser { get; set; }
        public TypeGame TypeGame_ { get; protected set; }
        
        protected BaseGame(int ratingGame)
        {
            CheckNegativeRating(ratingGame);
            RatingGame = ratingGame;
            IdGame = _gameIndexSeed++;
        }

        private void CheckNegativeRating(int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating played must be positive");
            }
        }

        protected abstract void PlayGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer);
        public abstract bool IsRatingForPlayer(BaseGameAccount gameAccount);
    }
}