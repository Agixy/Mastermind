using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Infrastructure;

namespace GameLibrary
{
    public class MastermindGame : IGame
    {
        public const int NumberOfColors = 8;

        private readonly ICollection<int> _riddle;


        public MastermindGame(int level = 4)
        {
            var rnd = new Random();

            var riddleList = new List<int>();

            for (int i = 0; i < level; i++)
            {
                riddleList.Add(rnd.Next(NumberOfColors));
            }

            _riddle = new ReadOnlyCollection<int>(riddleList);
        }

        /// <summary>
        /// Checks, if bet was right, if not, how near it was
        /// </summary>
        /// <param name="bet">Game bet in form of 4 digits from range 0..8</param>
        /// <param name="result">String, specifing, how near the bet is </param>
        /// <returns>True, if bet was right, otherwise falce</returns>
        public bool Guess(string bet, out string result)
        {
            ++Result;

            var betList = bet.Trim().Take(_riddle.Count).Select(c => c - '0').ToList();

            var map = betList.Zip(_riddle, (a, b) => a == b).ToList();
            var red = map.Count(b => b);

            var betAggregated = betList.Where((a, i) => !map[i]).GroupBy(a => a);
            var riddleAggregated = _riddle.Where((a, i) => !map[i]).GroupBy(a => a);

            var white = betAggregated.Join(riddleAggregated, b => b.Key, r => r.Key,
                    (a, b) => Math.Min(a.Count(), b.Count()))
                .Sum();

            result = $"Na swoim miejscu: {red}, na innym miescu: {white}";

            return red == _riddle.Count;
        }

        public int Result { get; private set; }
    }
}
