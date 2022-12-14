using System.Text;
using Lab2_Inheritance.Games;

namespace Lab2_Inheritance.Accounts
{
    public class AccountGameHistory
    {
        private int Id { get; }
        private BaseGame.TypeGame Type { get; }
        private int CurrentRatingPlayer { get; }
        public enum ResultGame
        {
            Win,
            Lose
        }
        public ResultGame Result { get; }
        private BaseGameAccount Opponent { get; }
        public bool IsGameRating { get; }
        private int Rating { get; }
        private int _ratingOperation;
        public int RatingOperation
        {
            get => _ratingOperation;
            private set => _ratingOperation = CurrentRatingPlayer + value < 1 ? 1 - CurrentRatingPlayer : value;
        }

        public AccountGameHistory(int id, BaseGame.TypeGame type, int currentRatingPlayer, ResultGame result,
            BaseGameAccount opponent, bool isGameRating, int rating, int ratingOperation)
        {
            Id = id;
            Type = type;
            CurrentRatingPlayer = currentRatingPlayer;
            Result = result;
            Opponent = opponent;
            IsGameRating = isGameRating;
            Rating = rating;
            RatingOperation = ratingOperation;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"{Id}\t{Type}\t {Opponent.UserName}\t\t");
            if (IsGameRating)
            {
                str.AppendLine($"{Rating}\t\t{Result}\t\t{RatingOperation}");
            }
            else
            {
                str.AppendLine($"-\t\t{Result}\t\t-");
            }

            return str.ToString();
        }
    }
}