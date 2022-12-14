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
        public int Id { get; }
        
        private int _rating;
        public int Rating
        {
            get => _rating;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The rating played must be positive");
                }

                _rating = value;
            }
        }

        public BaseGameAccount Winner { get; protected set; }
        public BaseGameAccount Loser { get; protected set; }
        public TypeGame Type { get; }
        
        protected BaseGame(int rating, TypeGame type)
        {
            Rating = rating;
            Id = _gameIndexSeed++;
            Type = type;
        }

        protected virtual void PlayGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer)
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
            
            SetResultGame();            
        }

        protected void SetResultGame()
        {
            Winner.WinGame(this);
            Loser.LoseGame(this);
        }
        
        public abstract bool IsRatingForPlayer(BaseGameAccount gameAccount);
    }
}