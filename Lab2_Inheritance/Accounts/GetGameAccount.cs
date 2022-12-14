namespace Lab2_Inheritance.Accounts
{
    public class GetGameAccount
    {
        public BaseGameAccount GetBaseGameAccount(string name, int startRating)
        {
            return new BaseGameAccount(name, startRating);
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