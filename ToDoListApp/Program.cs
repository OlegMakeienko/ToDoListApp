namespace ToDoListApp;

using System;

public class Program
{
    static void Main(string[] args)
    {
        ToDoList toDoList = new ToDoList();
        while (true)
        {
            Console.WriteLine("Welcome to ToDoLy");
            Console.WriteLine("You have {0} tasks todo and {1} tasks are done!", toDoList.GetToDoTaskCount(), toDoList.GetDoneTaskCount());
            Console.WriteLine("Pick an option:");
            Console.WriteLine("(1) Show Task List (by date or project)");
            Console.WriteLine("(2) Add New Task");
            Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
            Console.WriteLine("(4) Save and Quit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    toDoList.GetTasksByDate();
                    break;
                case "2":
                    toDoList.AddTask();
                    break;
                case "3":
                    // Här ska jag ändra Task
                    break;
                case "4":
                    // Här sparar jag alla ändringar och Quit
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}