using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ToDoTaskModels;

namespace ToDoTaskDataServise
{
    public class JSONDataService
    {
        private List<Data> tasks = new List<Data>();
        private string _filePath;

        public JSONDataService()
        {
            _filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/tasks.json";
        }

        
        private void Load()
        {
            if (!File.Exists(_filePath))
            {
                tasks = new List<Data>();
                return;
            }

            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                tasks = new List<Data>();
                return;
            }

            tasks = JsonSerializer.Deserialize<List<Data>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<Data>();
        }

        
        private void Save()
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }

       
        public void AddTask(Data data)
        {
            Load();
            tasks.Add(data);
            Save();
        }

        
        public List<Data> GetTasks()
        {
            Load();
            return tasks;
        }

        
        public void UpdateStatus(int index, string status)
        {
            Load();

            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].Status = status;
                Save();
            }
        }

        
        public void DeleteTask(int index)
        {
            Load();

            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Save();
            }
        }
    }
}