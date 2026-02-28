using System;
using System.Reflection.Metadata.Ecma335;

namespace toDoTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
        

            List<string> toDolist = new List<string>();
            List<string> tasklist = new List<string>();
            List<string> dateList = new List<string>();

            Console.WriteLine("TAsk Management");
            Console.WriteLine("A - Add Task");
            Console.WriteLine("B - View");
            Console.WriteLine("C - Change Status");
            Console.WriteLine("D - Exit");


            Console.WriteLine("Choose from the menu: ");
            string choise = Console.ReadLine();





            switch (choise)
            {
                case "A":
                    Console.Write("Task to Do: ");
                    string TaskList = Console.ReadLine();
                    Console.WriteLine("Date: ");
                    string DateList = Console.ReadLine();

                    toDolist.Add($"taskList: {TaskList}, dateList: {DateList}");

                    foreach (var log in toDolist)
                    {
                        Console.WriteLine("log");
                    }

                    break;
                case "B":
                    Console.WriteLine("log");
                    break;
                case "C":

                    break;
                case "D":
                    Environment.Exit(0);
                    break;

            }




        }
    }
}
