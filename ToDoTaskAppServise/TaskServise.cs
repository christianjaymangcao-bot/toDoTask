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
        JSONDataService dataService = new JSONDataService();

        public void AddTask(Data data)
        {
            dataService.AddTask(data);
        }

        public List<Data> GetTasks()
        {
            return dataService.GetTasks();
        }
        public void UpdateStatus(int index, string newStatus)
        {
            dataService.UpdateStatus(index, newStatus);
        }
        public void DeleteTask(int index)
        {
            dataService.DeleteTask(index);
        }

    }
}
