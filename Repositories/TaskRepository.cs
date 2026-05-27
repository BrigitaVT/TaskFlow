using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using TaskFlow.Models;

namespace TaskFlow.Repositories
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string dbPath = "tasks.db")
        {
            _connectionString = $"Data Source={dbPath}";
        }

        public void EnsureDatabase()
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Tasks(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Description TEXT,
                    StartDate TEXT,
                    EndDate TEXT,
                    Status TEXT,
                    Priority TEXT,
                    UserName TEXT
                );";

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TaskItem> GetAll()
        {
            var list = new List<TaskItem>();

            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
    @"SELECT Id, Name, Description, StartDate, EndDate,
      Status, Priority, UserName
      FROM Tasks";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new TaskItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                StartDate = DateTime.Parse(reader.GetString(3)),
                                EndDate = DateTime.Parse(reader.GetString(4)),
                                Status = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                Priority = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                UserName = reader.IsDBNull(7) ? "" : reader.GetString(7)
                            };

                            list.Add(task);
                        }
                    }
                }
            }

            return list;
        }

        public void AddTask(TaskItem task)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"INSERT INTO Tasks 
                        (Name, Description, StartDate, EndDate, Status, Priority, UserName) 
                        VALUES 
                        ($name, $description, $start, $end, $status, $priority, $user)";

                    cmd.Parameters.AddWithValue("$name", task.Name ?? "");
                    cmd.Parameters.AddWithValue("$description", task.Description ?? "");
                    cmd.Parameters.AddWithValue("$start", task.StartDate.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("$end", task.EndDate.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("$status", task.Status ?? "");
                    cmd.Parameters.AddWithValue("$priority", task.Priority ?? "");
                    cmd.Parameters.AddWithValue("$user", task.UserName ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Atnaujina pasirinktą taską pagal ID
        public void UpdateTask(TaskItem task)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"UPDATE Tasks
                  SET Name = $name,
                      Description = $description,
                      StartDate = $start,
                      EndDate = $end,
                      Status = $status,
                      Priority = $priority,
                      UserName = $user
                  WHERE Id = $id";

                    cmd.Parameters.AddWithValue("$id", task.Id);
                    cmd.Parameters.AddWithValue("$name", task.Name ?? "");
                    cmd.Parameters.AddWithValue("$description", task.Description ?? "");
                    cmd.Parameters.AddWithValue("$start", task.StartDate.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("$end", task.EndDate.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("$status", task.Status ?? "");
                    cmd.Parameters.AddWithValue("$priority", task.Priority ?? "");
                    cmd.Parameters.AddWithValue("$user", task.UserName ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Ištrina pasirinktą taską pagal jo ID
        public void DeleteTask(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"DELETE FROM Tasks 
                          WHERE Id = $id";

                    cmd.Parameters.AddWithValue("$id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}