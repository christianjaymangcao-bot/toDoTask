using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoTaskModels
{
    public class Data
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
