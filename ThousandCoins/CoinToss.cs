using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ThousandCoins.Models;

namespace ThousandCoins
{
    public class CoinToss
    {
        public List<Person> Persons = new List<Person>();
        public IEnumerable<Person> Top3;

        private Random _rnd;
        private int _counterPersonId;
        private int _counterTossId;

        public CoinToss()
        {
            _rnd = new Random();
        }

        public CoinToss(Random rnd)
        {
            _rnd = rnd;
        }

        public void RecursiveFlip(List<Person> persons)
        {
            Console.WriteLine($"Toss id: {_counterTossId++}. Tossing a coin...");

            foreach (var person in persons)
            {
                person.Flip(_rnd);
            }

            var personsWithHeads = persons
                .Where(p => p.CoinHistory
                                .Last()
                                .SideOfTheCoin == SideOfTheCoin.Heads)
                .ToList();

            Console.WriteLine($"Number of persons with Heads: {personsWithHeads.Count}");

            if (personsWithHeads.Count > 1)
            {
                Console.WriteLine($"------------------------------------");
                RecursiveFlip(personsWithHeads);
            }
            else
            {
                _counterTossId = 0;

                Top3 = Persons
                    .OrderByDescending(p => p.HeadsCount)
                    .Take(3);

                Console.WriteLine($"====================================");
            }
        }

        public void FillPersons(int count)
        {
            _counterPersonId = 0;
            Persons.Clear();
            for (int i = 0; i < count; i++)
            {
                Persons.Add(new Person(_counterPersonId++));
            }
        }
    }
}