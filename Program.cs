using System;
using System.Reflection.Metadata.Ecma335;

namespace toDoTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string taskList;
            string dateList;
           
            List<string> toDolist = new List<string>();

            Console.WriteLine("TAsk Management");
            Console.WriteLine("A - Add Task");
            Console.WriteLine("B - View");
            Console.WriteLine("C - Exit");
            Console.WriteLine("D - Change Status");
            

            Console.WriteLine("Choose from the menu: ");
            string choise = Console.ReadLine();

            switch (choise)
            {
                case "A":
                    Console.Write("Task to Do: ");
                    string task = Console.ReadLine();
                    Console.WriteLine("Date: ");
                    string date = Console.ReadLine();

                    toDolist.Add($"taskList{task}, dateList{date}");

                    foreach (var log in toDolist) ;
                    
                    break;
                    case "B":
                    Console.WriteLine("log");
                    break;
                    case "C":
                    Environment.Exit(0);
                    break;
                 
            }

            


        }
    }
}
