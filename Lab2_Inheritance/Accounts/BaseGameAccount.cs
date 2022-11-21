using System.Collections.Generic;
using System.Text;
using Lab2_Inheritance.Games;

namespace Lab2_Inheritance.Accounts
{
    public abstract class BaseGameAccount
    {
        public enum TypesAccount
        {
            Standard,
            HalfSave,
            SeriesWin
        }
        protected readonly List<BaseGame> AccountGameHistory = new List<BaseGame>();
        public string UserName { get; set; }
        protected int StartRating { get; }
        public int CurrentRating
        {
            get
            {
                int rating = StartRating;
                foreach (var item in AccountGameHistory)
                {
                    rating += item.Winner.Equals(this) 
                        ? item.RatingOperationWinner 
                        : item.RatingOperationLoser;
                }

                return rating;
            }
        }
        public TypesAccount TypeAccount { get; set; }
        public int GamesCount => AccountGameHistory.Count;
        
        public BaseGameAccount(string name, int startRating)
        {
            UserName = name;
            StartRating = startRating;
        }

        public abstract void WinGame(BaseGame game);

        public abstract void LoseGame(BaseGame game);
        
        protected int CheckRatingOperation(int rating)
        {
            return CurrentRating + rating < 1
                ? 1 - CurrentRating
                : rating;
        }
        
        public string GetStats()
        {
            StringBuilder str =
                new StringBuilder(
                    $"{UserName}'s stats:\nType Account: {TypeAccount}\nTotal games played: {GamesCount} | Player rating: {CurrentRating}");
            str.Append("\nIdGame\tTypeGame\t OpponentName\tRatingGame\tResultGame\tRatingOperation\n");
            foreach (var item in AccountGameHistory)
            {
                string opponentName, resultGame, ratingOperation;
                if (item.Winner.Equals(this))
                {
                    opponentName = item.Loser.UserName;
                    resultGame = "Win";
                    ratingOperation = item.RatingOperationWinner == 0 
                        ? "" + item.RatingOperationWinner
                        : "+" + item.RatingOperationWinner;
                }
                else
                {
                    opponentName = item.Winner.UserName;
                    resultGame = "Lose";
                    ratingOperation = "" + item.RatingOperationLoser;
                }
                str.Append(
                    $"{item.IdGame}\t{item.TypeGame}\t {opponentName}\t\t{item.RatingGame}\t\t{resultGame}\t\t{ratingOperation}\n");
            }

            return str.ToString();
        }
    }
}