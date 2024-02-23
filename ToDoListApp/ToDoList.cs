namespace ToDoListApp;

public class ToDoList
{
    private List<Task> tasks = new List<Task>();

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    public void EditTask()
    {
        Console.WriteLine("Enter the title of the task you want to edit:");
        string title = Console.ReadLine();

        Task taskToEdit = tasks.FirstOrDefault(t => t.Title == title);

        if (taskToEdit != null)
        {
            Console.WriteLine("Enter new task title:");
            string newTitle = Console.ReadLine();
            taskToEdit.Title = newTitle;

            Console.WriteLine("Enter new due date (yyyy-mm-dd):");
            DateTime newDueDate = DateTime.Parse(Console.ReadLine());
            taskToEdit.DueDate = newDueDate;

            Console.WriteLine("Enter new project:");
            string newProject = Console.ReadLine();
            taskToEdit.Project = newProject;

            Console.WriteLine("Mark as done? (yes/no):");
            string done = Console.ReadLine();
            taskToEdit.IsDone = done.ToLower() == "yes";

            Console.WriteLine("Task updated successfully!");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
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
}