using System;
using System.Collections.Generic;
using ToDoTaskModels;

namespace ToDoTaskDataServise
{
    public class DataService
    {
        private List<Data> ToDoList = new List<Data>();

        
        public void AddTask(Data data)
        {
            ToDoList.Add(data);
        }

        
        public List<Data> GetTasks()
        {
            return ToDoList;
        }

        
        public void UpdateStatus(Guid id, string newStatus)
        {
            for (int i = 0; i < ToDoList.Count; i++)
            {
                if (ToDoList[i].TaskId == id)
                {
                    ToDoList[i].Status = newStatus;
                    break;
                }
            }
        }

        
        public void DeleteTask(Guid id)
        {
            for (int i = 0; i < ToDoList.Count; i++)
            {
                if (ToDoList[i].TaskId == id)
                {
                    ToDoList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}