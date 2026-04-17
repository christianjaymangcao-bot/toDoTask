using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ToDoTaskModels;

namespace ToDoTaskDataServise
{
    public class TaskDBData
    {
        private string connectionString =
        "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ToDoTask; Integrated Security=True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public TaskDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddTask(Data task)
        {
            var query = "INSERT INTO Tasks (TaskId, TaskName, Date, Status) VALUES (@TaskId, @TaskName, @Date, @Status)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@TaskId", task.TaskId);
            cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
            cmd.Parameters.AddWithValue("@Date", task.Date);
            cmd.Parameters.AddWithValue("@Status", task.Status);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Data> GetTasks()
        {
            var tasks = new List<Data>();

            string query = "SELECT TaskId, TaskName, Date, Status FROM Tasks";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new Data
                {
                    TaskId = Guid.Parse(reader["TaskId"].ToString()),
                    TaskName = reader["TaskName"].ToString(),
                    Date = reader["Date"].ToString(),
                    Status = reader["Status"].ToString()
                });
            }

            sqlConnection.Close();
            return tasks;
        }

        public void UpdateStatus(Guid id, string status)
        {
            var query = "UPDATE Tasks SET Status = @Status WHERE TaskId = @TaskId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@TaskId", id);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteTask(Guid id)
        {
            var query = "DELETE FROM Tasks WHERE TaskId = @TaskId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@TaskId", id);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}