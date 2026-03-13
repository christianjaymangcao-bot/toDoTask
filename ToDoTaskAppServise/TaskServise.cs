using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoTaskModels;
using ToDoTaskDataServise;


namespace ToDoTaskAppServise
{
    public class TaskService
    {
        DataService dataService = new DataService();

        public void AddTask(Data data)
        {
            dataService.AddTask(data);
        }

        public List<Data> GetTasks()
        {
            return dataService.GetTasks();
        }
    }
}
