using System;
using Infrastructure;

namespace GameLibrary
{
    public class GuessGame : IGame
    {
        private readonly int _number = new Random().Next(0,1001);

        public bool Guess(string bet, out string result)
        {
            Result++;

            var cmp = _number.CompareTo(Int32.Parse(bet));
            if (cmp > 0)
                result = "Więcej";
            else if (cmp < 0)
                result = "Mniej";
            else
            {
                result = "Zgadłeś";
                return true;
            }
            return false;
        }

        public int Result { get; private set; }
    }
}
