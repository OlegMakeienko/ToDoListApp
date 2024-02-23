namespace ToDoListApp;

public class ToDoList
{
    private List<Task> tasks = new List<Task>();

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    public void MarkTaskAsDone(Task task)
    {
        task.IsDone = true;
    }

    public List<Task> GetTasksByDate()
    {
        return tasks.OrderBy(t => t.DueDate).ToList();
    }

    public List<Task> GetTasksByProject()
    {
        return tasks.OrderBy(t => t.Project).ToList();
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