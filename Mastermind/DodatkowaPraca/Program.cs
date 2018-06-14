using System.Collections.Specialized;
using System.Configuration;
using GameLibrary;
using HighScore;

namespace DodatkowaPraca
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = ((NameValueCollection) ConfigurationManager.GetSection("ScoreClassConfig"))["ConnectionString"];
            var scoreManager = new ScoreManager(connectionString, 10);      

            var flow = new GameFlow(new MastermindGame(), null);        // Here u can choose the game

            flow.Run();
        }
    }
}
