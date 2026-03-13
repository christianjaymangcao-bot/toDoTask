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
    }
}