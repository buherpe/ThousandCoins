using System;
using System.Collections.Generic;

namespace ThousandCoins.Models
{
    public class Person
    {
        public int Id { get; set; }
        public List<Coin> CoinHistory = new List<Coin>();
        public int HeadsCount { get; set; }
        public int TailsCount { get; set; }

        public Person(int id)
        {
            Id = id;
        }

        public void Flip(Random rnd)
        {
            var coin = new Coin();
            var result = coin.Flip(rnd);
            switch (result.SideOfTheCoin)
            {
                case SideOfTheCoin.Heads:
                    HeadsCount++;
                    break;
                case SideOfTheCoin.Tails:
                    TailsCount++;
                    break;
            }

            CoinHistory.Add(result);
        }
    }
}