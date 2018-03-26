using System;
using Infrastructure;

namespace DodatkowaPraca
{
    internal class GameFlow
    {
        private readonly IScoreManager _scoreManager;
        private readonly IGame _game;

        public GameFlow(IGame game, IScoreManager scoreManager)
        {
            _game = game;
            _scoreManager = scoreManager;
        }

        public void Run()
        {

            Console.Clear();
            Console.WriteLine("Podaj swoje imie:");
            var name = Console.ReadLine();

            bool result;
            do
            {
                Console.Write("Zgadnij: ");
                var bet = Console.ReadLine();

                result = _game.Guess(bet, out var answer);

                Console.WriteLine(answer);
            } while (!result);

            Console.WriteLine($"Wynik: {_game.Result}");

            if (_scoreManager == null)
                return;

            var highscoreEntry = new HighscoreEntry(name, _game.Result);
            _scoreManager.Add(highscoreEntry);

            Console.WriteLine("\nNAJLEPSZE WYNIKI:");
            foreach (var entry in _scoreManager.List())
            {
                Console.WriteLine(entry);
            }
        }
    }
}
