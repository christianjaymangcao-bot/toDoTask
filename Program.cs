using System;
using System.Collections.Generic;
using ToDoTaskModels;
using ToDoTaskAppServise;

namespace toDoTask
{
    internal class Program
    {
        static TaskService taskService = new TaskService();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nTask Management");
                Console.WriteLine("A - Add Task");
                Console.WriteLine("B - View Tasks");
                Console.WriteLine("C - Change Status");
                Console.WriteLine("D - Delete Task");
                Console.WriteLine("E - Exit");
                Console.Write("Choose from the menu: ");
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
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
                        Exit();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Task to Do: ");
            string task = Console.ReadLine();

            Console.Write("Date: ");
            string date = Console.ReadLine();

            Data newTask = new Data()
            {
                TaskName=task,
                Date=date
            };

            taskService.AddTask(newTask);

            Console.WriteLine("Task added successfully!");
        }

        static void ViewTask()
        {
            List<Data> tasks = taskService.GetTasks();

            Console.WriteLine("\n--- Task List ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                int i = 1;
                foreach (var task in tasks)
                {
                    Console.WriteLine($"{i}. Task: {task.TaskName}, Date: {task.Date},Status: {task.Status}");
                    i++;
                }
            }
        }
        static void ChangeStatus()
        {
            List<Data> tasks = taskService.GetTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("\n--- Task List ---");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].TaskName} - {tasks[i].Status}");
            }

            Console.Write("\nEnter task number to update: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > tasks.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine("\nSelect new status:");
            Console.WriteLine("1 - Pending");
            Console.WriteLine("2 - Ongoing");
            Console.WriteLine("3 - Done");
            Console.Write("Enter choice: ");

            string input = Console.ReadLine();
            string newStatus = "";

            switch (input)
            {
                case "1":
                    newStatus = "Pending";
                    break;
                case "2":
                    newStatus = "Ongoing";
                    break;
                case "3":
                    newStatus = "Done";
                    break;
                default:
                    Console.WriteLine("Invalid status.");
                    return;
            }

            
            taskService.UpdateStatus(index - 1, newStatus);

            Console.WriteLine("Status updated successfully!");
        }
        static void DeleteTask()
        {
            List<Data> tasks = taskService.GetTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("\n--- Task List ---");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].TaskName} - {tasks[i].Status}");
            }

            Console.Write("\nEnter task number to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > tasks.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            taskService.DeleteTask(index - 1);

            Console.WriteLine("Task deleted successfully!");
        }

        static void Exit()
        {
            Console.WriteLine("Exiting program...");
            Environment.Exit(0);
        }
    }
}