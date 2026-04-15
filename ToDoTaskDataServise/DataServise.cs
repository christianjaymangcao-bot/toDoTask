using System;
using System.Collections.Generic;
using ToDoTaskModels;

namespace ToDoTaskDataServise
{
    public class DataService
    {
        public List<Data> ToDoList = new List<Data>();


        public void AddTask(Data data)
        {
            ToDoList.Add(data);
        }

        public List<Data> GetTasks()
        {
            return ToDoList;
        }
        public void UpdateStatus(int index, string newStatus)
        {
            if (index >= 0 && index < ToDoList.Count)
            {
                ToDoList[index].Status = newStatus;
            }
        }
        public void DeleteTask(int index)
        {
            if (index >= 0 && index < ToDoList.Count)
            {
                ToDoList.RemoveAt(index);
            }
        }

    }
}