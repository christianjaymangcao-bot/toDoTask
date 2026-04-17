using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ToDoTaskModels;

namespace ToDoTaskDataServise
{
    public class TaskJsonData
    {
        private string filePath = "tasks.json";

        private List<Data> tasks = new List<Data>();

        public TaskJsonData()
        {
            LoadFromFile();
        }

        
        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            string json = File.ReadAllText(filePath);

            tasks = JsonSerializer.Deserialize<List<Data>>(json) ?? new List<Data>();
        }

        
        private void SaveToFile()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

      
        public void AddTask(Data task)
        {
            tasks.Add(task);
            SaveToFile();
        }

        
        public List<Data> GetTasks()
        {
            LoadFromFile();
            return tasks;
        }

    
        public void UpdateStatus(Guid id, string status)
        {
            LoadFromFile();

            var task = tasks.Find(t => t.TaskId == id);

            if (task != null)
            {
                task.Status = status;
                SaveToFile();
            }
        }

        
        public void DeleteTask(Guid id)
        {
            LoadFromFile();

            tasks.RemoveAll(t => t.TaskId == id);

            SaveToFile();
        }
    }
}