using System.Text.Json;

namespace ToDoListApp;

public class ToDoList
{
    private List<Task> tasks = new List<Task>();
    
    public List<Task> GetAllTasks()
    {
        return tasks;
    }

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
        ColoredTextInConsole.WriteLine("Task deleted\n", ConsoleColor.Green);
    }

    public void EditTask()
    {
        ColoredTextInConsole.WriteLine("Enter the title of the task you want to edit:", ConsoleColor.Cyan);
        string title = Console.ReadLine();

        Task taskToEdit = tasks.FirstOrDefault(t => t.Title == title);

        if (taskToEdit != null)
        {
            ColoredTextInConsole.WriteLine("Enter new task title:", ConsoleColor.Cyan);
            string newTitle = Console.ReadLine();
            taskToEdit.Title = newTitle;

            ColoredTextInConsole.WriteLine("Enter new due date (yyyy-mm-dd):", ConsoleColor.Cyan);
            DateTime newDueDate = DateTime.Parse(Console.ReadLine());
            taskToEdit.DueDate = newDueDate;

            ColoredTextInConsole.WriteLine("Enter new project:", ConsoleColor.Cyan);
            string newProject = Console.ReadLine();
            taskToEdit.Project = newProject;

            ColoredTextInConsole.WriteLine("Mark as done? (yes/no):", ConsoleColor.Red);
            string done = Console.ReadLine();
            taskToEdit.IsDone = done.ToLower() == "yes";

            Console.WriteLine("Task updated successfully!");
        }
        else
        {
            ColoredTextInConsole.WriteLine("Task not found.", ConsoleColor.Red);
        }
    }

    public void DisplayAllTasks(List<Task> displayList)
    {
        ColoredTextInConsole.WriteLine("TITLE:".PadRight(24) + "PROJECT:".PadRight(16) + "DUE DATE:".PadRight(16) + "STATUS:",
            ConsoleColor.DarkBlue);

        foreach (Task task in displayList)
        {
            string statusString;
            if (task.IsDone)
            {
                statusString = "Completed";
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (task.DueDate < DateTime.Now)
            {
                statusString = "In progress!";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else statusString = "";
                
            Console.WriteLine(task.Title.PadRight(24)
                              + task.Project.PadRight(16)
                              + task.DueDate.ToString("d").PadRight(16)
                              + statusString);
            Console.ResetColor();
        }
        Console.WriteLine("");
    }
    public void DisplayTasksByDate()
    {
        var orderedTasks = tasks.OrderBy(t => t.DueDate).ToList();

        foreach (var task in orderedTasks)
        {
            Console.WriteLine("Title: {0}, Due Date: {1}, Project: {2}, Is Done: {3}", task.Title, task.DueDate, task.Project, task.IsDone ? "Yes" : "No");
        }
    }


    public void DisplayTasksByProject()
    {
        var orderedTasks = tasks.OrderBy(t => t.Project).ToList();
        
        foreach (var task in orderedTasks)
        {
            Console.WriteLine("Title: {0}, Due Date: {1}, Project: {2}, Is Done: {3}", task.Title, task.DueDate, task.Project, task.IsDone ? "Yes" : "No");
        }
    }
    
    public int GetToDoTaskCount()
    {
        return tasks.Count(t => !t.IsDone);
    }

    public int GetDoneTaskCount()
    {
        return tasks.Count(t => t.IsDone);
    }

    public void AddTask()
    {
        Console.WriteLine("Enter task title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter due date (yyyy-mm-dd):");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter project:");
        string project = Console.ReadLine();

        Task newTask = new Task { Title = title, DueDate = dueDate, Project = project, IsDone = false };
        tasks.Add(newTask);

        Console.WriteLine("Task added successfully!");
    }
    public void SaveTasksToFile(string filePath)
    {
        var json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);
    }

    public void LoadTasksFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<List<Task>>(json);
        }
    }
}