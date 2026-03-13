using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoTaskDataServise;
using ToDoTaskModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoTaskAppServise
{
    public class TaskService
    {
        DataServise dataService = new DataServise();

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
