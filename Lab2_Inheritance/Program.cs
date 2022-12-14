using System;
using System.Collections.Generic;
using Lab2_Inheritance.Accounts;
using Lab2_Inheritance.Games;

namespace Lab2_Inheritance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var getGameAccount = new GetGameAccount();
            var getGame = new GetGame();

            var accounts = new List<BaseGameAccount>
            {
                getGameAccount.GetBaseGameAccount("Danya", 100),
                getGameAccount.GetHalfSaveGameAccount("Vlad", 100),
                getGameAccount.GetSeriesWinGameAccount("Liza", 100)
            };
            
            // TrainingGame
            getGame.GetTrainingGame(accounts[0], accounts[1]);
            getGame.GetTrainingGame(accounts[1], accounts[2]);
            getGame.GetTrainingGame(accounts[2], accounts[0]);
            
            // StandardGame
            for (int i = 0; i < 2; i++)
            {
                getGame.GetStandardGame(accounts[0], accounts[1], 40);
                getGame.GetStandardGame(accounts[1], accounts[2], 30);
                getGame.GetStandardGame(accounts[2], accounts[0], 50);
            }
            
            // NonRatingForOneGame
            for (int i = 0; i < 2; i++)
            {
                getGame.GetNonRatingForOneGame(accounts[0], accounts[1], 40);
                getGame.GetNonRatingForOneGame(accounts[1], accounts[2], 30);
                getGame.GetNonRatingForOneGame(accounts[2], accounts[0], 50);
            }

            Console.WriteLine(accounts[0].GetStats() + "\n" + accounts[1].GetStats() + "\n" + accounts[2].GetStats());
        }
    }
}