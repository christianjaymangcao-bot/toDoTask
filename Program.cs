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
                Console.WriteLine("D - Exit");
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
                       
                        break;
                    case "D":
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

            Data newTask = new Data
            {
                TaskName = task,
                Date = date
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
                    Console.WriteLine($"{i}. Task: {task.TaskName}, Date: {task.Date}");
                    i++;
                }
            }
        }

        static void Exit()
        {
            Console.WriteLine("Exiting program...");
            Environment.Exit(0);
        }
    }
}