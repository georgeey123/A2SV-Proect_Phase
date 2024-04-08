enum TaskCategories
{
    Personal,
    Work,
    Errands
}

class NewTask
{
    public required string Name {get; set;}
    public required string Description {get; set;}
    public TaskCategories Category {get; set;}
    public bool IsCompleted {get; set;}

    public override string ToString()
    {
        string str = $"Task: {this.Name}\nDescription: {this.Description}\nCategory: {this.Category}\n";
        if (this.IsCompleted) str += "Task is completed\n";
        else str += "Task is not complete\n";

        return str;
    }

    public string ToCsvString()
    {
        return $"{Name},{Description},{(int)Category},{IsCompleted}";
    }
}

class TaskManager
{
    public List<NewTask> Tasks = new List<NewTask>();
    public void AddTask(NewTask newTask)
    {
        Tasks.Add(newTask);
    }

    public void DisplayTasks(List<NewTask> tasks)
    {
        Console.WriteLine();
        foreach (NewTask item in tasks)
        {
            Console.WriteLine(item);
        }
    }

    public List<NewTask> FilterTask(TaskCategories category)
    {
        List<NewTask> CurrCatergory = Tasks.FindAll(task => task.Category == category);
        return CurrCatergory;
    }
    
    public async Task WriteTasksToCSV()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter("tasks.csv", true))
            {
                foreach (var task in Tasks)
                {
                    await sw.WriteLineAsync(task.ToCsvString());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public void CreateTaskFromCSV(string line)
    {
        string? name, description;
        TaskCategories category;
        bool isCompleted;

        string[] details = line.Split(",");
        name = details[0];
        description = details[1];
        category = (TaskCategories)int.Parse(details[2]);
        
        if (details[3].ToLower() == "true") isCompleted = true;
        else isCompleted = false;
        
        NewTask task = new NewTask 
        {
            Name = name,
            Description = description,
            Category = category,
            IsCompleted = isCompleted,
        };

        this.AddTask(task);
    }

    public async Task ReadTasksFromCSV()
    {
        try
        {
            using (StreamReader sr = new StreamReader("tasks.csv"))
            {   
                string? line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    this.CreateTaskFromCSV(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No tasks added");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
