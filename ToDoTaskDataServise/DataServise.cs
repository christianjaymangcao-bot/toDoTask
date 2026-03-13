using System;
using System.Collections.Generic;
using System.Text;
using ToDoTaskModels;

namespace ToDoTaskDataServise
{
    public class DataServise
    {
        List<Data> ToDoList = new List<Data>();

        public void AddTask(Data task)
        {
            ToDoList.Add(task);
        }
        public List<Data> GetTasks()
        {
            return ToDoList;
        }

    }
}