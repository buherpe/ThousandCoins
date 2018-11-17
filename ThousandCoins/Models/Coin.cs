using System;

namespace ThousandCoins.Models
{
    public class Coin
    {
        public SideOfTheCoin SideOfTheCoin { get; set; } = SideOfTheCoin.None;

        public Coin Flip(Random rnd)
        {
            if (rnd.Next(0, 2) == 0)
            {
                SideOfTheCoin = SideOfTheCoin.Heads;
                return this;
            }
            else
            {
                SideOfTheCoin = SideOfTheCoin.Tails;
                return this;
            }
        }
    }
}