namespace Lab1_GameAccount
{
    public class AccountGameHistory
    {
        public enum ResultGame
        {
            Win,
            Lose
        }

        public Game Game { get; }
        public ResultGame Result { get; }
        public int RatingOperation { get; }

        public AccountGameHistory(Game game, ResultGame resultGame, int ratingOperation)
        {
            Game = game;
            Result = resultGame;
            RatingOperation = ratingOperation;
        }
    }
}