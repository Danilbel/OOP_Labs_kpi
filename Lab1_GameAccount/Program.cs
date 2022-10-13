using System;

namespace Lab1_GameAccount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int startRating = random.Next(100, 151);
            GameAccount bob = new GameAccount("Bob", startRating);
            GameAccount tom = new GameAccount("Tom", startRating);
            GameAccount rob = new GameAccount("Rob", startRating);

            for (int i = 0; i < 8; i++)
            {
                var game = random.Next(0, 3);
                if (game == 0)
                {
                    Game.PlayGame(bob, tom, random);
                }
                else if (game == 1)
                {
                    Game.PlayGame(bob, rob, random);
                }
                else
                {
                    Game.PlayGame(rob, tom, random);
                }
            }

            Console.WriteLine(bob.GetStats() + "\n" + rob.GetStats() + "\n" + tom.GetStats());
        }
    }
}