using Lab2_Inheritance.Accounts;

namespace Lab2_Inheritance.Games
{
    public class GetGame
    {
        public BaseGame GetStandardGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer, int rating)
        {
            return new StandardGame(firstPlayer, secondPlayer, rating);
        }
        
        public BaseGame GetTrainingGame(BaseGameAccount firstPlayer, BaseGameAccount secondPlayer)
        {
            return new TrainingGame(firstPlayer, secondPlayer);
        }

        public BaseGame GetNonRatingForOneGame(BaseGameAccount firstPlayerNonRating, BaseGameAccount secondPlayer, int rating)
        {
            return new NonRatingForOneGame(firstPlayerNonRating, secondPlayer, rating);
        }
    }
}