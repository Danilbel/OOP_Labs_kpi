namespace Lab2_Inheritance.Accounts
{
    public class GetGameAccount
    {
        public BaseGameAccount GetStandardGameAccount(string name, int startRating)
        {
            return new StandardGameAccount(name, startRating);
        }
        
        public BaseGameAccount GetHalfSaveGameAccount(string name, int startRating)
        {
            return new HalfSaveGameAccount(name, startRating);
        }
        
        public BaseGameAccount GetSeriesWinGameAccount(string name, int startRating)
        {
            return new SeriesWinGameAccount(name, startRating);
        }
    }
}