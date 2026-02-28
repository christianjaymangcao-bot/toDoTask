using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace toDoTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool running = true;

                List<string> toDoList = new List<string>();

                while (running)
                {
                    Console.WriteLine("\nTask Management");
                    Console.WriteLine("A - Add Task");
                    Console.WriteLine("B - View Tasks");
                    Console.WriteLine("C - Change Status");
                    Console.WriteLine("D - Exit");

                    Console.Write("Choose from the menu: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "A":
                            Console.Write("Task to Do: ");
                            string task = Console.ReadLine();

                            Console.Write("Date: ");
                            string date = Console.ReadLine();

                            toDoList.Add($"Task: {task}, Date: {date}");
                            Console.WriteLine("Task added successfully!");
                            break;

                        case "B":
                            Console.WriteLine("\n--- Task List ---");
                            if (toDoList.Count == 0)
                            {
                                Console.WriteLine("No tasks available.");
                            }
                            else
                            {
                                foreach (var log in toDoList)
                                {
                                    Console.WriteLine(log);
                                }
                            }
                            break;

                        case "C":
                          
                            break;

                        case "D":
                            running = false;
                            Console.WriteLine("Exiting program...");
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
        }
    }

