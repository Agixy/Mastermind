using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace HighScore
{
    public class ScoreManager : IScoreManager
    {
        private readonly string _connectionString;
        private readonly int _howMany;

        public ScoreManager(string connectionString, int howMany)
        {
            _connectionString = connectionString;
            _howMany = howMany;
        }

        public HighscoreEntry[] List()
        {
            string connetionString = null;
            connetionString = _connectionString;

            using (var connection = new SqlConnection(connetionString))
            {
                connection.Open();

                using (var command = new SqlCommand($"SELECT TOP {_howMany} * FROM Highscore ORDER BY wynik;", connection))
                using (var dataReader = command.ExecuteReader())
                {
                    var lista = new List<HighscoreEntry>();
                    while (dataReader.Read())
                    {
                        var modelClass = new HighscoreEntry(dataReader.GetValue(1).ToString(), Convert.ToInt32(dataReader.GetValue(2).ToString()));
                        lista.Add(modelClass);
                    }
                    return lista.ToArray();
                }
            }
        }

        public void Add(HighscoreEntry entry)
        {
            string connetionString = null;
            connetionString = _connectionString;

            using (var connection = new SqlConnection(connetionString))
                using (var command = new SqlCommand("INSERT INTO Highscore VALUES (@b, @c);", connection))
                {
                    
                    command.Parameters.AddWithValue("@b", entry.Name);
                    command.Parameters.AddWithValue("@c", entry.Score);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                    
            
        }
    }
}
