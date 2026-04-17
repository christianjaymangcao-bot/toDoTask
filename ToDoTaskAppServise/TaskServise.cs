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
        //DataService dataService = new DataService();
        //JSONDataService dataService = new JSONDataService();
        TaskDBData dataService = new TaskDBData();

        public void AddTask(Data task)
        {
            dataService.AddTask(task);
        }

        public List<Data> GetTasks()
        {
            return dataService.GetTasks();
        }

        public void UpdateStatus(Guid id, string status)
        {
            dataService.UpdateStatus(id, status);
        }

        public void DeleteTask(Guid id)
        {
            dataService.DeleteTask(id);
        }
    }
}
