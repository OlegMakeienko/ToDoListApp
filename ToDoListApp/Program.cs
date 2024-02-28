namespace ToDoListApp;

using System;

public class Program
{
    static void Main(string[] args)
    {
        ToDoList toDoList = new ToDoList();
        toDoList.LoadTasksFromFile("tasks.json");
        while (true)
        {
            ColoredTextInConsole.WriteLine("Welcome to ToDoLy", ConsoleColor.Cyan);
            Console.WriteLine("You have {0} tasks todo and {1} tasks are done!", toDoList.GetToDoTaskCount(), toDoList.GetDoneTaskCount());
            ColoredTextInConsole.WriteLine("Pick an option:", ConsoleColor.Cyan);
            Console.WriteLine("(1) Show Task List (by date or project)");
            Console.WriteLine("(2) Add New Task");
            Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
            Console.WriteLine("(4) Save and Quit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    toDoList.DisplayAllTasks(toDoList.GetAllTasks());
                    break;
                case "2":
                    toDoList.AddTask();
                    break;
                case "3":
                    toDoList.EditTask();
                    break;
                case "4":
                    toDoList.SaveTasksToFile("tasks.json");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}