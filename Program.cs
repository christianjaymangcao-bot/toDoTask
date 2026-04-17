using System;
using System.Collections.Generic;
using ToDoTaskModels;
using ToDoTaskAppServise;

namespace toDoTask
{
    internal class Program
    {
        static TaskService taskService = new TaskService();

        static List<Data> cachedTasks = new List<Data>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== TASK MANAGEMENT =====");
                Console.WriteLine("A - Add Task");
                Console.WriteLine("B - View Tasks");
                Console.WriteLine("C - Change Status");
                Console.WriteLine("D - Delete Task");
                Console.WriteLine("E - Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "A":
                        AddTask();
                        break;

                    case "B":
                        ViewTask();
                        break;

                    case "C":
                        ChangeStatus();
                        break;

                    case "D":
                        DeleteTask();
                        break;

                    case "E":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        
        static void AddTask()
        {
            Console.Write("Task: ");
            string task = Console.ReadLine();

            Console.Write("Date: ");
            string date = Console.ReadLine();

            taskService.AddTask(new Data
            {
                TaskId = Guid.NewGuid(),
                TaskName = task,
                Date = date,
                Status = "Pending"
            });

            Console.WriteLine("Task added!");
        }

        
        static void ViewTask()
        {
            cachedTasks = taskService.GetTasks();

            Console.WriteLine("\n--- TASK LIST ---");

            if (cachedTasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            for (int i = 0; i < cachedTasks.Count; i++)
            {
                var t = cachedTasks[i];

                Console.WriteLine(
                    (i + 1) + ". " +
                    "ID: " + t.TaskId + " | " +
                    t.TaskName + " | " +
                    t.Date + " | " +
                    t.Status
                );
            }
        }

        static void ChangeStatus()
        {
            ViewTask();

            if (cachedTasks.Count == 0)
                return;

            Console.Write("\nSelect task number: ");
            int index = int.Parse(Console.ReadLine());

            if (index < 1 || index > cachedTasks.Count)
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Console.WriteLine("1 - Pending");
            Console.WriteLine("2 - Ongoing");
            Console.WriteLine("3 - Done");

            string input = Console.ReadLine();
            string status = "";

            switch (input)
            {
                case "1":
                    status = "Pending";
                    break;

                case "2":
                    status = "Ongoing";
                    break;

                case "3":
                    status = "Done";
                    break;

                default:
                    Console.WriteLine("Invalid status!");
                    return;
            }

            Guid id = cachedTasks[index - 1].TaskId;

            taskService.UpdateStatus(id, status);

            Console.WriteLine("Status updated!");
        }

       
        static void DeleteTask()
        {
            ViewTask();

            if (cachedTasks.Count == 0)
                return;

            Console.Write("\nSelect task number to delete: ");
            int index = int.Parse(Console.ReadLine());

            if (index < 1 || index > cachedTasks.Count)
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Guid id = cachedTasks[index - 1].TaskId;

            taskService.DeleteTask(id);

            Console.WriteLine("Task deleted!");
        }
    }
}