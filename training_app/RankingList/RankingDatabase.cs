using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using System.IO;
using Aim_Trainer.GameData;

namespace Aim_Trainer.RankingList
{
    public class RankingDatabase
    {
        private readonly string databasePath;

        public RankingDatabase()
        {
            databasePath = CreateDataBasePath();
            CreateTableIfMissing();
        }
        private static string CreateDataBasePath()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folder = Path.Combine(localAppData, "Spiel");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "WholeList.db");
        }
        private  string ConnectionString => $"Data Source={databasePath}";
        public void CreateTableIfMissing()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Ranking (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT NOT NULL, Points INTEGER NOT NULL, Hitquote INTEGER NOT NULL, Award TEXT, PlayedAt TEXT NOT NULL, Difficulty TEXT NOT NULL)";
            command.ExecuteNonQuery();
        }

        public void Add(RankingEntry entry)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
            INSERT INTO Ranking (Username, Points, Hitquote, Award, PlayedAt, Difficulty)
            VALUES ($username, $points, $hitquote, $award, $playedAt, $difficulty)";
            command.Parameters.AddWithValue("$username", entry.Username);
            command.Parameters.AddWithValue("$points", entry.Score);
            command.Parameters.AddWithValue("$hitquote", entry.HitScoreInPercent);
            command.Parameters.AddWithValue("$award", entry.Extra ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("$playedAt", entry.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("$difficulty", entry.Difficulty.ToString());
            command.ExecuteNonQuery();
        }

        public List<RankingEntry> GetAll()
        {
            var entries = new List<RankingEntry>();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
            SELECT Username, Points, Hitquote, Award, PlayedAt, Difficulty
            FROM Ranking
            ORDER BY Points DESC";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                entries.Add(new RankingEntry
                {
                    Username = reader.GetString(0),
                    Score = reader.GetInt32(1),
                    HitScoreInPercent = reader.GetInt16(2),
                    Extra = reader.IsDBNull(3) ? null : reader.GetString(3),
                    CreationDate = DateTime.Parse(reader.GetString(4)),
                    Difficulty = Enum.Parse<GameSettings.Difficulty>(reader.GetString(5))
                });
            }
            return entries;
        }

        public List<RankingEntry> GetByDifficulty(GameSettings.Difficulty difficulty)
        {
            var entries = new List<RankingEntry>();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
            SELECT Username, Points, Hitquote, Award, PlayedAt, Difficulty
            FROM Ranking
            WHERE Difficulty = $difficulty
            ORDER BY Points DESC";

            command.Parameters.AddWithValue("$difficulty", difficulty.ToString());


            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                entries.Add(new RankingEntry
                {
                    Username = reader.GetString(0),
                    Score = reader.GetInt32(1),
                    HitScoreInPercent = reader.GetInt16(2),
                    Extra = reader.IsDBNull(3) ? null : reader.GetString(3),
                    CreationDate = DateTime.Parse(reader.GetString(4)),
                    Difficulty = Enum.Parse<GameSettings.Difficulty>(reader.GetString(5))
                });
            }
            return entries;
        }
    }
}
