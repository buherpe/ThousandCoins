using System;

namespace ThousandCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random(0);
            var coinToss = new CoinToss(rnd);
            coinToss.FillPersons(1_000);

            coinToss.RecursiveFlip(coinToss.Persons);

            Console.WriteLine($"Top 3 people tossed heads:");
            foreach (var winner in coinToss.Top3)
            {
                Console.WriteLine($"  [Person {winner.Id}] Heads: {winner.HeadsCount}");
            }

            Console.ReadLine();
        }
    }
}