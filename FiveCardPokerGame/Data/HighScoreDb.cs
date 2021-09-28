﻿using FiveCardPokerGame.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.Data
{
    public class HighScoreDb : BaseViewModel
    {
        public static string dif { get; set; }

        public static void GetDifficulty(int difficulty)
        {
            if (Global.Difficulty == 1)
            {
                dif = "Hard";
            }
            else if (Global.Difficulty == 2)
            {
                dif = "Medium";
            }
            else if (Global.Difficulty == 3)
            {
                dif = "Easy";
            }
        }

        #region Create
        public void SetHighscore()
        {
            GetDifficulty(Global.Difficulty);

            string stmt = $"INSERT INTO highscore(score, player_id, difficulty) VALUES (@score, @player_id, @difficulty)";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@score", Global.EndScore);
                command.Parameters.AddWithValue("@player_id", Global.MyPlayer.PlayerId);
                command.Parameters.AddWithValue("@difficulty", dif);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                     Global.EndScore = (int)reader["score"];
                }  
            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t add highscore", ex);
            }           
        }

        #endregion

        #region Read
        public ObservableCollection<Highscore> GetHighscores()
        {            
            string stmt = $"SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = '{dif}' LIMIT 19";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                EndOfGameViewModel.HighscoreList = new ObservableCollection<Highscore>();
                Highscore highscore = new Highscore();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],                        
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]
                    };
                    EndOfGameViewModel.HighscoreList.Add(highscore);
                    
                }
                return EndOfGameViewModel.HighscoreList;
                
            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        public ObservableCollection<Highscore> GetEasyHighScore()
        {
            string stmt = "SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Easy'  ORDER BY score DESC LIMIT 19";


            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> easyList = new ObservableCollection<Highscore>();
                Highscore highscore = new Highscore();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"]
                    };
                    easyList.Add(highscore);
                }
                return easyList;
            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }
        public ObservableCollection<Highscore> GetHardHighScore()
        {
            string stmt = "SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Hard'  ORDER BY score DESC LIMIT 19";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> hardList = new ObservableCollection<Highscore>();
                Highscore highscore = new Highscore();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"]
                    };
                    hardList.Add(highscore);
                }
                return hardList;
            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }


        public ObservableCollection<Highscore> GetMediumHighScore()
        {
            string stmt = "SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Medium'  ORDER BY score DESC LIMIT 19";


            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> mediumList = new ObservableCollection<Highscore>();
                Highscore highscore = new Highscore();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"]
                    };
                    mediumList.Add(highscore);
                }
                return mediumList;
            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        #endregion
    }
}
